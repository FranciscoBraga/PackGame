using PackGameData.DataContext;
using PackGameData.GenericRepository;
using System;
using System.IO;
using System.Web;
using System.Drawing;

namespace PackGameData.RepositoryImplemetation
{
    public class ImagemRepository : GenericRepository<Imagem>, IImagemRepository
    {
        public void UploadFile(string caminho, HttpPostedFileBase file)
        {

            file.SaveAs(caminho);
        }

        public string resizeImageAndSave(string imagePath, int largura, int altura, string prefixo)
        {
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imagePath);
            var thumbnailImg = new Bitmap(largura, altura);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, largura, altura);
            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
            string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath), Path.GetFileNameWithoutExtension(imagePath)+prefixo);
            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            thumbnailImg.Dispose();
            return targetPath;
        }
    }
}
