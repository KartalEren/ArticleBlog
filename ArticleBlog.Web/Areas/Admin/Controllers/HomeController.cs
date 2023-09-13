using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
    [Area("Admin")] 
    [Authorize]
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
