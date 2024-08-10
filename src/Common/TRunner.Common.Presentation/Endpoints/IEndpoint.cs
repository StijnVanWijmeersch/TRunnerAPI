using Microsoft.AspNetCore.Routing;
namespace TRunner.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
