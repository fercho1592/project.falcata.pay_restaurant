namespace Falcata.PayRestaurant.Persistence.Contexts;

public interface IBaseDbContext
{
    Task ExecuteSaveChangesAsync(CancellationToken cancellationToken);
}