using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TRunner.Common.Domain;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Groups.Application.Groups.GetGroups;

namespace TRunner.Modules.Groups.Presentation.Groups;
internal sealed class GetGroups : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("groups", async (ISender sender) =>
        {
            Result<IReadOnlyCollection<GroupResponse>> result = await sender.Send(new GetGroupsQuery());

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.NotFound(result.Error);
        })
        .WithTags(Tags.Groups);
    }
}
