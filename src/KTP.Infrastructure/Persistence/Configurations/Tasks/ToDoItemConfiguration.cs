using KTP.Domain.Modules.Entities.Tasks;
using KTP.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTP.Infrastructure.Persistence.Configurations.Tasks;

internal sealed class ToDoItemConfiguration : EntityConfiguration<ToDoItem>
{
    protected override void ConfigureProperties(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(TasksConstants.Constraints.ToDoItemNameMaxLength);
        builder.Property(t => t.Description)
            .HasMaxLength(TasksConstants.Constraints.ToDoItemDescriptionMaxLength);
    }

    protected override void ConfigureNavigation(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.HasMany(t => t.ToDoItemDays)
            .WithOne(d => d.ToDoItem)
            .HasForeignKey(d => d.ToDoItemId)
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
    }
}
