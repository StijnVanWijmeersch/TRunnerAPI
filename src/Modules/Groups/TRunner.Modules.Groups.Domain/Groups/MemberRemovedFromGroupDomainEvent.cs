using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Groups;
public sealed class MemberRemovedFromGroupDomainEvent(Guid runnerId, Guid groupId) : DomainEvent
{
    public Guid MemberId { get; init; } = runnerId;
    public Guid GroupId { get; init; } = groupId;
}
