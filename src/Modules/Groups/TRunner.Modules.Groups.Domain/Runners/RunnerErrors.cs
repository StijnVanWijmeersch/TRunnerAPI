using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public static class RunnerErrors
{
    public static Error NotFound(Guid id)
        => Error.NotFound("Runner.NotFound", $"Runner with id {id} was not found.");
}
