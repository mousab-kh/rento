

using Microsoft.EntityFrameworkCore;
using Rento.Infrastructure.Implemenation.Db;
using Rento.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected RentoDbContext RentoContexts { get; set; }

        public Repository(RentoDbContext context)
        {
            RentoContexts = context;
        }

        public virtual void AddEntity(T entity)
        {
            RentoContexts.Add(entity);

        }

        public virtual void UpdateEntity(T entity)
        {
            RentoContexts.Update(entity);
        }

        public virtual async Task<T?> GetEntityAsync(int id)
        {
            return await RentoContexts.Set<T>().FindAsync(id);
        }

        public virtual void DeleteEntity(T entity)
        {
            RentoContexts.Remove(entity);
        }

        public virtual void Save()
        {
            RentoContexts.SaveChanges();
        }

        public virtual void Clear()
        {
            RentoContexts.ChangeTracker.Clear();
        }

        public virtual IQueryable<T> GetAll()
        {
            return RentoContexts.Set<T>().AsQueryable();
        }

        public virtual async Task<IList<T>> FindEntitysAsync(Expression<Func<T, bool>> predicate)
        {
            return await RentoContexts.Set<T>().Where(predicate).ToListAsync();

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await RentoContexts.Set<T>().AsQueryable().AnyAsync(predicate);
        }
    }
}
