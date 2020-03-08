using NTT_BlogEngine.DAL.Interfaces;
using NTT_BlogEngine.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace NTT_BlogEngine.DAL
{
    public class EntityRepository : IRepository
    {
        private readonly IDbContext context;

        public EntityRepository(IDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            return GetDbSet<TEntity>().AsQueryable();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            GetDbSet<TEntity>().Add(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            GetDbSet<TEntity>().Remove(entity);
        }

        private IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }


        public TEntity GetById<TEntity>(int id) where TEntity : BaseModel<int>
        {
            return (from item in GetEntities<TEntity>()
                    where item.Id == id
                    select item).SingleOrDefault();
        }
    }
}
