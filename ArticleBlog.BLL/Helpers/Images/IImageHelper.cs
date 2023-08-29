using ArticleBlog.Entitiy.DTOs.Images;
using ArticleBlog.Entitiy.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Helpers.Images
{
    public interface IImageHelper//hemen bu sınıflarıda ImageHelper, IImageHelper da bll-extension-servislayer katmanında mapleriz
    {
        Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null); //resim yükleme metodudur.

        void DeleteImage(string imageName);//resim silme metodudur.

    }
}
