using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Domain.Models;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories;

public interface IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<List<TEntity>> ListAsync(IQueryBuilder<TEntity> queryBuilder, CancellationToken cancellationToken);
}