using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Groups;
public sealed class GroupRemovedDomainEvent(Guid groupId) : DomainEvent
{
    public Guid GroupId { get; init; } = groupId;
}
