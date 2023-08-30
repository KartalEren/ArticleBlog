using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Categories
{
    public class CategoryDTO //Burada isimleri gösterip idleri kullanırız.
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
