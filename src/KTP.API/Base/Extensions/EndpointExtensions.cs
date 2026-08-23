using KTP.API.Constants;

namespace KTP.API.Base.Extensions;

public static class EndpointExtensions
{
    extension(IEndpoint endpoint)
    {
        public string GetEndpointPath()
        {
            return $"{AppConstants.API_ENDPOINT_PREFIX}/{endpoint.GetEndpointName()}";
        }
    }
}
