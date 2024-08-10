using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TRunner.Common.Domain;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Groups.Application.Groups.CreateGroup;

namespace TRunner.Modules.Groups.Presentation.Groups;
internal sealed class CreateGroup : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("groups", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new CreateGroupCommand(
                request.Name,
                request.Description,
                request.Size,
                request.OwnerId));

            return result.IsSuccess
                ? Results.Created($"/groups/{result.Value}", result.Value)
                : Results.BadRequest(result.Error);
        })
        .WithTags(Tags.Groups);
    }


    internal sealed class Request
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int Size { get; init; }
        public Guid OwnerId { get; init; }
    }
}
