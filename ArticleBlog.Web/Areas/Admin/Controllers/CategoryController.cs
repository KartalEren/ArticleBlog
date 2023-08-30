using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //tüm listeleri geri getirir.
            return View(categories);

        }

        [HttpGet]
        public IActionResult Add() //makale ekleme get kısmı
        {
            return View();
        }
    }
}
