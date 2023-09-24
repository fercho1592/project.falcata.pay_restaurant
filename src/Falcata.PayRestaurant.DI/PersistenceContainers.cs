using System.Reflection;
using Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;
using Falcata.PayRestaurant.Application.Interfaces.Repositories.Users;
using Falcata.PayRestaurant.Persistence.Contexts;
using Falcata.PayRestaurant.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.DI;

[ExcludeFromCodeCoverage]
public static class PersistenceContainers
{
    public static void RegisterPersistenceContainers(this IServiceCollection service, params Assembly[] assemblies)
    {
        RegisterContext(service, assemblies);
        RegisterMainRepositories(service, assemblies);
    }

    private static void RegisterMainRepositories(this IServiceCollection service, Assembly[] assemblies)
    {
        //service.AddScoped(typeof(IUserQueryRepository), typeof(UserRepository));

        service.AddScoped<UserRepository>()
            .AddScoped<NoteRepository>();
            
        service
            .AddScoped<IUserQueryRepository>(x => x.GetService<UserRepository>() ?? throw new InvalidOperationException())
            .AddScoped<INotesCommandRepository>(x => x.GetService<NoteRepository>() ?? throw new InvalidOperationException())
            .AddScoped<INotesQueryRepository>(x => x.GetService<NoteRepository>() ?? throw new InvalidOperationException());
    }

    private static void RegisterContext(this IServiceCollection service, Assembly[] assemblies)
    {
        service.AddScoped<IMainDbContext>(s =>
        {
            var config = s.GetService<IConfiguration>();
            var connString = config?.GetConnectionString("MainConnection");
            if (string.IsNullOrWhiteSpace(connString))
                throw new ArgumentNullException("ConnectionStrings:MainConnection", "Verify if the User Secrets were added correctly");

            var opt = new DbContextOptionsBuilder<MainDbContext>();
            opt.UseSqlServer(connString);

            // var logger = s.GetService<IAppLogger<MainDbContext>>();
            // opt.LogTo(message => { logger.Debug(message); }, LogLevel.Information);
            
            return new MainDbContext(opt.Options);
        });
    }
}