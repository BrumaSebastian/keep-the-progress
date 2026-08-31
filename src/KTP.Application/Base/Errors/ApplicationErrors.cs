namespace KTP.Application.Base.Errors;

public record CreateError(string EntityName, string Details)
{
    public string Code => $"{EntityName}.CreateFailed";
    public string Description => $"Failed to create {EntityName}: {Details}";
}

public record UpdateError(string EntityName, string Details)
{
    public string Code => $"{EntityName}.UpdateFailed";
    public string Description => $"Failed to update {EntityName}: {Details}";
}

public record NotFoundError(string EntityName, Guid Id)
{
    public string Code => $"{EntityName}.NotFound";
    public string Description => $"{EntityName} with ID '{Id}' was not found.";
}

public record DeleteError(string EntityName, string Details)
{
    public string Code => $"{EntityName}.DeleteFailed";
    public string Description => $"Failed to delete {EntityName}: {Details}";
}

