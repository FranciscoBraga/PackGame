using PackGameApplicationLayer.ApplicationImplemation;
using PackGameData.DataContext;
using System.Web.Mvc;
using System;

namespace PackGameWeb.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioApplication usuarioApplication = new UsuarioApplication();
        private PerfilApplication perfilApplication = new PerfilApplication();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            if (ModelState.IsValid)
            {
                

              Usuario usuario =  usuarioApplication.Logar(u.senha, u.email);

                if (usuario != null)
                {
                    Session["usuarioId"] = usuario.idUsuario;
                    Session["usuarioNome"] = usuario.nome;
                    return RedirectToAction("../Areas/Area/Index");
                }
                else
                {
                    ViewBag.Message = "Erro: Login e Senha ínvalidos";
                }
            }
         
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Usuario u)
        {
            if (ModelState.IsValid)
            {

                Perfil perfil = perfilApplication.BuscaPerfil("Jogador");
                u.idPerfil = perfil.idPerfil;
                usuarioApplication.AdicionarUsuario(u);
                return RedirectToAction("../Area/Index", new { u.idUsuario });
                
            }
            else
            {
                return View(u);
            }

           
        }

    }
}