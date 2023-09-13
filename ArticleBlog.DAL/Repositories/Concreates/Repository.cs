using ArticleBlog.Core.Entities;
using ArticleBlog.DAL.Context;
using ArticleBlog.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Repositories.Concreates
{
   
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() 
    {
        private readonly BlogDBContext _dbContext;
        public Repository(BlogDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        private DbSet<T> BlogTable { get => _dbContext.Set<T>(); }
        public async Task AddAsync(T entity) 
        {
            await BlogTable.AddAsync(entity);
        }



        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = BlogTable;
            if (predicate != null) 
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item); 
                }
            }
            return query.ToList(); 

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)  
        {
            IQueryable<T> query = BlogTable; 
            query = query.Where(predicate); 


            foreach (var item in includeProperties)
            {
                query = query.Include(item); 
            }
            return await query.SingleAsync(); 
        }




        public async Task<T> GetByIdAsync(int id) 
        {
            return await BlogTable.FindAsync(id); 

        }

        public async Task<T> UpdateAsync(T entity) 
        {
           await Task.Run(() => BlogTable.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity) 
        {
            await Task.Run(() => BlogTable.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) 
        {
          return await BlogTable.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await BlogTable.CountAsync(predicate); 
        }

      
    }

}
