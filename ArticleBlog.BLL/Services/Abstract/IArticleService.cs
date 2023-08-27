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
        Task<List<Article>> GetAllArticlesAsync();//Sadece article a ait olduğu içinjenerik yapmaya gerek yoktur.
    }
}
