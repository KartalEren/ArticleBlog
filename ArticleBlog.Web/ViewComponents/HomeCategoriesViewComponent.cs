using ArticleBlog.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.ViewComponents
{
    public class HomeCategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var categories =await _categoryService.GetAllCategoriesNonDeletedTake24();
            return View(categories);
        }

    }
}
