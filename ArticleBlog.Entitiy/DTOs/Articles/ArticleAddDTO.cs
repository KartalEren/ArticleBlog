using ArticleBlog.Entitiy.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Articles
{
    public class ArticleAddDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }

        public ArticleAddDTO()
        {
            Categories = new HashSet<CategoryDTO>();
        }
    }
}
