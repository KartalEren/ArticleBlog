using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.AutoMapper.ArticleMapper
{

    //NOT:******Controllerda var map=... gibi ifade yapabilmek için buraya auto map yaparız.
    public class ArticleProfile: Profile //Auto Mapper yapısı için bu katmanda AutoMapper ve AutoMapper DependencyInjection Nugetlarını indirip kurduk. Ve Profile den kalıtım verdik.
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO,Article>().ReverseMap(); //***Hem ArticleDTO dan Article a, hem de Article dan ArticleDTO ya map leme işlemi yapıldı. (ReverseMap() ters yönden map leme sağlar. Yani içerikleri birbirleri arasında aktarır. Data Transfer Object (DTO)).


            CreateMap<ArticleUpdateDTO, Article>().ReverseMap();// Hem article ve articleupdatedto alışverişi olur.
            CreateMap<ArticleUpdateDTO, ArticleDTO>().ReverseMap(); //***Hem de ArticleUpdateDTO ve ArticleDTO arasında alışveriş olur. Çünkü biz artık DTO lar üzerinden de işlemler yapıyoruz.

            CreateMap<ArticleAddDTO, Article>().ReverseMap(); //***Hem de ArticleAddDTO ve Article arasında alışveriş olur. Çünkü biz ArticleControlerda Add işlemi yapaken artık Article ve ArticleAddDTO üzerinden de işlemler yapıyoruz.


        }
    }
}
