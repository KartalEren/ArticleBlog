using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{//Not: Repository lere direkt ulaşmamak için Unit Of Work yapısı oluşturmuştuk, o yapı üzerinde jeneri olarak  IRepository<T> IUnitOfWork.GetRepository<T>() metoduyla repository lere ulaşabilecektirk. Burada da aynı şekilde direkt Repositorylere ulaşmamak için Unit Of Work den ctor da eşleme yaparız.
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        public async Task<List<Article>> GetAllArticlesAsync() //Liste türünde Article döndürecek.
        {
            return await _unitOfWork.GetRepository<Article>().GetAllAsync();//***Burada IUnitOfWork ü ctor da eşleyerek, IUnitOfWork da oluşturduğumuz GetRepository<> metoduyla jenerik olarak yaptığımız için Article yazarak Article sınıfı için tüm repository metodlarına return await _unitOfWork.GetRepository<Article>(). yaptıktan sonra ulaşmış oluyoruz. İşin kolaylığı burada....
        }

        
    }
}
