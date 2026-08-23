namespace KTP.Domain.Base;

interface IHasCreationDate
{
    DateTime CreatedAtUtc { get; set; }
}

interface ICreationMetadata : IHasCreationDate
{
}

interface IHasUpdateDate
{
    DateTime? UpdatedAtUtc { get; set; }
}

interface IUpdateMetadata : IHasUpdateDate
{
}

interface IHasDeletionDate
{
    DateTime? DeletedAtUtc { get; set; }
}

interface IDeletionMetadata : IHasDeletionDate
{
}

interface IAuditMetadata : ICreationMetadata, IUpdateMetadata, IDeletionMetadata
{
}

interface IModificationMetadata : ICreationMetadata, IUpdateMetadata
{
}