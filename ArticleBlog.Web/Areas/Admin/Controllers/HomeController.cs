using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]//***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
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
