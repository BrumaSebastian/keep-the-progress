using KTP.Domain.Modules.Entities.Tasks;
using KTP.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTP.Infrastructure.Persistence.Configurations.Tasks;

internal sealed class NoteConfiguration : EntityConfiguration<Note>
{
    protected override void ConfigureNavigation(EntityTypeBuilder<Note> builder)
    {
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Note> builder)
    {
        builder.Property(n => n.Content)
            .IsRequired()
            .HasMaxLength(TasksConstants.Constraints.NoteContentMaxLength);
    }
}
