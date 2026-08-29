using KTP.Domain.Modules.Entities.Tasks;
using KTP.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTP.Infrastructure.Persistence.Configurations.Tasks;

internal sealed class PlanItemConfiguration : EntityConfiguration<PlanItem>
{
    protected override void ConfigureNavigation(EntityTypeBuilder<PlanItem> builder)
    {
    }

    protected override void ConfigureProperties(EntityTypeBuilder<PlanItem> builder)
    {
        builder.Property(p => p.Text)
            .IsRequired()
            .HasMaxLength(TasksConstants.Constraints.PlanItemTextMaxLength);
    }
}
