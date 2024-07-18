using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Runs;
public static class RunErrors
{
    public static Error RunAlreadyFinished(Guid runId) => 
       Error.Conflict("Runs.AlreadyFinished", $"Run with id {runId} is already finished.");

    public static Error RunAlreadyCancelled(Guid id) =>
        Error.Conflict("Runs.AlreadyCancelled", $"Run with id {id} is already cancelled.");
}
