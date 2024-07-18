using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Badges;
public sealed class Badge : Entity
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime CreatedAt { get; init; }

    private Badge() { }

    public static Badge Create(string name, string description)
    {
        var badge = new Badge
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };

        return badge;
    }
}
