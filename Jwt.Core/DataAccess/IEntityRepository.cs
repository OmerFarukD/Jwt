using System.Linq.Expressions;
using Jwt.Core.Entities;

namespace Jwt.Core.DataAccess;

public interface IEntityRepository<TEntity> where TEntity: class,IEntity, new()
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate =null);
    TEntity GetByFilter(Expression<Func<TEntity,bool>> predicate);
}