using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Helpers.Images;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Entitiy.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{
    
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper mapper; 
        private readonly IImageHelper _imageHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._imageHelper = imageHelper;

            this._httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<ArticleListDTO> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false) 
        {
            pageSize = pageSize > 20 ? 20 : pageSize; 
            var articles = categoryId == 0
                ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image)
                : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted,
                    a => a.Category, i => i.Image); 

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDTO 
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//



        public async Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false) 
        {

            pageSize = pageSize > 20 ? 20 : pageSize; 
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.CategoryName.Contains(keyword)),
            a => a.Category, i => i.Image); 




            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDTO 
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }






        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO) 
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();


           
            var imageUpload = await _imageHelper.Upload(articleAddDTO.Title, articleAddDTO.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddDTO.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            await _unitOfWork.SaveAsync();



            /*---------------------------------------------------------*/




           
            var article = new Article(articleAddDTO.Title, articleAddDTO.Content, userId, userEmail, articleAddDTO.CategoryId, image.ID); 


           


            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync(); 
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNoneDeletedAsync() 
        {

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted == false, x => x.Category);

            var map = mapper.Map<List<ArticleDTO>>(articles); 

            return map;
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task<ArticleDTO> GetArticleWithCategoryNonDeletedAsync(int Id)
        {

            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.ID == Id, x => x.Category, i => i.Image);
           

            var map = mapper.Map<ArticleDTO>(article); 

            return map;
        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task<string> UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.ID == articleUpdateDTO.ID, x => x.Category, i => i.Image); 

          
           

            if (articleUpdateDTO.Photo != null)
            {
                _imageHelper.DeleteImage(article.Image.FileName);

                var imageUpload = await _imageHelper.Upload(articleUpdateDTO.Title, articleUpdateDTO.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDTO.Photo.ContentType, userEmail);

                articleUpdateDTO.ImageFileName = image.FileName; 

                await _unitOfWork.GetRepository<Image>().AddAsync(image); 
                await _unitOfWork.SaveAsync();

                article.ImageId = image.ID; 

            }


           /*---------------------------------------------------------------------------------------*/

           
            mapper.Map(articleUpdateDTO, article); 
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;       

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article); 

            await _unitOfWork.SaveAsync();
            return article.Title;

        }




        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task SafeDeleteArticleAsync(int Id)
        {
            var userEmail = _user.GetLoggedInEmail();



            var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(Id);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy=userEmail;


            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }






        
        //--------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//




        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryDeleted()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);

            var map = mapper.Map<List<ArticleDTO>>(articles); 

            return map; 
        }

        public async Task UndoDeleteArticleAsync(int Id)
        {
            var userEmail = _user.GetLoggedInEmail();


            var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(Id);

            article.IsDeleted = false; 
            article.DeletedDate = null;
            article.DeletedBy = null;


            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }

       

        //--------------------------------------------------------------------------------------
    }
}
