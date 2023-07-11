using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Falcata.PayRestaurant.API.Controllers;

[Route("[controller]")]
public class HealthStatusController: BaseController
{
    private readonly IMediator _mediator;

    public HealthStatusController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("/")]
    public async Task<string> ServiceHealthAsync()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"Mediator active: {_mediator is not null}");

        return result.ToString();
    }
}