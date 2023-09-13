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
    public interface IImageHelper
    {
        Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null); 

        void DeleteImage(string imageName);

    }
}
