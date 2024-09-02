using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public static class MemberErrors
{
    public static Error NotFound(Guid id)
        => Error.NotFound("Member.NotFound", $"Member with id {id} was not found.");
}
