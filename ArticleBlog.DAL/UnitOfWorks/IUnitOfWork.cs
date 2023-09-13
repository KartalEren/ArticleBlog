using ArticleBlog.Core.Entities;
using ArticleBlog.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new(); 
        Task<int> SaveAsync();

        int Save(); 
    }
}
