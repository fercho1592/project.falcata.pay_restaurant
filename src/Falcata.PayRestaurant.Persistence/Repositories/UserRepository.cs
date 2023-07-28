using Falcata.PayRestaurant.Application.Interfaces.Repositories.Users;
using Falcata.PayRestaurant.Domain.Models.MainSchema;
using Falcata.PayRestaurant.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Persistence.Repositories;

public class UserRepository: IUserQueryRepository
{
    private readonly IMainDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IMainDbContext context, ILogger<UserRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<List<User>> UserListAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug(_context.ToString());

        var users = await _context.Users.ToListAsync(cancellationToken);
        
        return users;
    }
}