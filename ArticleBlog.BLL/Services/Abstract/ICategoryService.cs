using ArticleBlog.Entitiy.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Abstract
{//Burada aslında Interface ve Normal abstract sınıfında bu metotları yapınca Dependency Injection yapmış oluyoruz birnevi.
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesNonDeleted();
    }
}
