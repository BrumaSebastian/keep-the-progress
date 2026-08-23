namespace KTP.Domain.Base;

public abstract class BaseEntity<TId> : IBaseEntity where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
    object IBaseEntity.Id { get => Id; }
}
