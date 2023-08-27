using ArticleBlog.Core.Entities;
using ArticleBlog.DAL.Context;
using ArticleBlog.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Repositories.Concreates
{
    //***BURDA METOTLARIN SOMUT HALİ KULLANILIR, IREPOSITORY DE İSE SOYUT HALİ KULLANILIR.
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() //Repository new edebilelim ki nesnelerimi ben buraya yollayabileyim ayrıca IEntityBase ile etiketleme yapmış olduk. Bu sınıftan türememiş hiç bir sınıf Repository i kullanamasın dedik.
    {
        private readonly BlogDBContext _dbContext;
        public Repository(BlogDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        private DbSet<T> BlogTable { get => _dbContext.Set<T>(); }// burada _dbContext i Table ismine atadık. Böylece sürekli ctorda eşleme yaparken _dbContext çağırmak yerine BlogTable diyebiliriz.
        public async Task AddAsync(T entity) //Ekleme metodudur. Task ı burada sanki void anlamında gibi düşünebiliriz. Yani bir değer,veri döndürmez, eğer istersek yalnızca uyarı mesajı verebiliriz.  Task içerisinde değer olmadığı için return yapılmaz.
        {
            await BlogTable.AddAsync(entity); //asyn metot olduğu için await kullanmamız gereklidir.
        }



        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)//Liste olarak geri döndüren metottur. Çünkü biz burada tüm article ları geri isteyeceğiz. Func içerisinde ise; T entity değeri verip bool bir değer döndürmesini istiyoruz, bool değer yazmamızın sebebi where sorgusu yazacağımızdandır(yani tüm article ları getir ama isdeletede olmayanları geit şartı gibi). 2. Func da ise gene T entity değeri verip object dizisi(1 den fazla olabileceği için dizi yaptık.) döndürmeyi istiyoruz. includeProperties ise birbiriyle bağlı entityleri döndürmeye yarar. Task içerisinde <List<T>> olduğu için liste değer döndürürüz.
        {
            IQueryable<T> query = BlogTable; //IQueryable(***Veri tabanından verileri geniş kapsamlı sorgulamak için kullanılır.) türünde __dbContext(BlogTable) nesnesinin burada set ettik.
            if (predicate != null) //predicate default değeri parametrede null olarak atandı, aksi durumda metodun 2. seçeneğini(includeProperties) kullanmak istersek sıkıntı yaşardık.
            {
                query = query.Where(predicate);//yukarıda belirttiğimiz where şartını burada sağlarız.
            }
            if (includeProperties.Any()) //Örnek vermek gerekirse eğer içerisinde 1 tane article varsa bunu foreachle dön
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item); // hem kategori hem image vs buraya çağırmış olabileceğiz.
                }
            }
            return query.ToList(); //Yaptğımız query(sorgunun) liste olarak dönmesini sağlamış olduk.

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)  //Bu metot bize 1 tane veri döndürür. Mesela id si 2 olan veriyi silmek için burada id si 2 olanveriyi eşitlersek sadece 1 değer bize döndürmesini sağlarız. Task içerisinde <T> olduğu için değer döndürürüz.
        {
            IQueryable<T> query = BlogTable; //IQueryable(***Veri tabanından verileri geniş kapsamlı sorgulamak için kullanılır.) türünde __dbContext(BlogTable) nesnesinin burada set ettik.
            query = query.Where(predicate); //yukarıda belirttiğimiz where şartını burada sağlarız.


            foreach (var item in includeProperties)
            {
                query = query.Include(item); // hem kategori hem image vs buraya çağırmış olabileceğiz.
            }
            return await query.SingleAsync(); //Yaptğımız query(sorgunun) 1 tane nesne dönmesini sağlamış olduk.
        }




        public async Task<T> GetByIdAsync(int id) //id ye göre bul getir. Task içerisinde <T> olduğu için değer döndürürüz.
        {
            return await BlogTable.FindAsync(id); 

        }

        public async Task<T> UpdateAsync(T entity) //Update metodu async olarak ÇALIŞMAZ. bUNDAN DOLAYI uPDATE İN ASYN METODU DOĞRUDAN YOKTUR. Güncelleme(Edit) işlemini gerçeleştiren somut sınıf metottur. Task içerisinde <T> olduğu için değer döndürürüz.
        {
           await Task.Run(() => BlogTable.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity) //Silme(Delete) işlemini gerçeleştiren somut sınıf metottur. Task içerisinde değer olmadığı için return yapılmaz.
        {
            await Task.Run(() => BlogTable.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) //Burada değeri verip işlemleri Any e göre yaptıracağız. Task içerisinde <bool> olduğu için değer döndürürüz.
        {
          return await BlogTable.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)//Burada ise mesela Article Tablomuzda kaç makale olduğunun sayısını bize döndürecektir. Task içerisinde <int> olduğu için değer döndürürüz.
        {
            return await BlogTable.CountAsync(predicate); 
        }

      
    }

}
