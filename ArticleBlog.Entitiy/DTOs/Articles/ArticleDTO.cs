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
        public virtual string CreatedBy { get; set; }
        public string Content { get; set; }
        public virtual DateTime CreatedDate { get; set; }  
        public string Title { get; set; }
        public CategoryDTO Category { get; set; }        
        public int ViewCount { get; set; }
        public Image Image { get; set; }
        public AppUser User { get; set; }
        public bool IsDeleted { get; set; }  
      
    }
}
