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
    public class ArticleProfile: Profile //Auto Mapper yapısı için bu katmanda AutoMapper ve AutoMapper DependencyInjection Nugetlarını indirip kurduk. Ve Profile den kalıtım verdik.
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO,Article>().ReverseMap(); //***Hem ArticleDTO dan Article a, hem de Article dan ArticleDTO ya map leme işlemi yapıldı. (ReverseMap() ters yönden map leme sağlar. Yani içerikleri birbirleri arasında aktarır. Data Transfer Object (DTO)).
        }
    }
}
