using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Runs;
public sealed class RunStartedDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; init; } = userId;
}
