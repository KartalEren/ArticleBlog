using ArticleBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Repositories.Abstracts
{
    //***BURDA METOTLARIN SOYUT HALİ KULLANILIR, REPOSITORY DE İSE SOMUT HALİ KULLANILIR.
    public interface IRepository<T> where T : class, IEntityBase,new() 
    {
        Task AddAsync(T entity); 
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); 

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); 
        Task<T> GetByIdAsync(int id); 
        Task<T> UpdateAsync(T entity); 
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); 
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null); 

    }
}
