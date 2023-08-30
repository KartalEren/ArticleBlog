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
        public ICollection<Article> Articles { get; set; }//1 kategori 1 den fazla article içerebilir

        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public Category(string categoryName, string createdBy)//kod okunabilirliği açısından parametreli ctor yarattık. Yukarıda da boş ctor yarattık.
        {
            CategoryName = categoryName;
            CreatedBy = createdBy; //kimin işlem yaptığını controllerlarda belirtirken bu parameter gereklidir.
        }
    }
}
