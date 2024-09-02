using TRunner.Common.Domain;
using TRunner.Modules.Groups.Domain.Runners;

namespace TRunner.Modules.Groups.Domain.Groups;

public sealed class Group : Entity
{
    public Guid Id { get; private set; }
    public int Size { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid OwnerId { get; private set; }
    public GroupStatus Status { get; private set; }
    public IList<Member> Members { get; private set; }

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

    public int MemberCount => Members.Count;

    public Result Close()
    {
        if (Status == GroupStatus.Closed)
        {
            return Result.Failure(GroupErrors.AlreadyClosed);
        }

        Status = GroupStatus.Closed;

        RaiseDomainEvent(new GroupClosedDomainEvent(Id));

        return Result.Success();
    }

    public Result Open()
    {
        if (Status == GroupStatus.Open)
        {
            return Result.Failure(GroupErrors.AlreadyOpen);
        }

        Status = GroupStatus.Open;

        RaiseDomainEvent(new GroupOpenedDomainEvent(Id));

        return Result.Success();
    }

    public Result RemoveMember(Member oldMember)
    {
        Member? member = Members.FirstOrDefault(gr => gr.Id == oldMember.Id);

        if (member is null)
        {
            return Result.Failure(GroupErrors.RunnerNotFound(oldMember.Id));
        }

        Members.Remove(member);

        RaiseDomainEvent(new MemberRemovedFromGroupDomainEvent(oldMember.Id, Id));

        return Result.Success();
    }

    public Result AddMember(Member newMember)
    {

        if (Members.Count >= Size)
        {
            return Result.Failure(GroupErrors.GroupIsFull);
        }

        Member? member = Members.FirstOrDefault(gr => gr.Id == newMember.Id);

        if (member is not null)
        {
            return Result.Failure(GroupErrors.RunnerAlreadyInGroup(newMember.Id));
        }

        Members.Add(newMember);

        return Result.Success();
    }

    public Result ChangeOwner(Guid newOwnerId)
    {
        if (OwnerId == newOwnerId)
        {
            return Result.Failure(GroupErrors.SameOwner(newOwnerId));
        }

        bool memberExists = Members.Any(gr => gr.Id == newOwnerId);

        if (!memberExists)
        {
            return Result.Failure(GroupErrors.NewOwnerNotInGroup(newOwnerId));
        }

        OwnerId = newOwnerId;

        return Result.Success();
    }

    public void Remove()
    {
        RaiseDomainEvent(new GroupRemovedDomainEvent(Id));
    }


}
