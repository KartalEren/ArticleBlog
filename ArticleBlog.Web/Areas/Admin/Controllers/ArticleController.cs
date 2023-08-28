using ArticleBlog.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            this._articleService = articleService;
        }


        public async Task<IActionResult>  Index()
        {
            var article =await _articleService.GetAllArticlesWithCategoryNoneDeletedAsync();
            return View(article);
        }
    }
}
