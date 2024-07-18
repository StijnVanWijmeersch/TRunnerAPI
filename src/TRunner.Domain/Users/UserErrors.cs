using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Users;
public static class UserErrors
{
    public static Error NotFound(Guid userId) =>
        Error.NotFound("Users.NotFound", $"User with id {userId} was not found");

    public static Error EmailAlreadyInUse(string email) =>
        Error.Conflict("Users.EmailAlreadyInUse", $"Email {email} is already in use");

    public static Error UserNameAlreadyInUse(string userName) =>
        Error.Conflict("Users.UserName", $"Username {userName} is already in use");
}
