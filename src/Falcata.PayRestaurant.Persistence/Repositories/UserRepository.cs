using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Application.Interfaces.Repositories.Users;
using Falcata.PayRestaurant.Domain.Models.MainSchema;
using Falcata.PayRestaurant.Persistence.Contexts;
using Falcata.PayRestaurant.Persistence.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Persistence.Repositories;

public class UserRepository: BaseRepository<User, int, IMainDbContext>, IUserQueryRepository
{
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IMainDbContext context, ILogger<UserRepository> logger): base(context, logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override DbSet<User> Entities => _context.Users;
    public IUserQueryBuilder NewQueryBuilder() => new UserQueryBuilder(Entities.AsQueryable());
}