using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;//article metotlara ulaşabilmek için çağırdık
        private readonly ICategoryService _categoryService; //article metotlara ulaşabilmek için çağırdık
        private readonly IMapper _mapper;//mapping işlemi için çağırdık
        private readonly IValidator<Article> _validator;//fluent validation ları kullanabilmek için çağırdık.

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)
        {
            this._articleService = articleService;
            this._categoryService = categoryService;
            this._mapper = mapper;
            this._validator = validator;
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
            //ArticleAddDTO dan Article a çevirelemeyeceği için mapper işlemi yaparız
            var map = _mapper.Map<Article>(articleAddDTO); //önce tabloları maple.//***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.
            var result = await _validator.ValidateAsync(map);//sonra map sonucuna göre hata mesajı ver veya verme


            if (result.IsValid) //olumluysa işlemi yap
            {
                await _articleService.CreateArticleAsync(articleAddDTO);
                return RedirectToAction("Index", "Article", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir.               
            }
            else//olumsuzsa FluentValidationdaki AddToModelState metodundaki hatayı dön
            {
                result.AddToModelState(this.ModelState); //işlem başarısızsa gerçekleşecek durumdur.
               
            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });

        }


        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(Id); //1 adet article güncellemek için yapıldı.
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Article a ait silinmemiş olan tüm kategorileri güncellemek için yapıldı.


            var articleUpdateDTO = _mapper.Map<ArticleUpdateDTO>(article); //Farklı servisten 
            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);
        }
        //var map = _mapper.Map<Article>(articleAddDTO);
        //var result = await _validator.ValidateAsync(map);

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDTO articleUpdateDTO)
        {

            var map = _mapper.Map<Article>(articleUpdateDTO);//önce tabloları maple.//***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.
            var result=await _validator.ValidateAsync(map);//sonra map sonucuna göre hata mesajı ver veya verme


            if (result.IsValid) //olumluysa işlemi yap
            {
                await _articleService.UpdateArticleAsync(articleUpdateDTO);
            }
            else//olumsuzsa FluentValidationdaki AddToModelState metodundaki hatayı dön
            {
                result.AddToModelState(this.ModelState);
            }


            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Article a ait silinmemiş olan tüm kategorileri güncellemek için yapıldı.

            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);



        }





        public async Task<IActionResult> Delete(int Id)
        {
            await _articleService.SafeDeleteArticleAsync(Id);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}