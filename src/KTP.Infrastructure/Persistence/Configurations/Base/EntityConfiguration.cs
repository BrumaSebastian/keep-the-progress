using KTP.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTP.Infrastructure.Persistence.Configurations.Base;

internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureProperties(builder);
        ConfigureNavigation(builder);
        ConfigureEntity(builder);
    }

    protected abstract void ConfigureProperties(EntityTypeBuilder<T> builder);
    protected abstract void ConfigureNavigation(EntityTypeBuilder<T> builder);
    protected virtual void ConfigureEntity(EntityTypeBuilder<T> builder) { }
}
