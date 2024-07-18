using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Friendships;
public sealed class FriendshipAcceptedDomainEvent(Guid requesterId, Guid requestedId) : DomainEvent
{
    public Guid RequesterId { get; init; } = requesterId;
    public Guid RequestedId { get; init; } = requestedId;
}
