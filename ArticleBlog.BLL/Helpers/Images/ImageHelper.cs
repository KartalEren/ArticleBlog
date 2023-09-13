using ArticleBlog.Entitiy.DTOs.Images;
using ArticleBlog.Entitiy.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Helpers.Images
{
    public class ImageHelper : IImageHelper 
    {
        private readonly IWebHostEnvironment _whe;
        private readonly string wwwroot;
        private const string imgFolder = "images";
        private const string articleImagesFolder = "article-images"; 
        private const string userImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment whe) 
        {
            this._whe = whe;
            wwwroot = whe.WebRootPath;
        }


        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        } //Klavyedeki büyük küçük harf değişikliği yapan metottur.




        public Task Delete(string imageName)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile,ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder; //folderName i kullanmak için imageType ı ImageType.User ise userImagesFolder kullan değilse articleImagesFolder kullan dedik.

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))//önceden böyle bi dosya adı oluşturulmuş mu onu chech ederiz
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");//dosya yoksa aç deriz.


            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name); //dosya adın bu metottan çıkan addır diyoruz.

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";//***AYNI İSİMLİ RESİM EKLENİRSE DOSYA SONUNA EKLENDİĞİ MILISECOND SÜRESİDE EKLENECEKTİR VE DOSYA ADLARININ BU ŞEKİLDE AYNI OLMASI ZOR OLACAKTIR.

            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName); // wwwroot git imgFolder ı bul folderName i yukarıda kıyasla newFileName olarak ekle

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false); //burada yukarılarda oluşturulan dosyaları kopyalayarak oluştururuz.
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string message = imageType == ImageType.User ? $"{newFileName} user picture succesfully added." : $"{newFileName} article picture succesfully added"; //Ternary if: bu resmi kaydeden User ise (ImageType.User)

            return new ImageUploadedDTO()
            {
                FullName = $"{folderName}/{newFileName}"
            };

        }
        public void DeleteImage(string imageName) //resim silme metodudur.
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);

        }

    }
}
