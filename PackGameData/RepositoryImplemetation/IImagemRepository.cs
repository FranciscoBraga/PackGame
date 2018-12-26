using PackGameData.DataContext;
using PackGameData.GenericRepository;
using System.Web;

namespace PackGameData.RepositoryImplemetation
{
    public  interface IImagemRepository:IGenericRepository<Imagem>
    {
        void UploadFile(string caminho, HttpPostedFileBase file);
        string resizeImageAndSave(string imagePath, int largura, int altura, string prefixo);
    }
}