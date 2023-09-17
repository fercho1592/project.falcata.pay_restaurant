using Falcata.PayRestaurant.Domain.Models;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories;

public interface ICreateCommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken);
}