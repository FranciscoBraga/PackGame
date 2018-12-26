using System;

using System.IO;
using System.IO.Compression;

using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PackGameApplicationLayer;
using PackGameApplicationLayer.ApplicationImplemation;
using PackGameData.DataContext;
using PackGameWeb.Areas.Usuario.Models;

namespace PackGameWeb.Areas.Usuario.Controllers
{
    public class JogoController : Controller
    {
        private JogoApplication jogoApplication = new JogoApplication();
        private ImagemApplication imagemApplication = new ImagemApplication();
        private GeneroApplication generoApplication = new GeneroApplication();
        private EtapaApplication etapaApplication = new EtapaApplication();
        // GET: Usuario/Jogo
        public ActionResult Index()
        {
           
            return View(jogoApplication.GetJogo());
        }

        // GET: Usuario/Jogo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = jogoApplication.ProcurarJogo(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Usuario/Jogo/Create
        public ActionResult Create()
        {
            ViewBag.idEtapa = new SelectList(etapaApplication.GetEtapa(), "idEtapa", "etapaGame");
            ViewBag.idGenero = new SelectList(generoApplication.GetGenero(), "idGenero", "generoGame");
            ViewBag.idImagem = new SelectList(imagemApplication.GetImagem(), "idImagem", "caminho");

            return View();
        }

        // POST: Usuario/Jogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJogo,nome,descricao,idGenero,idEtapa")] Jogo jogo , Upload fileBase)
        {
            string nomeArquivo = "";
            string nomeImagem = "";
            var caminho = "";
        
            if (fileBase.Arquivo.ContentLength>0)
            {
                try
                { 

                    string getName = fileBase.Arquivo.FileName;
                                 
                    int depoisDoPonto = getName.IndexOf(".");
                    string complemento = getName.Substring(depoisDoPonto);
                    nomeArquivo = jogo.nome+complemento;
                    nomeImagem = jogo.nome + "p" + complemento;
                    caminho = Path.Combine(Server.MapPath("~/Files/Image"), nomeArquivo);
                  
                    fileBase.Arquivo.SaveAs(caminho);
                  
                    imagemApplication.SalvarImage(caminho,fileBase.Arquivo);

                 
                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();

                }
            }
            if (ModelState.IsValid)
            {
                Imagem imagem = new Imagem();
                imagem.caminho = nomeImagem;
                imagemApplication.AdicionarImagem(imagem);
                jogo.idImagem = imagem.idImagem;
                jogo.isUpload = "n";             
                
                jogoApplication.AdicionarJogo(jogo);
               
              
                return RedirectToAction("UploadGame/"+jogo.idJogo);
            }

            ViewBag.idEtapa = new SelectList(etapaApplication.GetEtapa(), "idEtapa", "etapaGame", jogo.idEtapa);
            ViewBag.idGenero = new SelectList(generoApplication.GetGenero(), "idGenero", "generoGame", jogo.idGenero);
            ViewBag.idImagem = new SelectList(imagemApplication.GetImagem(), "idImagem", "caminho", jogo.idImagem);
            return View(jogo);
        }

        // GET: Usuario/Jogo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = jogoApplication.ProcurarJogo(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEtapa = new SelectList(etapaApplication.GetEtapa(), "idEtapa", "etapaGame", jogo.idEtapa);
            ViewBag.idGenero = new SelectList(generoApplication.GetGenero(), "idGenero", "generoGame", jogo.idGenero);
            ViewBag.idImagem = new SelectList(imagemApplication.GetImagem(), "idImagem", "caminho", jogo.idImagem);
            return View(jogo);
        }

        // POST: Usuario/Jogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJogo,nome,descricao,idGenero,idImagem,idEtapa")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                jogoApplication.AlterarJogo(jogo);
              
                return RedirectToAction("Index");
            }
            ViewBag.idEtapa = new SelectList(etapaApplication.GetEtapa(), "idEtapa", "etapaGame", jogo.idEtapa);
            ViewBag.idGenero = new SelectList(generoApplication.GetGenero(), "idGenero", "generoGame", jogo.idGenero);
            ViewBag.idImagem = new SelectList(imagemApplication.GetImagem(), "idImagem", "caminho", jogo.idImagem);
            return View(jogo);
        }

        // GET: Usuario/Jogo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = jogoApplication.ProcurarJogo(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Usuario/Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = jogoApplication.ProcurarJogo(id);
            jogoApplication.ExcluirJogo(jogo);
       
            return RedirectToAction("Index");
        }

        public ActionResult UploadGame()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadGame(int id, Upload fileBase)
        {
           
            Jogo jogo = jogoApplication.ProcurarJogo(id);

            string nomeArquivo = "";
            string nomePasta = "";
            var caminho = "";


            if (fileBase.Arquivo.ContentLength > 0)
            {
                try
                {

                    //string getName = fileBase.Arquivo.FileName;



                    nomeArquivo = jogo.nome;
                    nomeArquivo = nomeArquivo.ToLower();
                    nomeArquivo = nomeArquivo.Replace(" ", "");
                    string novoNomeArquivo = nomeArquivo + ".zip";
                    nomePasta = nomeArquivo;
                 
                   
                    //criando diretorio com o nome do jogo
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Files/Game/" + nomePasta));
                    //salvando na variável caminho a localização do jogo zipado
                    caminho = Path.Combine(Server.MapPath("~/Files/Game/"+nomePasta), novoNomeArquivo);
                    
                    fileBase.Arquivo.SaveAs(caminho);

                    try
                    {

                        //abrindo o jogo
                        ZipFile.ExtractToDirectory(caminho, Server.MapPath("~/Files/Game/"+nomePasta));
                        //deletando o arquivo zip
                        System.IO.File.Delete(caminho);
                        jogo.dateUpload = DateTime.Today;
                        jogo.isUpload = "s";
                        jogoApplication.AlterarJogo(jogo);
                        
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        return View();


                    }                                  

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    return View();


                }
            }

            
      

            ViewBag.idEtapa = new SelectList(etapaApplication.GetEtapa(), "idEtapa", "etapaGame", jogo.idEtapa);
            ViewBag.idGenero = new SelectList(generoApplication.GetGenero(), "idGenero", "generoGame", jogo.idGenero);
            ViewBag.idImagem = new SelectList(imagemApplication.GetImagem(), "idImagem", "caminho", jogo.idImagem);
            return View(jogo);

        }


    }
}
