using System.Linq.Expressions;
using Jwt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Core.DataAccess;

public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext: DbContext
    
{
    protected  TContext Context { get; }

    public EfEntityRepository(TContext context)
    {
        Context = context;
    }
    
    public void Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
    {
        return predicate== null ? Context.Set<TEntity>().ToList() : Context.Set<TEntity>().Where(predicate).ToList();
    }

    public TEntity GetByFilter(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }
}