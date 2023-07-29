using System.Linq.Expressions;

namespace Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;

public interface IQueryBuilder<TEntity>
{
    IQueryBuilder<TEntity> SetPredicate(Expression<Func<TEntity, bool>>? predicate);
    IQueryBuilder<TEntity> NoTracking();
    IQueryBuilder<TEntity> Tracking();
    IQueryBuilder<TEntity> SplitQuery();
}