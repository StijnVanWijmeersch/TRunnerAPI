using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Users;
internal class UserEmailChangedDomainEvent(Guid UserId, string UserEmail) : DomainEvent
{
    public Guid UserId { get; init; } = UserId;
    public string UserEmail { get; init; } = UserEmail;
}
