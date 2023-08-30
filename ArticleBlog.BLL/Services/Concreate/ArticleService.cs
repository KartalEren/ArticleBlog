using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Helpers.Images;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Entitiy.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IImageHelper _imageHelper; //resim ekleme için article a buradan imageHelper içindeki metotlara ulaşırız hem eklemek hem silmek için
        private readonly IHttpContextAccessor _httpContextAccessor; //BLL-Extension-LoggedInUserExtensions deki ifadeleri görmesi için buraya servis ekledik. HttpContextAccessor ile kullanıcıyı bulmamızı sağlayan yapıdır.
        private readonly ClaimsPrincipal _user;//Bir üstteki _httpContextAccessor tanımlamak yerine kısa metotlarda olması adına _user şeklinde yapar ctor içine atarız ve _user ı kullanırız artık

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._imageHelper = imageHelper;

            this._httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;//burada eşleme işlemi aşağılarda uzun uzun olmaması adına _user a işlem yapan yapıyı eşitledik.
        }

        public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO) //Yeni bir article eklemek için kullanıcıya gösterdiğimiz DTO lar ile kullanıcılardan alınan bilgilere göre yeni makale ekler.
        {
            var userId = _user.GetLoggedInUserId();//artık loginlerde user ıd yi otomatik buluruz girişlerde.BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.
            var userEmail = _user.GetLoggedInEmail();//artık makaleleri kimin yarattığını Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir CreatedBy kısmına. BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.


            //önce resim ekleme işlemi yapılır db ye 
            //sonra article eklenir.
            var imageUpload = await _imageHelper.Upload(articleAddDTO.Title, articleAddDTO.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddDTO.Photo.ContentType, userEmail); //imagenn ctor unda istenilenleri ekledik.
            await _unitOfWork.GetRepository<Image>().AddAsync(image);//Burada da unitofWork sayesinde REPOSITPRY E EKLEMİŞ OLURUZ.
            await _unitOfWork.SaveAsync(); // Burada da SaveChanges() mantığı gibi kayıt işlemi yapmış olduk.



            //---------------------------------------------------------




            //var imageId = 1;
            var article = new Article(articleAddDTO.Title, articleAddDTO.Content, userId, userEmail, articleAddDTO.CategoryId, image.ID); //Aşağıdaki gibi tek tek yazacağımı, Entity calsslarında oluşturduğum parametreli ctor ilede eşleme işlemi yapabilirim. Yukarıdaki imagenin ID sini çeceriz.


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

            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.ID == Id, x => x.Category, i => i.Image);
            //***Kategoriye göre hem silinmemiş hemde buradaki id si ile kendindeki ID yi bul eşleştir getir dedik.
            //Burada IUnitOfWork ü ctor da eşleyerek, IUnitOfWork da oluşturduğumuz GetRepository<> metoduyla jenerik olarak yaptığımız için Article yazarak ArticleDTO sınıfı için tüm repository metodlarına return await _unitOfWork.GetRepository<Article>(). yaptıktan sonra ulaşmış oluyoruz. Ayrıca kategor,ye göre silinmemiş olanları GetAllAsync(x=>x.IsDeleted==false,x=>x.Category) metoduyla getirir articleları İşin kolaylığı burada....

            var map = mapper.Map<ArticleDTO>(article); //Burada DTO oluşturduğumuz ArticleDTO classının maplemek için yaparız ve deriz ki; buradaki dto da oluşturulan proplara göre listeleri getir demek isteriz. Yani göstermek istediğimiz propları index te veya herhangi cshtml de biz seçeriz böylece tüm propları kişilere güvenlik açısından açmamış oluruz. 

            return map; //burada da Map leme işlemi yaptığımız map değişkenini döndürürüz ve böylece liste dönmüş olur.
        }







        public async Task<string> UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var userEmail = _user.GetLoggedInEmail();//artık makaleleri kimin güncellediiğni Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir ModifiedBy kısmına.BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.ID == articleUpdateDTO.ID, x => x.Category, i => i.Image); //Yukarıdaki metoda benzerdir.

            //önce eskiyi resim varsa silme işlemi yapar kaydederiz
           

            if (articleUpdateDTO.Photo != null)
            {
                _imageHelper.DeleteImage(article.Image.FileName);// Article sınıfının içinde Image türünde Image probuyla Image entitisinden bağlantı alırız ve oradaki FileName i çekebiliriz Article içinden. Burada eğer resim varsa önce sil dedik

                var imageUpload = await _imageHelper.Upload(articleUpdateDTO.Title, articleUpdateDTO.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDTO.Photo.ContentType, userEmail);

                articleUpdateDTO.ImageFileName = image.FileName; //***********İNCELE ***UPDATEVIEW DA RESİM KAYDETME YERİNDE SRC YE YAZDIK

                await _unitOfWork.GetRepository<Image>().AddAsync(image); //burada da update yapılır.
                await _unitOfWork.SaveAsync();

                article.ImageId = image.ID; //burada da yeni seçilen resmi eşitlemiş olduk 

            }


            //---------------------------------------------------------------------------------------

            //aşağıda da yeni değerli kaydederiz.

            //Buralarda manuel mapper yapmak zorunda kaldık bu da bir yoldur. tek tek updatedto daki değerleri Article entitisimize eşleriz Database ye kullanıcıdan gelen değişiklikleri ataması için.  
            article.Title = articleUpdateDTO.Title;
            article.Content = articleUpdateDTO.Content;
            article.CategoryId = articleUpdateDTO.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail; //ModifiedBy kısmında giriş yapanın Emil adresi yazacaktır.       

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article); //burada da update yapılır.

            await _unitOfWork.SaveAsync();
            return article.Title;

        }







        public async Task SafeDeleteArticleAsync(int Id) //Tamamen silmeden Silmiş gibi işlem yaptırırız.
        {
            var userEmail = _user.GetLoggedInEmail();//artık makaleleri kimin sildiğini Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir DeletedBy kısmına.BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.



            var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(Id); //sadece repositorydeki GetByIdAsync metoduyla silme işlemi yapabiliriz.

            article.IsDeleted = true; //IsDeleted true olduğu için biz article çağırdığımızda yukarılarda yaptığımız metotlarda !isDeleted ları almıştık dolayısıyla onlar gelmeyecek. BaseEntity de isDeletd=false tanımlıdır normalde.
            article.DeletedDate = DateTime.Now;
            article.DeletedBy=userEmail; //DeletedBy kısmında giriş yapanın Emil adresi yazacaktır. 


            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }


    }
}
