using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Friendships;
public sealed class Friendship : Entity
{
    public Guid RequesterId { get; init; }
    public Guid RequestedId { get; init; }
    public bool IsAccepted { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Friendship() { }

    public static Friendship Create(Guid requesterId, Guid requestedId)
    {
        var friendship = new Friendship
        {
            RequesterId = requesterId,
            RequestedId = requestedId,
            IsAccepted = false
        };

        friendship.RaiseDomainEvent(new FriendshipRequestedDomainEvent(requesterId, requestedId));

        return friendship;
    }


    public Result Accept()
    {
        IsAccepted = true;

        RaiseDomainEvent(new FriendshipAcceptedDomainEvent(RequesterId, RequestedId));

        return Result.Success();
    }
}
