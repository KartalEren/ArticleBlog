using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.DTOs.Authors;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Web.Consts;
using ArticleBlog.Web.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArticleBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService; //autor detaylarına ulaşmak için bu servisteki metoda ulaşmak için oluşturduk bu field ı
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService,ICategoryService categoryService , IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IUserService userService, IMapper mapper, IValidator<Article> validator)
        {
            _logger = logger;
            this._articleService = articleService;
            this._categoryService = categoryService;
            this._httpContextAccessor = httpContextAccessor;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._mapper = mapper;
            this._validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int categoryId,int currentPage=1,int pageSize=3,bool isAscending=false)
        {


            var articles= await _articleService.GetAllByPagingAsync(categoryId,currentPage,pageSize);// _articleService içinde oluşturduğumuz ilk açılış sayfasında çıkacakları belirlediğimiz Pagination metodudur.

            return View(articles);


            //var articles=await _articleService.GetAllArticlesWithCategoryNoneDeletedAsync(); //IArticleService içinde oluşturulan GetAllArticlesAsync ve Unit Of Work yapısı ile Repositorydeki GetAllAsync (tüm listeyi çağırmak için) metodunu bağladığımız için GetAllArticlesAsync metodu yeterlidir.
            //return View(articles);
        }


        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles); // SearchAsync() Ana sayfada makaleler listelenirken keyword e göreSerach ile arama işlemi için bu metot yapıldı.
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Detail(int id) //Read More yapınc makale detaylarını getirmek için oluşturuldu.
        {

            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); //View sayısını artırmak için yeni giriş yapan kullanıcının IP Adresini alırız.
            var articeVisitors = await _unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article); //burada çoka çok ilişki olan visitor ve aticle ile include derek bilgileri aldım.
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.ID == id); // _unitOfWork ile jenerik GetRepository<Article>() metodunu kullanarak IRepository de kullandığım GetAsync(x => x.ID == id); metodu ile id ler ile article çektim.


            var result = await _articleService.GetArticleWithCategoryNonDeletedAsync(id); //Tek bir değer Article kategorileriyle birlikte silinmemiş olanları ve id lere göre eşleyerek getirecek döndürecek.

            var visitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress); // _unitOfWork teki GetRepository metodu ile Visitor sınıfıma ve IRepositorydeki GetAsync(x => x.IpAddress == ipAddress); metodumla IP Adresine göre eşleşenlen visitor ı çağırabiliyorum.

            var addArticleVisitors = new ArticleVisitor(article.ID, visitor.ID); //hem article hem visitor ları ayrı ayrı id lere göre bulup ekleme işlemi yapacağım.

            if (articeVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId))//articeVisitors'da hiç bu değerler eşleşiyor mu?(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId) diye sorarız. Eğer aynıları var sa ekleme işlemi yapma retrun View(result); dön deriz.
                return View(result); 
            else //aynıları yok ise
            {
                await _unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors); //önce article visitorumu eklemem gerek ArticleVisitor tabloma.
                article.ViewCount += 1; //görüntümü bu şekilde yeni bir kullanıcı olduğu için 1 artır dedik.
                await _unitOfWork.GetRepository<Article>().UpdateAsync(article); //ViewCount arttığı için bu işlemi Article daki ViewCount propbu için kaydetmem gerek.
                await _unitOfWork.SaveAsync(); //son olarak da her şeyi tablolarıma update ederim.
            }

            return View(result);





        }
        public  IActionResult About()
        {
            return View();
        }


        public async Task<IActionResult>  AuthorDetails(int id)
        {
            var author=await _userService.GetAppUserByIdAsync(id); //yazarı çektik id ye göre
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.ID == id); //bu id ye ait artice ları çektik.
            var map=_mapper.Map<AuthorDetailDTO>(author); //article ı AuthorDetailDTO ya mapledik
            map.Articles = articles; //bunu tabloya kaydettik

            return View(map);
        }


        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleAddDTO articleAddDTO) //Post da ekleme yapacağımız yer kullanıcıya gösteriğimiz DTO olduğu için o parametreleri veririz.
        {
            //ArticleAddDTO dan Article a çevirelemeyeceği için mapper işlemi yaparız
            var map = _mapper.Map<Article>(articleAddDTO); //önce tabloları maple.//***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.
            var result = await _validator.ValidateAsync(map);//sonra map sonucuna göre hata mesajı ver veya verme


            if (result.IsValid) //olumluysa işlemi yap
            {
                await _articleService.CreateArticleAsync(articleAddDTO);
                return RedirectToAction("Index", "Home", new { Area = " " }); //işlem başarılıysa ana sayfaya gönderir.               
            }
            else//olumsuzsa FluentValidationdaki AddToModelState metodundaki hatayı dön
            {
                result.AddToModelState(this.ModelState); //işlem başarısızsa gerçekleşecek durumdur. Bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });

        }


    }
}