using ArticleBlog.Core.Entities;
using ArticleBlog.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable //Buradan türetilmesinin neden asenkron bir yapı yapmamız gerektiği için
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new(); //***NOT:Tüm Repositoryleri yazıp içleri boş şekilde kalan entity yerine (mesela article, image category vs...için ayrı ayrı repo açıp IRepository den kalıtım alıp içi boş boş duran class ları DAL-Repositories-Abstract klasöründe açacağımıza tek metotta onları jenerik olarak çağıracağımız bir metot oluşturduk.) tek metotta çağırıp işlemleri kısalttık. Repository türünde  içerisinde <T> olduğu için değer döndürürüz. Buradan Repository metotlarına Entity adı belirtrek ulaşabiliriz.

        Task<int> SaveAsync(); //Task içerisinde <int> olduğu için değer döndürürüz.

        int Save(); //asenkron kullanılmaması durumunda bu kayıt işlemini kullanmak için yaptık. Int olduğu için geriye değer döndürür.
    }
}
