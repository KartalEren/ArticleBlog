using ArticleBlog.DAL.Context;
using ArticleBlog.DAL.Repositories.Abstracts;
using ArticleBlog.DAL.Repositories.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDBContext _dbContext;
        public UnitOfWork(BlogDBContext dBContext) //DAL-Concreates deki Repository yapımızdaki gibi ctor yaptık ve db yi new ledik. Çünkü burada da veri tabanıyla işlemimiz var.
        {
            this._dbContext = dBContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public int Save() //asenkron kullanılmaması durumunda bu kayıt işlemini kullanmak için yaptık. Int olduğu için geriye değer döndürür.
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync() //Task içerisinde <int> olduğu için değer döndürürüz.
        {
           return await _dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>() //NOT:***Tüm Repositoryleri yazıp içleri boş şekilde kalan entity yerine (mesela article, image category vs...için ayrı ayrı repo açıp IRepository den kalıtım alıp içi boş boş duran class ları DAL-Repositories-Abstract klasöründe açacağımıza tek metotta onları jenerik olarak çağıracağımız bir metot oluşturduk.) tek metotta çağırıp işlemleri kısalttık. Repository türünde içerisinde <T> olduğu için değer döndürürüz. Buradan Repository metotlarına Entity adı belirtrek ulaşabiliriz.
        {
           return new Repository<T>(_dbContext);
        }

        //NOT: İLERDE KULLANACAĞIMIZ METOTLAR BUNLARDIR. UNIT OF WORK YAPISINI KULLANIP GetRepository<T>() METODUNU ÇAĞIRIP İÇERİSİNE JENERİK YAPISI SAYESİNDE İSTEDİĞİMİZ ENTITIY VERİP REPOSITORY İÇERİSİNDEKİ METOTLARA ULAŞABİLECEĞİZ.
    }
}
