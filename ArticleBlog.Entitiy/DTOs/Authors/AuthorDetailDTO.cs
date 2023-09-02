using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Authors
{
    public class AuthorDetailDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }       
        public ICollection<Article> Articles { get; set; }
        public AuthorDetailDTO()
        {
            Articles = new HashSet<Article>();
        }
    }
}
