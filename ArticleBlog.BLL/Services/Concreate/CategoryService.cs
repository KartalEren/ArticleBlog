using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
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
{//Burada aslında Interface ve Normal abstract sınıfında bu metotları yapınca Dependency Injection yapmış oluyoruz birnevi.
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork; //Repolara ulaşmak için burada new leriz.
        private readonly IMapper mapper; //Liste türünde metotlarda Mapleme yapmak için burada new leriz.
        private readonly IHttpContextAccessor _httpContextAccessor; //BLL-Extension-LoggedInUserExtensions deki ifadeleri görmesi için buraya servis ekledik. HttpContextAccessor ile kullanıcıyı bulmamızı sağlayan yapıdır.
        private readonly ClaimsPrincipal _user;//Bir üstteki _httpContextAccessor tanımlamak yerine kısa metotlarda olması adına _user şeklinde yapar ctor içine atarız ve _user ı kullanırız artık


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor ) 
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;//burada eşleme işlemi aşağılarda uzun uzun olmaması adına _user a işlem yapan yapıyı eşitledik.
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeleted()
        {
            var categories = await  _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); //Burada map işlemini hemen DTO su ile yapmış oluruz.
            return map; //Kategorileri dönen servistir.
        }


        public async Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            
            var userEmail = _user.GetLoggedInEmail(); //artık makaleleri kimin yarattığını Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir CreatedBy kısmına. BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.

            Category category = new(categoryAddDTO.CategoryName,userEmail);//buradan gelen name i category clasına ekleriz ve kimin işlem yaptığını ategory clasındaki parametreli oluşturduğumuz ctor u ekleriz ve ondan daolyı oradaki Created By kısmına userEmail i koyarız ki işlemi yapanı bulalım.

            await _unitOfWork.GetRepository<Category>().AddAsync(category);

            await _unitOfWork.SaveAsync();
        }



    }

   




}



