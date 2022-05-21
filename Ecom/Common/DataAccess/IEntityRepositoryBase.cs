using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace Common.DataAccess
{
    public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(long id);
        Task<TEntity> GetByIdAsync(long id);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}