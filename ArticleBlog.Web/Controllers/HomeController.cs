using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArticleBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            this._articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles=await _articleService.GetAllArticlesWithCategoryNoneDeletedAsync(); //IArticleService içinde oluşturulan GetAllArticlesAsync ve Unit Of Work yapısı ile Repositorydeki GetAllAsync (tüm listeyi çağırmak için) metodunu bağladığımız için GetAllArticlesAsync metodu yeterlidir.
            return View(articles);
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
    }
}