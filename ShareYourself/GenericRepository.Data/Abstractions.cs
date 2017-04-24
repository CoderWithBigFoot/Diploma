using System;
using System.Linq;

namespace GenericRepository.Data
{
    public interface IEntity
    {
        int Id { set; get; }
    }

    public interface IRepository<TEntity>
        where TEntity: IEntity
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        IQueryable<TModel> Get<TModel>(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
