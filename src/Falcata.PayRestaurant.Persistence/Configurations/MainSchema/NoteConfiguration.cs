using Falcata.PayRestaurant.Domain.Models.MainSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.PayRestaurant.Persistence.Configurations.MainSchema;

public class NoteConfiguration: BaseEntityTypeConfiguration<Note>, IMainSchemaEntityTypeConfiguration<Note>
{
    protected override void ConfigureTable(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("notes", "main")
            .HasKey(x => x.NoteId);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<Note> builder)
    {
        builder.Property(x => x.NoteId)
            .HasColumnName("note_id")
            .UseIdentityColumn();
        
        builder.Property(x => x.Message)
            .HasColumnName("note");
    }
}