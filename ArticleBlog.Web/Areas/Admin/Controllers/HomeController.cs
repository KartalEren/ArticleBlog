using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")] //Bunu yazarak diyoruz ki... Ben Area içindeki Home Controller olarak çalışacağım diyorum.
    [Authorize]//Login için bunu bu controller da zorunlu tuttuk. Admine giriş için yapıldı aslında
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
       

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
           
        }

        public async Task<IActionResult> Index()
        {
            var articles= await articleService.GetAllArticlesWithCategoryNoneDeletedAsync();
            

            return View(articles);
        }
    }
}
