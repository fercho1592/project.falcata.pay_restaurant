using Falcata.PayRestaurant.Domain.Models.MainSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.PayRestaurant.Persistence.Configurations.MainSchema;

public class UserConfiguration: BaseEntityTypeConfiguration<User>, IMainSchemaEntityTypeConfiguration<User>
{
    protected override void ConfigureTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", "main")
            .HasKey(x => x.UserId);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .UseIdentityColumn();
        
        builder.Property(x => x.Email)
            .HasColumnName("email");
    }
}