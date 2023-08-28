using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
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
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNoneDeletedAsync() //Liste türünde Article ları kategorileriyle birlikte silinmemiş olanları döndürecek.
        {
            
            var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>x.IsDeleted==false, x=>x.Category);//***Burada IUnitOfWork ü ctor da eşleyerek, IUnitOfWork da oluşturduğumuz GetRepository<> metoduyla jenerik olarak yaptığımız için Article yazarak ArticleDTO sınıfı için tüm repository metodlarına return await _unitOfWork.GetRepository<Article>(). yaptıktan sonra ulaşmış oluyoruz. Ayrıca kategor,ye göre silinmemiş olanları GetAllAsync(x=>x.IsDeleted==false,x=>x.Category) metoduyla getirir articleları İşin kolaylığı burada....

            var map = mapper.Map<List<ArticleDTO>>(articles); //Burada DTO oluşturduğumuz ArticleDTO classının maplemek için yaparız ve deriz ki; buradaki dto da oluşturulan proplara göre listeleri getir demek isteriz. Yani göstermek istediğimiz propları index te veya herhangi cshtml de biz seçeriz böylece tüm propları kişilere güvenlik açısından açmamış oluruz. List türünde olmalıdır çünkü metot bir liste döndürür. Article Listesi döner.

            return map; //burada da Map leme işlemi yaptığımız map değişkenini döndürürüz ve böylece liste dönmüş olur.
        }


    }
}
