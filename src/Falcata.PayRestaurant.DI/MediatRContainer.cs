using System.Reflection;
using MediatR;

namespace Falcata.PayRestaurant.DI;

[ExcludeFromCodeCoverage]
public static class MeditatRContainer
{
    public static void RegisterMediatR(this IServiceCollection service, params Assembly[] assemblies)
    {
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<IMediator>();
            cfg.RegisterServicesFromAssemblies(assemblies)
                .RegisterServicesFromAssemblyContaining(typeof(IRequestHandler<,>));
        });
    }
}