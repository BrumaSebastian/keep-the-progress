namespace KTP.API.Base;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder endpointRouterBuilder);
    string GetEndpointName();
}
