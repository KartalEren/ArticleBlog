using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Abstract
{//Burada aslında Interface ve Normal abstract sınıfında bu metotları yapınca Dependency Injection yapmış oluyoruz birnevi.
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesNonDeleted(); // tüm category leri listeler

        Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO);  //Yeni bir category eklemek için kullanıcıya gösterdiğimiz DTO lar ile kullanıcılardan alınan bilgilere göre category ekler.

        Task<Category> GetCategoryById(int id); //id ye göre kategori güncelleme işlemi yapılır.
        Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO); //güncellemem işleminin yapıldığı metottur. String olarak yazarız çünkü makale başlığını göreceğiz.
        Task<string> SafeDeleteCategoryAsync(int id); //string vir başlık döneriz ve Tamamen silmeden Silmiş gibi işlem yaptırırız..
    }
}
