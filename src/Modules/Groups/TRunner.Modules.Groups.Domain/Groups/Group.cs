using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Groups;

public sealed class Group
{
    public Guid Id { get; set; }
    public int Size { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public GroupStatus Status { get; set; }

    private Group() { }

    public static Group Create(int size, string name, string description, Guid ownerId)
    {
        var group = new Group
        {
            Id = Guid.NewGuid(),
            Size = size,
            Name = name,
            Description = description,
            OwnerId = ownerId,
            Status = GroupStatus.Open
        };

        return group;
    }

}
