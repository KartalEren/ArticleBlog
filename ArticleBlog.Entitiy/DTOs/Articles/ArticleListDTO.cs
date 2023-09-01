using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Articles
{
    //HOME-INDEX ANA SAYFA BİLGİLERİ İÇİN PAGINATION İÇİN GEREKLİ BİLGİLERDİR. SAYFA İLK AÇILDIĞINDA SİTE ANA SAYFASIDIR BURADAKİ BİLGİLER
    public class ArticleListDTO //makalelerin kaç tane olduğunu göstermek için yaptık Pagination işlemi için
    {
        public IList<Article> Articles { get; set; } //tüm makaleleri getireceğiz.
        public int? CategoryId { get; set; }
        public virtual int CurrentPage { get; set; } = 1; //Home-Index te 1 sayfada olduğumuzu gösterir.
        public virtual int PageSize { get; set; } = 3; //Home-Index te sayfada kaç makale göründüğünün bilgisidir 1 kere de gösterilen makalelerdir.
        public virtual int TotalCount { get; set; } //Home-Index te sayfada alttaki sayfa sayılarını gösterir <1-2-3-4-5 gibi>
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));//toplam 50 makalem varsa ve ben 1 sayfada maksimum 3 makale listeiyorsam benim aşağıdaki sayfa sayılarım 17 sayfa olacaktır. Bunun heaabı yapılır.
        public virtual bool ShowPrevious => CurrentPage > 1; //bir önceki sayfayı gösterir
        public virtual bool ShowNext => CurrentPage < TotalPages; //maksimum kaç sayfam varsa bir sonraki ilerleteceği sayfa toplam sayfasan küçük olmalıdır.
        public virtual bool IsAscending { get; set; } = false;
    
    }
}
