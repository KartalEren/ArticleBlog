using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService; 
        private readonly IValidator<Category> _validator; 
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._validator = validator;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted(); 
            return View(categories);

        }



        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> DeletedCategory() 
        {
            var categories = await _categoryService.GetAllCategoriesDeleted(); 
            return View(categories);

        }



        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")] 
        public IActionResult Add() 
        {
            return View();
        }



        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO) 
        {
            var map = _mapper.Map<Category>(categoryAddDTO); 

            var result = await _validator.ValidateAsync(map); 

            if (result.IsValid) 
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTO);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });              
            }
            else
            {
                result.AddToModelState(this.ModelState); 

                return View(categoryAddDTO);
            }
        }


        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDTO categoryAddDTO)
        {
            var map = _mapper.Map<Category>(categoryAddDTO);

            var result = await _validator.ValidateAsync(map);

            if (result.IsValid) 
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTO);

                string categoryName = categoryAddDTO.CategoryName;
                return Json(categoryName);

            }
            else
            {
                return Json(result.Errors.First().ErrorMessage); 
            }
        }







        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> Update(int Id) 
        {
            var category=await _categoryService.GetCategoryById(Id);

            var map=_mapper.Map<Category,CategoryUpdateDTO>(category); 

            return View(map); 
        }





        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO) 
        {
            

            var map = _mapper.Map<Category>(categoryUpdateDTO); 

            var result = await _validator.ValidateAsync(map);


            if (result.IsValid) 
            {
                await _categoryService.UpdateCategoryAsync(categoryUpdateDTO);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });  

            }
            else
            {
                result.AddToModelState(this.ModelState);

                return View();
            }
            
        }



        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _categoryService.SafeDeleteCategoryAsync(Id);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }



        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> UndoDelete(int Id)
        {
            await _categoryService.UndoDeleteCategoryAsync(Id);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


    }
}



