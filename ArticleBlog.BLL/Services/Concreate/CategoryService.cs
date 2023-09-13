using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper mapper; 
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly ClaimsPrincipal _user;


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor ) 
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeleted()
        {
            var categories = await  _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); 
            return map; 
        }



        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//



        public async Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            
            var userEmail = _user.GetLoggedInEmail(); 
            Category category = new(categoryAddDTO.CategoryName,userEmail);

            await _unitOfWork.GetRepository<Category>().AddAsync(category);

            await _unitOfWork.SaveAsync();
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//


        public async Task<Category> GetCategoryById(int id) 
        {
            var category=await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            return category;
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//


        public async Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO) 
        {

            var userEmail = _user.GetLoggedInEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => x.IsDeleted == false && x.ID == categoryUpdateDTO.Id); 


           
            category.CategoryName = categoryUpdateDTO.CategoryName;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;


            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);

            await _unitOfWork.SaveAsync();

           return category.CategoryName;
        }





        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//


        public async Task<string> SafeDeleteCategoryAsync(int id) 
        {
            var userEmail = _user.GetLoggedInEmail();



            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id); 

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail; 


            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.CategoryName;
        }







        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task<List<CategoryDTO>> GetAllCategoriesDeleted() 
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); 
            return map; 
        }

        public async Task<string> UndoDeleteCategoryAsync(int id) 
        {
            var userEmail = _user.GetLoggedInEmail();



            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id); 

            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;


            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.CategoryName;
        }


        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//



        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeletedTake24()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); 

            var takeCategories = map.Take(24).ToList();
            return takeCategories; 
        }


        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//

    }


}



