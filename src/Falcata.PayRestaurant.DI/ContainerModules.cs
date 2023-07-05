using Microsoft.AspNetCore.Hosting;

namespace Falcata.PayRestaurant.DI;

public static class ContainerModules
{
    [ExcludeFromCodeCoverage]
    public static IWebHostBuilder ConfigureDependencies(IWebHostBuilder webHost)
    {
        return webHost;
    }
}