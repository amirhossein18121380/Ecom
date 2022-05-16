using System.Linq.Expressions;
using Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.DataAccess
{

    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
  where TContext : DbContext
    {
        protected readonly TContext _context;
        public EntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}

