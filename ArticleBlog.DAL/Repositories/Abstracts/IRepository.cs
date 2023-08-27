using ArticleBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Repositories.Abstracts
{
    //***BURDA METOTLARIN SOYUT HALİ KULLANILIR, REPOSITORY DE İSE SOMUT HALİ KULLANILIR.
    public interface IRepository<T> where T : class, IEntityBase,new() //IRepository new edebilelim ki nesnelerimi ben buraya yollayabileyim ayrıca IEntityBase ile etiketleme yapmış olduk. Bu sınıftan türememiş hiç bir sınıf Repository i kullanamasın dedik. IRepository ninde <T> almasının nedeni, Repository(somut) sınıfımızı burada soyuta çevirirken oradan gelen metotların içerisinde <T> türünü belirtirken burada sıkıntı çıkarmasın diye aynı şekil tanımlamış olduk.
    {
        Task AddAsync(T entity); //Ekleme metodudur. Task ı burada sanki void anlamında gibi düşünebiliriz. Yani bir değer,veri döndürmez, eğer istersek yalnızca uyarı mesajı verebiliriz.  Task içerisinde değer olmadığı için return yapılmaz.
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); //Liste olarak geri döndüren metottur. Çünkü biz burada tüm article ları geri isteyeceğiz. Func içerisinde ise; T entity değeri verip bool bir değer döndürmesini istiyoruz, bool değer yazmamızın sebebi where sorgusu yazacağımızdandır(yani tüm article ları getir ama isdeletede olmayanları geit şartı gibi). 2. Func da ise gene T entity değeri verip object dizisi(1 den fazla olabileceği için dizi yaptık.) döndürmeyi istiyoruz. includeProperties ise birbiriyle bağlı entityleri döndürmeye yarar. Task içerisinde <List<T>> olduğu için liste değer döndürürüz.

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //Bu metot bize 1 tane veri döndürür. Mesela id si 2 olan veriyi silmek için burada id si 2 olanveriyi eşitlersek sadece 1 değer bize döndürmesini sağlarız. Task içerisinde <T> olduğu için değer döndürürüz.
        Task<T> GetByIdAsync(int id); //id ye göre bul getir. Task içerisinde <T> olduğu için değer döndürürüz.
        Task<T> UpdateAsync(T entity); //Güncelleme(Edit) işlemini gerçeleştiren soyut sınıf metottur. Task içerisinde <T> olduğu için değer döndürürüz.
        Task DeleteAsync(T entity); //Hiç bir veriyi tamamen silmek istemiyoruz bunu sadece silinmiş gibii göstereceğiz. (isDeleted=true gibi görünecek ve listeden kaldırılıp silinmiş gibi görünecek.) Task içerisinde değer olmadığı için return yapılmaz.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Burada değeri verip işlemleri Any e göre yaptıracağız.  Task içerisinde <bool> olduğu için değer döndürürüz.
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null); //Burada ise mesela Article Tablomuzda kaç makale olduğunun sayısını bize döndürecektir. Task içerisinde <int> olduğu için değer döndürürüz.

    }
}
