using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArticleBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._articleService = articleService;
            this._httpContextAccessor = httpContextAccessor;
            this._unitOfWork = unitOfWork;
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



    }
}