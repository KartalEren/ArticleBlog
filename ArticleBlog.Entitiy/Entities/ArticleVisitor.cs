using ArticleBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.Entities
{
    public class ArticleVisitor:IEntityBase
    {
        public Article Article { get; set; }
        public int ArticleId { get; set; }
        public Visitor Visitor { get; set; }
        public int VisitorId { get; set; }


        public ArticleVisitor(int articleId, int visitorId)
        {
            ArticleId=articleId;
            VisitorId=visitorId;
        }
        public ArticleVisitor()
        {
            
        }
    }
}
