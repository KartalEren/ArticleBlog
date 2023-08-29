using ArticleBlog.Core.Entities;
using ArticleBlog.Entitiy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.Entities
{
    public class Image: EntityBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Article> Articles { get; set; }//1 resim 1 den fazla article içerebilir
        public ICollection<AppUser> Users { get; set; }//1 resim 1 den fazla article içerebilir


        public Image()
        {
            Articles = new HashSet<Article>();
            Users= new HashSet<AppUser>();
        }


        public Image(string fileName, string fileType, string createdBy)//kod okunabilirliği açısından parametreli ctor yarattık. Yukarıda da boş ctor yarattık.
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

    }
}
