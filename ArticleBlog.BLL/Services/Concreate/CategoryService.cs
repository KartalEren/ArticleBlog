using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{//Burada aslında Interface ve Normal abstract sınıfında bu metotları yapınca Dependency Injection yapmış oluyoruz birnevi.
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork; //Repolara ulaşmak için burada new leriz.
        private readonly IMapper mapper; //Liste türünde metotlarda Mapleme yapmak için burada new leriz.

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeleted()
        {
            var categories = await  _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); //Burada map işlemini hemen DTO su ile yapmış oluruz.
            return map; //Kategorileri dönen servistir.
        }
    }




}



