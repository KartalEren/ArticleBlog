using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.DTOs.Authors;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Web.Consts;
using ArticleBlog.Web.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArticleBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService; 
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService,ICategoryService categoryService , IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IUserService userService, IMapper mapper, IValidator<Article> validator)
        {
            _logger = logger;
            this._articleService = articleService;
            this._categoryService = categoryService;
            this._httpContextAccessor = httpContextAccessor;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._mapper = mapper;
            this._validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int categoryId,int currentPage=1,int pageSize=3,bool isAscending=false)
        {


            var articles= await _articleService.GetAllByPagingAsync(categoryId,currentPage,pageSize);

            return View(articles);
            
        }


        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles); 
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Detail(int id) 
        {

            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); 
            var articeVisitors = await _unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article); 
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.ID == id);


            var result = await _articleService.GetArticleWithCategoryNonDeletedAsync(id); 

            var visitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress); 

            var addArticleVisitors = new ArticleVisitor(article.ID, visitor.ID); 

            if (articeVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId))
                return View(result); 
            else 
            {
                await _unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors); 
                article.ViewCount += 1; 
                await _unitOfWork.GetRepository<Article>().UpdateAsync(article); 
                await _unitOfWork.SaveAsync(); 
            }

            return View(result);





        }
        public  IActionResult About()
        {
            return View();
        }


        public async Task<IActionResult>  AuthorDetails(int id)
        {
            var author=await _userService.GetAppUserByIdAsync(id); 
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.ID == id);
            var map=_mapper.Map<AuthorDetailDTO>(author);
            map.Articles = articles; 

            return View(map);
        }


        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 
            return View(new ArticleAddDTO { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleAddDTO articleAddDTO) 
        {
           
            var map = _mapper.Map<Article>(articleAddDTO); 
            var result = await _validator.ValidateAsync(map);


            if (result.IsValid) 
            {
                await _articleService.CreateArticleAsync(articleAddDTO);
                return RedirectToAction("Index", "Home", new { Area = " " });                
            }
            else
            {
                result.AddToModelState(this.ModelState);

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 
            return View(new ArticleAddDTO { Categories = categories });

        }


    }
}