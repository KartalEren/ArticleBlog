﻿
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

        public Article()//illa parametreli ctor olmaması adına bu şekilde parametreside ctor oluşturduk.
        {
            ArticleVisitors=new HashSet<ArticleVisitor>();
        }


        public Article(string title, string content,int userId, string createdBy,int categoryId,int imageId) //kod okunabilirliği açısından parametreli ctor yarattık. Yukarıda da boş ctor yarattık.
        {
            Title=title;
            Content=content;
            UserId=userId;
            CategoryId=categoryId;
            ImageId=imageId;
            CreatedBy = createdBy;
        }





        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0; //default 0 deriz.

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

      
        public int UserId { get; set; }
        //public AppUser User { get; set; }



        public ICollection<ArticleVisitor> ArticleVisitors { get; set; } //Bir makalenin 1 den fazla ziyaretçisi olabilir.

    }
}
