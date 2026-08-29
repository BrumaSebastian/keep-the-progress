using KTP.Domain.Modules.Entities.Tasks;
using KTP.Domain.Modules.Entities.Tasks.Enums;
using KTP.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTP.Infrastructure.Persistence.Configurations.Tasks;

internal sealed class ToDoItemDayConfiguration : EntityConfiguration<ToDoItemDay>
{
    protected override void ConfigureNavigation(EntityTypeBuilder<ToDoItemDay> builder)
    {
        builder.HasMany(d => d.Notes)
            .WithOne(n => n.ToDoItemDay)
            .HasForeignKey(n => n.ToDoItemDayId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.PlanItems)
            .WithOne(p => p.ToDoItemDay)
            .HasForeignKey(p => p.ToDoItemDayId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<ToDoItemDay> builder)
    {
        builder.Property(d => d.DateUtc)
            .IsRequired();
        builder.Property(d => d.Status)
            .IsRequired()
            .HasDefaultValue(TaskDayStatus.Undefined);
    }
}
