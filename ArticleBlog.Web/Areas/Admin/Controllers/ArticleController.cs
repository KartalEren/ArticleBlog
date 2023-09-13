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
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService; 
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)
        {
            this._articleService = articleService;
            this._categoryService = categoryService;
            this._mapper = mapper;
            this._validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var article = await _articleService.GetAllArticlesWithCategoryNoneDeletedAsync();
            return View(article);
        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedArticle() 
        {
            var article = await _articleService.GetAllArticlesWithCategoryDeleted();
            return View(article);
        }




        [HttpGet] 
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] 
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 
            return View(new ArticleAddDTO { Categories = categories });
        }


        [HttpPost] 
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] 
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO) 
        {
           
            var map = _mapper.Map<Article>(articleAddDTO); 
            var result = await _validator.ValidateAsync(map);


            if (result.IsValid)
            {
                await _articleService.CreateArticleAsync(articleAddDTO);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });             
            }
            else
            {
                result.AddToModelState(this.ModelState);

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 
            return View(new ArticleAddDTO { Categories = categories });

        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] 
        public async Task<IActionResult> Update(int Id)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(Id); 
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 


            var articleUpdateDTO = _mapper.Map<ArticleUpdateDTO>(article); 
            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);
        }
      

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] 
        public async Task<IActionResult> Update(ArticleUpdateDTO articleUpdateDTO)
        {

            var map = _mapper.Map<Article>(articleUpdateDTO);
            var result=await _validator.ValidateAsync(map);


            if (result.IsValid) 
            {
                await _articleService.UpdateArticleAsync(articleUpdateDTO);
            }
            else
            {
                result.AddToModelState(this.ModelState);  
            }


            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 

            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);



        }




        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] 
        public async Task<IActionResult> Delete(int Id)
        {
             await _articleService.SafeDeleteArticleAsync(Id);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }



        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")] 
        public async Task<IActionResult> UndoDelete(int Id) 
        {
            await _articleService.UndoDeleteArticleAsync(Id);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}