using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public sealed class MemberScoreChangedDomainEvent(Guid runnerId, int score) : DomainEvent
{
    public Guid MemberId { get; init; } = runnerId;
    public int Score { get; init; } = score;
}
