using ArticleBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.Entities
{
    public class Category : EntityBase
    {        


        public string CategoryName { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public Category(string categoryName, string createdBy)
        {
            CategoryName = categoryName;
            CreatedBy = createdBy; 
        }
    }
}
