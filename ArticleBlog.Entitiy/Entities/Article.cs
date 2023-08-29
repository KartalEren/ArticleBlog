
using ArticleBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.Entities
{
    public class Article : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        //public AppUser User { get; set; }
        //public int UserId { get; set; }

    }
}
