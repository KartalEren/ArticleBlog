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


   
    public class ArticleProfile: Profile 
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO,Article>().ReverseMap(); 


            CreateMap<ArticleUpdateDTO, Article>().ReverseMap();
            CreateMap<ArticleUpdateDTO, ArticleDTO>().ReverseMap(); 

            CreateMap<ArticleAddDTO, Article>().ReverseMap();


        }
    }
}
