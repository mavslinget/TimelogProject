using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<TEntity>
         where TEntity : class
    {
        TEntity Create(TEntity newEntity);

        TEntity Update(object key, TEntity entity);

        void Delete(object key);

        IQueryable<TEntity> Retrieve();

        Task<TEntity> CreateAsync(TEntity newEntity);

        Task DeleteAsync(object key);

        Task<TEntity> UpdateAsync(object key, TEntity entity);

        TEntity Retrieve(object id);

        Task<TEntity> RetrieveAsync(object id);
    }
}
