using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GenericRepository.Data
{
    public interface IEntity
    {
        int Id { set; get; }
    }

    public interface IRepository<TEntity>
        where TEntity: IEntity
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        //IEnumerable<TModel> Get<TModel>() where TModel : class;
        IEnumerable<TModel> Get<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : class;

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
