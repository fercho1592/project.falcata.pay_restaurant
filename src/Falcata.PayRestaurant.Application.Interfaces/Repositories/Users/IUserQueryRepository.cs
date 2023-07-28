using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories.Users;

public interface IUserQueryRepository : IQueryRepository<User, int>
{
    Task<List<User>> UserListAsync(CancellationToken cancellationToken);
}