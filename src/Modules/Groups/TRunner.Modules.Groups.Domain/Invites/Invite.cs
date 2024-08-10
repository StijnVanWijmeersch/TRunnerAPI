namespace TRunner.Modules.Groups.Domain.Invites;
public sealed class Invite
{
    public Guid Id { get; private set; }
    public Guid GroupId { get; private set; }   
    public Guid RunnerId { get; private set; }
    public InviteStatus Status { get; private set; }
}
