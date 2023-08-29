using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Articles
{
    public class ArticleDTO
    {
        public virtual int ID { get; set; }
        public virtual string CreatedBy { get; set; }//article kim tarafından yaratıldı?
        public string Content { get; set; }
        public virtual DateTime CreatedDate { get; set; }  //article yaratma tarihi. Null geçilebilir (?) yaptık.
        public string Title { get; set; }
        public CategoryDTO Category { get; set; } //kategori adına ulaşmak için bu DTO türünde prop açtık.       
        public int ViewCount { get; set; } 
        public bool IsDeleted { get; set; }  
      
    }
}
