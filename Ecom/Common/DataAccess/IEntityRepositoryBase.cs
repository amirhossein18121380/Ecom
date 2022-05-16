using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace Common.DataAccess
{
    public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity GetById(long id);
        Task<TEntity> GetByIdAsync(long id);
    }
}