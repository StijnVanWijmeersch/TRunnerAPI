namespace TRunner.Domain.Abstractions;
public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
}
