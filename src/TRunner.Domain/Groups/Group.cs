using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Groups;
public sealed class Group : Entity
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public bool IsPublic { get; set; }
    public GroupStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private Group() { }

    public static Group Create(Guid ownerId, string name, int size, bool isPublic)
    {
        var group = new Group
        {
            Id = Guid.NewGuid(),
            OwnerId = ownerId,
            Name = name,
            Size = size,
            IsPublic = isPublic,
            Status = GroupStatus.Active
        };

        return group;
    }

    public Result Close()
    {
        Status = GroupStatus.Inactive;

        RaiseDomainEvent(new GroupClosedDomainEvent(Id));

        return Result.Success();
    }

}
