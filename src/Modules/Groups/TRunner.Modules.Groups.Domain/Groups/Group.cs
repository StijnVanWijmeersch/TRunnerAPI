using TRunner.Common.Domain;
using TRunner.Modules.Groups.Domain.JoinTables;

namespace TRunner.Modules.Groups.Domain.Groups;

public sealed class Group : Entity
{
    public Guid Id { get; set; }
    public int Size { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public GroupStatus Status { get; set; }

    // Navigational properties
    public IList<RunnerGroup> Runners { get; set; }

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

    public Result RemoveRunner(Guid runnerId)
    {
        RunnerGroup? runner = Runners.FirstOrDefault(gr => gr.RunnerId == runnerId);

        if (runner is null)
        {
            return Result.Failure(GroupErrors.RunnerNotFound(runnerId));
        }

        Runners.Remove(runner);

        RaiseDomainEvent(new RunnerRemovedFromGroupDomainEvent(runnerId, Id));

        return Result.Success();
    }

    public Result AddRunner(Guid runnerId)
    {

        if (Runners.Count >= Size)
        {
            return Result.Failure(GroupErrors.GroupIsFull);
        }

        RunnerGroup? runner = Runners.FirstOrDefault(gr => gr.RunnerId == runnerId);

        if (runner is not null)
        {
            return Result.Failure(GroupErrors.RunnerAlreadyInGroup(runnerId));
        }

        var runnerGroup = new RunnerGroup
        {
            GroupId = Id,
            RunnerId = runnerId
        };

        Runners.Add(runnerGroup);

        return Result.Success();
    }
    
    public Result ChangeOwner(Guid newOwnerId)
    {
        if (OwnerId == newOwnerId)
        {
            return Result.Failure(GroupErrors.SameOwner(newOwnerId));
        }

        bool runnerExists = Runners.Any(gr => gr.RunnerId == newOwnerId);

        if (!runnerExists)
        {
            return Result.Failure(GroupErrors.NewOwnerNotInGroup(newOwnerId));
        }

        OwnerId = newOwnerId;

        return Result.Success();
    }

    public Result Remove()
    {
        Runners.Clear();

        RaiseDomainEvent(new GroupRemovedDomainEvent(Id));

        return Result.Success();
    }


}
