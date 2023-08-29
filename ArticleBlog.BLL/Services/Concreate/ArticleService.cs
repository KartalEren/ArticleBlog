using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{
    //Burada aslında Interface ve Normal abstract sınıfında bu metotları yapınca Dependency Injection yapmış oluyoruz birnevi.

    //Not: Repository lere direkt ulaşmamak için Unit Of Work yapısı oluşturmuştuk, o yapı üzerinde jeneri olarak  IRepository<T> IUnitOfWork.GetRepository<T>() metoduyla repository lere ulaşabilecektirk. Burada da aynı şekilde direkt Repositorylere ulaşmamak için Unit Of Work den ctor da eşleme yaparız.
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork; //Repolara ulaşmak için burada new leriz.
        private readonly IMapper mapper; //Liste türünde metotlarda Mapleme yapmak için burada new leriz.

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO) //Yeni bir article eklemek için kullanıcıya gösterdiğimiz DTO lar ile kullanıcılardan alınan bilgilere göre yeni makale ekler.
        {
            var userId = 1;
            var imageId = 1;
            var article = new Article(articleAddDTO.Title, articleAddDTO.Content, userId,articleAddDTO.CategoryId ,imageId); //Aşağıdaki gibi tek tek yazacağımı, Entity calsslarında oluşturduğum parametreli ctor ilede eşleme işlemi yapabilirim.


            //var article = new Article
            //{
            //    Title = articleAddDTO.Title,
            //    Content = articleAddDTO.Content,
            //    CategoryId = articleAddDTO.CategoryId,
            //    UserId= userId

            //}; //****Burada DTO dan alınan verileri asıl tablomuz olan burada yeni oluşturduğumuz Article ın içine ekleriz ve kaydetmiş oluruz.****


            await _unitOfWork.GetRepository<Article>().AddAsync(article);//Burada da unitofWork sayesinde REPOSITPRY E EKLEMİŞ OLURUZ.
            await _unitOfWork.SaveAsync(); // Burada da SaveChanges() mantığı gibi kayıt işlemi yapmış olduk.
        }

        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNoneDeletedAsync() //Liste türünde Article ları kategorileriyle birlikte silinmemiş olanları döndürecek.
        {

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted == false, x => x.Category);//***Burada IUnitOfWork ü ctor da eşleyerek, IUnitOfWork da oluşturduğumuz GetRepository<> metoduyla jenerik olarak yaptığımız için Article yazarak ArticleDTO sınıfı için tüm repository metodlarına return await _unitOfWork.GetRepository<Article>(). yaptıktan sonra ulaşmış oluyoruz. Ayrıca kategor,ye göre silinmemiş olanları GetAllAsync(x=>x.IsDeleted==false,x=>x.Category) metoduyla getirir articleları İşin kolaylığı burada....

            var map = mapper.Map<List<ArticleDTO>>(articles); //Burada DTO oluşturduğumuz ArticleDTO classının maplemek için yaparız ve deriz ki; buradaki dto da oluşturulan proplara göre listeleri getir demek isteriz. Yani göstermek istediğimiz propları index te veya herhangi cshtml de biz seçeriz böylece tüm propları kişilere güvenlik açısından açmamış oluruz. List türünde olmalıdır çünkü metot bir liste döndürür. Article Listesi döner.

            return map; //burada da Map leme işlemi yaptığımız map değişkenini döndürürüz ve böylece liste dönmüş olur.
        }



        public async Task<ArticleDTO> GetArticleWithCategoryNonDeletedAsync(int Id) //Tek bir değer Article kategorileriyle birlikte silinmemiş olanları ve id lere göre eşleyerek getirecek döndürecek.
        {

            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.ID == Id, x => x.Category);
            //***Kategoriye göre hem silinmemiş hemde buradaki id si ile kendindeki ID yi bul eşleştir getir dedik.
            //Burada IUnitOfWork ü ctor da eşleyerek, IUnitOfWork da oluşturduğumuz GetRepository<> metoduyla jenerik olarak yaptığımız için Article yazarak ArticleDTO sınıfı için tüm repository metodlarına return await _unitOfWork.GetRepository<Article>(). yaptıktan sonra ulaşmış oluyoruz. Ayrıca kategor,ye göre silinmemiş olanları GetAllAsync(x=>x.IsDeleted==false,x=>x.Category) metoduyla getirir articleları İşin kolaylığı burada....

            var map = mapper.Map<ArticleDTO>(article); //Burada DTO oluşturduğumuz ArticleDTO classının maplemek için yaparız ve deriz ki; buradaki dto da oluşturulan proplara göre listeleri getir demek isteriz. Yani göstermek istediğimiz propları index te veya herhangi cshtml de biz seçeriz böylece tüm propları kişilere güvenlik açısından açmamış oluruz. 

            return map; //burada da Map leme işlemi yaptığımız map değişkenini döndürürüz ve böylece liste dönmüş olur.
        }


        public async Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.ID == articleUpdateDTO.ID, x => x.Category); //Yukarıdaki metoda benzerdir.

            article.Title = articleUpdateDTO.Title;
            article.Content = articleUpdateDTO.Content;
            article.CategoryId = articleUpdateDTO.CategoryId; //Buralarda manuel mapper yapmak zorunda kaldık bu da bir yoldur. tek tek updatedto daki değerleri Article entitisimize eşleriz Database ye kullanıcıdan gelen değişiklikleri ataması için.           

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article); //burada da update yapılır.

            await _unitOfWork.SaveAsync();
        }



        public async Task SafeDeleteArticleAsync(int Id) //Tamamen silmeden Silmiş gibi işlem yaptırırız.
        {
            var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(Id); //sadece repositorydeki GetByIdAsync metoduyla silme işlemi yapabiliriz.

            article.IsDeleted = true; //IsDeleted true olduğu için biz article çağırdığımızda yukarılarda yaptığımız metotlarda !isDeleted ları almıştık dolayısıyla onlar gelmeyecek. BaseEntity de isDeletd=false tanımlıdır normalde.
            article.DeletedDate = DateTime.Now;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }


    }
}
