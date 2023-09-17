using Falcata.PayRestaurant.Domain.Models;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories;

public interface IDeleteCommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}