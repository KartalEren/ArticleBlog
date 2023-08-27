using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Context
{
    public class IdentityDBContext:IdentityDbContext<AppUser, AppRole,int>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> opt) : base(opt)
        {
            
        }
    }
}
