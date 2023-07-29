using System.Text;
using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Application.Interfaces.Repositories.Users;
using Falcata.PayRestaurant.Domain.Models.MainSchema;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Falcata.PayRestaurant.API.Controllers;

[Route("[controller]")]
public class HealthStatusController: BaseController
{
    private readonly IMediator _mediator;
    private readonly IUserQueryRepository _userQueryRepository;

    public HealthStatusController(IMediator mediator, IUserQueryRepository userQueryRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _userQueryRepository = userQueryRepository ?? throw new ArgumentNullException(nameof(userQueryRepository));
    }

    [HttpGet("/")]
    public async Task<string> ServiceHealthAsync([FromQuery] string email, CancellationToken cancellationToken)
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"Mediator active: {_mediator is not null}");
        
        try
        {
            IQueryBuilder<User> userQuery = _userQueryRepository.NewQueryBuilder();
            userQuery.NoTracking();
            if (!string.IsNullOrWhiteSpace(email))
                userQuery.SetPredicate(x => x.Email.Contains(email));

            var userList = await _userQueryRepository.ListAsync(userQuery, cancellationToken);
            
            result.AppendLine("Users:");
            foreach (var user in userList)
                result.AppendLine($"{user.Email}");
            if(userList is { Count: 0})
                result.AppendLine("Empty List");
        }
        catch
        {
            result.AppendLine("Error reading users list");
        }

        return result.ToString();
    }
}