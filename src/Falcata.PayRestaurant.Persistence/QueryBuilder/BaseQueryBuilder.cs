using System.Linq.Expressions;
using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Microsoft.EntityFrameworkCore;

namespace Falcata.PayRestaurant.Persistence.QueryBuilder;

public abstract class BaseQueryBuilder<TEntity>: IQueryBuilder<TEntity> where TEntity : class
{
    protected IQueryable<TEntity> Query;
    protected Expression<Func<TEntity, bool>>? Predicate;

    internal (IQueryable<TEntity>, Expression<Func<TEntity, bool>>? predicate) GetQuery()
    {
        return (Query, Predicate);
    }

    internal BaseQueryBuilder(IQueryable<TEntity> queryEntity)
    {
        Query = queryEntity ?? throw new ArgumentNullException(nameof(queryEntity));
        Predicate = null;
    }

    public IQueryBuilder<TEntity> SetPredicate(Expression<Func<TEntity, bool>>? predicate)
    {
        Predicate = predicate;
        return this;
    }

    public IQueryBuilder<TEntity> NoTracking()
    {
        Query = Query.AsNoTracking();
        
        return this;
    }

    public IQueryBuilder<TEntity> Tracking()
    {
        Query = Query.AsTracking();
        
        return this;
    }

    public IQueryBuilder<TEntity> SplitQuery()
    {
        Query = Query.AsSplitQuery();
        
        return this;
    }
}