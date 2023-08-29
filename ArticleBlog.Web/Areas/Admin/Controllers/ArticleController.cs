using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.Entitiy.DTOs.Articles;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            this._articleService = articleService;
            this._categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var article = await _articleService.GetAllArticlesWithCategoryNoneDeletedAsync();
            return View(article);
        }


        [HttpGet] //ilk ekran get ekranı olacak yani formu görp içine neler girebiliriz onu göreceğiz.
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });
        }


        [HttpPost] //ilk ekran get ekranı olacak yani formu görp içine neler girebiliriz onu göreceğiz.
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO) //Post da ekleme yapacağımız yer kullanıcıya gösteriğimiz DTO olduğu için o parametreleri veririz.
        {

            await _articleService.CreateArticleAsync(articleAddDTO);
            return RedirectToAction("Index", "Article", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir.

            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });
        }
    }
}