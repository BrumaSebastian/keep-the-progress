using KTP.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace KTP.Infrastructure.Persistence.Configurations.Base;

internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasValueGenerator<UuidV7ValueGenerator>();

        ConfigureProperties(builder);
        ConfigureNavigation(builder);
        ConfigureEntity(builder);
    }

    protected abstract void ConfigureProperties(EntityTypeBuilder<T> builder);
    protected abstract void ConfigureNavigation(EntityTypeBuilder<T> builder);
    protected virtual void ConfigureEntity(EntityTypeBuilder<T> builder) { }
}

public class UuidV7ValueGenerator : ValueGenerator<Guid>
{
    public override bool GeneratesTemporaryValues => false;

    public override Guid Next(EntityEntry entry) => Guid.CreateVersion7();
}