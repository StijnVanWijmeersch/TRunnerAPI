using TRunner.Common.Domain;

namespace TRunner.Modules.Users.Domain.Users;
public sealed class UserNameUpdatedDomainEvent(Guid userId, string userName) : DomainEvent
{
    public Guid UserId { get; init; } = userId;
    public string UserName { get; init; } = userName;
}
