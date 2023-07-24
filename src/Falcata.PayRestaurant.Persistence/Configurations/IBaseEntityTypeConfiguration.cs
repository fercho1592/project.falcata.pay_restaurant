using Microsoft.EntityFrameworkCore;

namespace Falcata.PayRestaurant.Persistence.Configurations;

public interface IBaseEntityTypeConfiguration<TEntity>: IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    
}