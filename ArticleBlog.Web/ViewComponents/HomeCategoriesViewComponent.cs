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

        public async Task<IViewComponentResult> InvokeAsync() //Burada view component oluştrduk _Layoutta bunu yazabilmek için temiz görünsün diye Partial View mantığı gibi
        {
            var categories =await _categoryService.GetAllCategoriesNonDeletedTake24();
            return View(categories);
        }

    }
}
