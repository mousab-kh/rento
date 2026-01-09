using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rento.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        Task<T?> GetEntityAsync(int id);
        void DeleteEntity(T entity);
        void Save();
        IQueryable<T> GetAll();
        void Clear();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
