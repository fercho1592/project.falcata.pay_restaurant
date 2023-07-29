using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories;

public interface IQueryBuilderProvider<TQueryBuilder, TEntity> where TQueryBuilder: IQueryBuilder<TEntity>
{
    TQueryBuilder NewQueryBuilder();
}