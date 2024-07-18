using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Groups;
public sealed class GroupClosedDomainEvent(Guid groupId) : DomainEvent
{
    public Guid GroupId { get; init; } = groupId;
}
