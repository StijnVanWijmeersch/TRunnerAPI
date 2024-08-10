using TRunner.Common.Domain;

namespace TRunner.Modules.Users.Domain.Users;
public static class UserErrors
{
    public static Error NotFound(Guid userId) =>
        Error.NotFound("Users.NotFound", $"User with Id {userId} was not found.");
}
