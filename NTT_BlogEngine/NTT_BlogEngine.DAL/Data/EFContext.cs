using Microsoft.AspNet.Identity.EntityFramework;
using NTT_BlogEngine.DAL.Interfaces;
using NTT_BlogEngine.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT_BlogEngine.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ApplicationDbContext()
            : base(Identifier.DbName)
        {
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Post>();
            modelBuilder.Entity<Comment>();
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<NTT_BlogEngine.DAL.Model.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<NTT_BlogEngine.DAL.Model.Comment> Comments { get; set; }
    }
}
