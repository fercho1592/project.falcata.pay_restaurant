using Microsoft.EntityFrameworkCore;

namespace Falcata.PayRestaurant.Persistence.Contexts;

public abstract class BaseDdContext : DbContext
{
    protected BaseDdContext(DbContextOptions ctxOptions) : base(ctxOptions)
    {
    }

    protected void SetEntityConfigurations(ModelBuilder builder, Type entityConfigurationType, string schema)
    {
        var entityConfigurations = typeof(BaseDdContext).Assembly
            .GetTypes()
            .Where(t => t is {IsClass: true, IsAbstract: false} && t.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == entityConfigurationType));

        var applyConfigurationMethod = typeof(ModelBuilder)
            .GetMethods()
            .Single(mtd =>
                mtd is {ContainsGenericParameters: true, IsAbstract: false, Name: "ApplyConfiguration"}
                && mtd.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

        foreach (var config in entityConfigurations)
        {
            var entityType = config.GetInterfaces().First().GenericTypeArguments[0];
            var configurationInstance = Activator.CreateInstance(config, args: new object [] {/*schema*/});

            var target = applyConfigurationMethod.MakeGenericMethod(entityType);
            target.Invoke(builder, new [] { configurationInstance });
        }
    }
}