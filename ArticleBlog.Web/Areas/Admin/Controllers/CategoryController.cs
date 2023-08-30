﻿using ArticleBlog.BLL.Services.Abstract;
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

        [HttpGet]
        public IActionResult Add() //makale ekleme get kısmı
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO) //makale ekleme get kısmı
        {
            var map = _mapper.Map<Category>(categoryAddDTO); //önce tabloları maple

            var result = await _validator.ValidateAsync(map); //sonra map sonucuna göre hata mesajı ver veya verme

            if (result.IsValid) //olumluysa işlemi yap
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTO);
                return RedirectToAction("Index", "Category", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir.               
            }
            else//olumsuzsa FluentValidationdaki AddToModelState metodundaki hatayı dön
            {
                result.AddToModelState(this.ModelState); //işlem başarısızsa gerçekleşecek durumdur.

                return View();
            }
        }
    }
}



