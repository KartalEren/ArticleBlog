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



        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//



        public async Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            
            var userEmail = _user.GetLoggedInEmail(); //artık makaleleri kimin yarattığını Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir CreatedBy kısmına. BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.

            Category category = new(categoryAddDTO.CategoryName,userEmail);//buradan gelen name i category clasına ekleriz ve kimin işlem yaptığını ategory clasındaki parametreli oluşturduğumuz ctor u ekleriz ve ondan daolyı oradaki Created By kısmına userEmail i koyarız ki işlemi yapanı bulalım.

            await _unitOfWork.GetRepository<Category>().AddAsync(category);

            await _unitOfWork.SaveAsync();
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//


        public async Task<Category> GetCategoryById(int id) //id ye göre kategori güncelleme işlemi yapılır.
        {
            var category=await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            return category;
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//


        public async Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO) //güncellemem işleminin yapıldığı metottur. String olarak yazarız çünkü makale başlığını göreceğiz.
        {

            var userEmail = _user.GetLoggedInEmail();//artık makaleleri kimin güncellediiğni Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir ModifiedBy kısmına.BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => x.IsDeleted == false && x.ID == categoryUpdateDTO.Id); //delete olmayan ve id sine göre olanları çağırırız.


            //alt kısımda verileri dtodan güncellenerek  gelen verileri normal category class ına eşlemiş olduk
            category.CategoryName = categoryUpdateDTO.CategoryName;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;


            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);

            await _unitOfWork.SaveAsync();

           return category.CategoryName;
        }





        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//


        public async Task<string> SafeDeleteCategoryAsync(int id)  //string vir başlık döneriz ve Tamamen silmeden Silmiş gibi işlem yaptırırız..
        {
            var userEmail = _user.GetLoggedInEmail();//artık makaleleri kimin sildiğini Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir DeletedBy kısmına.BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.



            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id); //sadece repositorydeki GetByIdAsync metoduyla silme işlemi yapabiliriz.

            category.IsDeleted = true; //IsDeleted true olduğu için biz article çağırdığımızda yukarılarda yaptığımız metotlarda !isDeleted ları almıştık dolayısıyla onlar gelmeyecek. BaseEntity de isDeletd=false tanımlıdır normalde.
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail; //DeletedBy kısmında giriş yapanın Emil adresi yazacaktır. 


            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.CategoryName;
        }







        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task<List<CategoryDTO>> GetAllCategoriesDeleted() //tüm silinen category leri listeler
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); //Burada map işlemini hemen DTO su ile yapmış oluruz.
            return map; //Kategorileri dönen servistir.
        }

        public async Task<string> UndoDeleteCategoryAsync(int id) //silinmiş categoryleri geri döndürür.
        {
            var userEmail = _user.GetLoggedInEmail();//artık makaleleri kimin sildiğini Email le giriş yapıldığı için direkt düzenleyenin Emaili gelir DeletedBy kısmına.BLL-Extension-LoggedInUserExtensions deki ifadelerden gelir burası.



            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id); //sadece repositorydeki GetByIdAsync metoduyla silme işlemi yapabiliriz.

            category.IsDeleted = false; //IsDeleted false olduğu için biz article çağırdığımızda yukarılarda yaptığımız metotlarda isDeleted=true ları almıştık dolayısıyla onlar gelmeyecek. BaseEntity de isDeletd=true tanımlıdır normalde.
            category.DeletedDate = null;
            category.DeletedBy = null; //DeletedBy kısmında giriş yapanın Emil adresi yazacaktır. 


            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.CategoryName;
        }


        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//



        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeletedTake24()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories); //Burada map işlemini hemen DTO su ile yapmış oluruz.

            var takeCategories = map.Take(24).ToList();
            return takeCategories; //24 tane kategori çekeriz
        }


        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//

    }


}



