using ArticleBlog.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")] //Bunu yazarak diyoruz ki... Ben Area içindeki Home Controller olarak çalışacağım diyorum.
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles= await articleService.GetAllArticlesAsync();
            return View(articles);
        }
    }
}
