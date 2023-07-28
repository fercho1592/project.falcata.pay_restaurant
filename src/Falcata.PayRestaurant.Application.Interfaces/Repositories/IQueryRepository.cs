using Falcata.PayRestaurant.Domain.Models;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories;

public interface IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    
}