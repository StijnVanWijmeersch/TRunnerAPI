namespace TRunner.Modules.Groups.Domain.Groups;

public sealed class Group
{
    public Guid Id { get; set; }
    public int Size { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public GroupStatus Status { get; set; }

}
