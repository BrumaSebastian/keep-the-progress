using KTP.API.Base.Extensions;

namespace KTP.API.Features.Tasks.Create;

public class CreateTask : IEndpoint
{
    public string GetEndpointName()
    {
        return "task";
    }

    public void MapEndpoint(IEndpointRouteBuilder endpointRouterBuilder)
    {
        endpointRouterBuilder.MapPost(this.GetEndpointPath(), Handle)
            .WithName("CreateTask")
            .WithTags("Tasks");
    }

    private static async Task<IResult> Handle()
    {
        return Results.Ok();
    }
}
