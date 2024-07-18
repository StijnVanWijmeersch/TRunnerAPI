using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Runs;
public sealed class RunFinishedDomainEvent(Guid runId, Guid userId) : DomainEvent
{
    public Guid RunId { get; init; } = runId;
    public Guid UserId { get; init; } = userId;
}
