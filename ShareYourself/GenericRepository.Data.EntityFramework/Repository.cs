using System;
using System.Linq;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;

namespace GenericRepository.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private DbContext _context;
        private DbSet<TEntity> _set;

        public Repository(DbContext context)
        {
            _context = context ?? throw new Exception("DbContext is null");
            _set = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return _set;
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _set.Where(x => predicate(x));
        }

        public IQueryable<TModel> Get<TModel>(Func<TEntity, bool> predicate)
        {
            return _set.Where(x => predicate(x)).ProjectTo<TModel>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }
    }
}
