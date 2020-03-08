using NTT_BlogEngine.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT_BlogEngine.DAL.Interfaces
{
    public interface IRepository : IDisposable
    {
        System.Linq.IQueryable<TEntity> GetEntities<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();

        TEntity GetById<TEntity>(int id) where TEntity : BaseModel<int>;
    }
}
