using ArticleBlog.Entitiy.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Articles
{
    public class ArticleUpdateDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }

        public ArticleUpdateDTO()
        {
            Categories = new HashSet<CategoryDTO>();
        }
    }
}
