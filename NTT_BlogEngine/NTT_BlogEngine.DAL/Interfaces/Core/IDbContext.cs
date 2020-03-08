using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NTT_BlogEngine.DAL.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
