using Falcata.PayRestaurant.Domain.Models;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories;

public interface IUpdateCommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}