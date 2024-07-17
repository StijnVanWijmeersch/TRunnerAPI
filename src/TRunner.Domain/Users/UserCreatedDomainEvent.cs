using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Users;
public sealed class UserCreatedDomainEvent : IDomainEvent
{
    public Guid Id => throw new NotImplementedException();

    public DateTime OccurredOn => throw new NotImplementedException();
}
