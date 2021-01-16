using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Hahn.ApplicatonProcess.December2020.Data.Repositories.Base;
using Hahn.ApplicatonProcess.December2020.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.UOW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext dbContext;

        private Dictionary<Type, object> repos;

        public UnitOfWork(ApplicationContext dBConnectionContext)
        {
            dbContext = dBConnectionContext;
        }
        //public List<TEntity> SpRepository<TEntity>(string SpName, params object[] parameters) where TEntity : class
        //{
        //    return _dBConnectionContext.Set<TEntity>().FromSqlRaw(SpName, parameters).ToList<TEntity>();
        //}
        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new GenericRepository<TEntity>(dbContext);
            }

            return (IGenericRepository<TEntity>)repos[type];
        }
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return dbContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}
