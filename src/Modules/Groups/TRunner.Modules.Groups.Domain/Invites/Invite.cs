namespace TRunner.Modules.Groups.Domain.Invites;
public sealed class Invite
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }   
    public Guid RunnerId { get; set; }
    public InviteStatus Status { get; set; }
}
