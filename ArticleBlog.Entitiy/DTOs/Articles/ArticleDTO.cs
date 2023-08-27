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
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now; //article yaratma tarihi. Null geçilebilir (?) yaptık.
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } 
    }
}
