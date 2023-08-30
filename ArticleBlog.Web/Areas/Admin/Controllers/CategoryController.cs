using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService; //category metotlara ulaşabilmek için çağırdık
        private readonly IValidator<Category> _validator; //fluent validation ları kullanabilmek için çağırdık.
        private readonly IMapper _mapper;//mapping işlemi için çağırdık

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._validator = validator;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //tüm listeleri geri getirir.
            return View(categories);

        }




        public async Task<IActionResult> DeletedCategory() //Silinmiş kategorileri listeler
        {
            var categories = await _categoryService.GetAllCategoriesDeleted(); //tüm listeleri geri getirir.
            return View(categories);

        }




        [HttpGet]
        public IActionResult Add() //makale ekleme get kısmı
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO) //makale ekleme get kısmı
        {
            var map = _mapper.Map<Category>(categoryAddDTO); //önce tabloları maple.//***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            var result = await _validator.ValidateAsync(map); //sonra map sonucuna göre hata mesajı ver veya verme

            if (result.IsValid) //olumluysa işlemi yap
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTO);
                return RedirectToAction("Index", "Category", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir.               
            }
            else//olumsuzsa FluentValidationdaki AddToModelState metodundaki hatayı dön
            {
                result.AddToModelState(this.ModelState); //işlem başarısızsa gerçekleşecek durumdur. bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 

                return View(categoryAddDTO);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDTO categoryAddDTO)
        {
            var map = _mapper.Map<Category>(categoryAddDTO); //önce tabloları maple.//***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            var result = await _validator.ValidateAsync(map); //sonra map sonucuna göre hata mesajı ver veya verme

            if (result.IsValid) //olumluysa işlemi yap
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTO);

                string categoryName = categoryAddDTO.CategoryName;
                return Json(categoryName);

            }
            else
            {
                return Json(result.Errors.First().ErrorMessage); //olumsuzsa
            }
        }







        [HttpGet]
        public async Task<IActionResult> Update(int Id) //makale ekleme get kısmı
        {
            var category=await _categoryService.GetCategoryById(Id);

            var map=_mapper.Map<Category,CategoryUpdateDTO>(category); //mapleyerek kullanıcıdan gelen bilgileri tablolar arasında aktarmış olduk yani Category new leyerek yeni bilgileri tek tek yazmaya gerek kalmadı.***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            return View(map); //kullanıcının girdiği değerleri eşler ve güncellenecek bilgileri update ekranına getirir
        }





        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO) //makale ekleme get kısmı
        {
            

            var map = _mapper.Map<Category>(categoryUpdateDTO); //mapleyerek kullanıcıdan gelen bilgileri tablolar arasında aktarmış olduk yani Category new leyerek yeni bilgileri tek tek yazmaya gerek kalmadı.***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            var result = await _validator.ValidateAsync(map); //sonra map sonucuna göre hata mesajı ver veya verme


            if (result.IsValid) //olumluysa işlemi yap
            {
                await _categoryService.UpdateCategoryAsync(categoryUpdateDTO);
                return RedirectToAction("Index", "Category", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir.  

            }
            else//olumsuzsa FluentValidationdaki AddToModelState metodundaki hatayı dön
            {
                result.AddToModelState(this.ModelState); //işlem başarısızsa gerçekleşecek durumdur. bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 

                return View();
            }
            
        }




        public async Task<IActionResult> Delete(int Id)
        {
            await _categoryService.SafeDeleteCategoryAsync(Id);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }




        public async Task<IActionResult> UndoDelete(int Id)//Silinmiş kategorileri geri yükler
        {
            await _categoryService.UndoDeleteCategoryAsync(Id);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


    }
}



