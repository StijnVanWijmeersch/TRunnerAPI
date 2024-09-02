using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Users.Application.Users.RegisterUser;
public sealed record RegisterUserCommand(
    string Email,
    string UserName) : ICommand<Guid>;
