using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TRunner.Common.Domain;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Users.Application.Users.RegisterUser;

namespace TRunner.Modules.Users.Presentation.Users;

internal sealed class RegisterUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new RegisterUserCommand(
                request.Email,
                request.UserName));

            return result.IsSuccess
                ? Results.Created($"/users/{result.Value}", result.Value)
                : Results.BadRequest(result.Error);
        })
        .WithTags(Tags.Users);
    }

    internal sealed class Request
    {
        public string Email { get; init; }
        public string UserName { get; init; }

    }
}
