using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.Generic;
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

        public IEnumerable<TEntity> Get()
        {
            return _set;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _set.Where(expression.Compile());
        }

        public IEnumerable<TModel> Get<TModel>(Expression<Func<TEntity, bool>> expression)
            where TModel : class
        {
            return _set.Where(expression.Compile()).AsQueryable().ProjectTo<TModel>();
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
