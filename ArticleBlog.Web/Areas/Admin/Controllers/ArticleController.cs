using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Web.Consts;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}, {RoleConsts.User}")]//***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Index()
        {
            var article = await _articleService.GetAllArticlesWithCategoryNoneDeletedAsync();
            return View(article);
        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> DeletedArticle() //Silinmiş article ları geri listeler
        {
            var article = await _articleService.GetAllArticlesWithCategoryDeleted();
            return View(article);
        }




        [HttpGet] //ilk ekran get ekranı olacak yani formu görp içine neler girebiliriz onu göreceğiz.
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });
        }


        [HttpPost] //ilk ekran get ekranı olacak yani formu görp içine neler girebiliriz onu göreceğiz.
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
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
                result.AddToModelState(this.ModelState); //işlem başarısızsa gerçekleşecek durumdur. Bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Kategorisi silinmemiş olan tüm article ları getir dedik.
            return View(new ArticleAddDTO { Categories = categories });

        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
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
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
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
                result.AddToModelState(this.ModelState); //bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 
            }


            var categories = await _categoryService.GetAllCategoriesNonDeleted(); //Article a ait silinmemiş olan tüm kategorileri güncellemek için yapıldı.

            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);



        }




        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Delete(int Id)//Makaleleri tamamen silmeden silinmiş gösterir.
        {
             await _articleService.SafeDeleteArticleAsync(Id);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }



        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> UndoDelete(int Id) //Silinen makaleleri geri yükler.
        {
            await _articleService.UndoDeleteArticleAsync(Id);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}