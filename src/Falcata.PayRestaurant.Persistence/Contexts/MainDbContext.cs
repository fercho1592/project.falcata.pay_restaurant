using Falcata.PayRestaurant.Persistence.Configurations.MainSchema;
using Microsoft.EntityFrameworkCore;

namespace Falcata.PayRestaurant.Persistence.Contexts;

public class MainDbContext: BaseDdContext, IMainDbContext
{
    public MainDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        base.SetEntityConfigurations(builder, typeof(IMainSchemaEntityTypeConfiguration<>), "main");
    }

    //entities
    //public DbSet<Student> Students { get; set; }
}