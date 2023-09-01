using ArticleBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.Entities
{
    public class Visitor:IEntityBase //ziyaret yapan kullanıcı bulunur.
    {
        public Visitor()
        {
            //1 adet boş parametreli ctor tanımlarız

            ArticleVisitors=new HashSet<ArticleVisitor>();

        }

        public Visitor(string ipAddress, string userAgent)
        {
            //burada da parametreli ctor tanımlarız ki bu sınıf newlenince 2 şekli olsun hem boş hem parametreli oluşabilir diye......

            IpAddress=ipAddress;
            UserAgent=userAgent;


        }

        public int ID { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;


        public ICollection<ArticleVisitor> ArticleVisitors { get; set; } //Bir Visitor ün 1 den fazla ziyaretçisi olabilir.



    }
}
