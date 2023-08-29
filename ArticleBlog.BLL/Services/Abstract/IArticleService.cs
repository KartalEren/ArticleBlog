using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryNoneDeletedAsync();//Sadece article a ait olduğu içinjenerik yapmaya gerek yoktur.
        Task CreateArticleAsync(ArticleAddDTO articleAddDTO); //Yeni bir article eklemek için kullanıcıya gösterdiğimiz DTO lar ile kullanıcılardan alınan bilgilere göre yeni makale ekler.
    }
}
