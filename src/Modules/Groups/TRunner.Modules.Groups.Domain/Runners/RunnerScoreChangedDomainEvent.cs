using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public sealed class RunnerScoreChangedDomainEvent(Guid runnerId, int score) : DomainEvent
{
    public Guid RunnerId { get; init; } = runnerId;
    public int Score { get; init; } = score;
}
