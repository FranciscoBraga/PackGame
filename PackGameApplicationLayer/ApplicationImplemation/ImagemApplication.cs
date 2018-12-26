using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PackGameApplicationLayer.ApplicationImplemation
{
    public class ImagemApplication
    {

        private ImagemRepository ImagemRepository = new ImagemRepository();


        public ImagemApplication()
        {

        }


        public List<Imagem> GetImagem(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return ImagemRepository.GetTodos().ToList();

                }
                else
                {
                    return ImagemRepository.Get(l => l.idImagem == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarImagem(Imagem Imagem)
        {
            try
            {
                ImagemRepository.Adicionar(Imagem);
                ImagemRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Imagem ProcurarImagem(int? id)
        {
            try
            {
                return ImagemRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirImagem(Imagem Imagem)
        {
            try
            {

                ImagemRepository.Deletar(l => l == Imagem);
                ImagemRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarImagem(Imagem Imagem)
        {
            try
            {
                ImagemRepository.Atualizar(Imagem);
                ImagemRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void SalvarImage(string caminho, HttpPostedFileBase file)
        {
            try
            {
                ImagemRepository.UploadFile(caminho, file);
                ImagemRepository.resizeImageAndSave(caminho, 170, 256, "p");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
