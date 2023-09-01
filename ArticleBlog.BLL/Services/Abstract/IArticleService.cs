using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Abstract
{       //Burada aslında Interface ve Normal abstract sınıfında bu metotları yapınca Dependency Injection yapmış oluyoruz birnevi.
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryNoneDeletedAsync();//Sadece article a ait olduğu içinjenerik yapmaya gerek yoktur.
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryDeleted();//Silinmiş makaleleri listeler.
        Task CreateArticleAsync(ArticleAddDTO articleAddDTO); //Yeni bir article eklemek için kullanıcıya gösterdiğimiz DTO lar ile kullanıcılardan alınan bilgilere göre yeni makale ekler.
        Task<ArticleDTO> GetArticleWithCategoryNonDeletedAsync(int Id); //Tek bir değer Article kategorileriyle birlikte silinmemiş olanları ve id lere göre eşleyerek getirecek döndürecek.

        Task<string> UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO); //Article ın Update metodudur.


        Task SafeDeleteArticleAsync(int Id); //Tamamen silmeden Silmiş gibi işlem yaptırırız.
        Task UndoDeleteArticleAsync(int Id); //Silinmiş makaleleri geri getirir.

        Task<ArticleListDTO> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3,
             bool isAscending = false); //PAGINATION işlemi için kullanılıyor bu metot, burada açılan home-indexte kaç makale ekranda görünsün ve fazla makale varsa alttaki sayfa numaralarından atlatma işlemi için yaparız.
        Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
            bool isAscending = false); //Ana sayfada makaleler listelenirken keyword e göreSerach ile arama işlemi için bu metot yapıldı.
    }
}
