using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.AutoMapper.CategoryMapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap(); //***Hem CategoryDTO dan Category a, hem de Category dan CategoryDTO ya map leme işlemi yapıldı. (ReverseMap() ters yönden map leme sağlar. Yani içerikleri birbirleri arasında aktarır. Data Transfer Object (DTO)).
            CreateMap<CategoryAddDTO,Category>().ReverseMap(); //***Hem CategoryAddDTO dan Category a, hem de Category dan CategoryAddDTO ya map leme işlemi yapıldı. (ReverseMap() ters yönden map leme sağlar. Yani içerikleri birbirleri arasında aktarır. Data Transfer Object (DTO)).
            CreateMap<CategoryUpdateDTO,Category>().ReverseMap(); //***Hem CategoryUpdateDTO dan Category a, hem de Category dan CategoryUpdateDTO ya map leme işlemi yapıldı. (ReverseMap() ters yönden map leme sağlar. Yani içerikleri birbirleri arasında aktarır. Data Transfer Object (DTO)).
        }
    }
}
