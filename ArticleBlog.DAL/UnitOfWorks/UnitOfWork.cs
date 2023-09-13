using ArticleBlog.DAL.Context;
using ArticleBlog.DAL.Repositories.Abstracts;
using ArticleBlog.DAL.Repositories.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDBContext _dbContext;
        public UnitOfWork(BlogDBContext dBContext) 
        {
            this._dbContext = dBContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public int Save() 
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync() 
        {
           return await _dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>() 
        {
           return new Repository<T>(_dbContext);
        }

       
    }
}
