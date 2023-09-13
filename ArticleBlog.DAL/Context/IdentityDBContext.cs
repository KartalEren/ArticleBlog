using ArticleBlog.DAL.Configuration;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Context
{
    public class IdentityDBContext : IdentityDbContext<AppUser, AppRole, int>
    { 
       
        public IdentityDBContext(DbContextOptions<IdentityDBContext> opt) : base(opt)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 

        }
    }
}
