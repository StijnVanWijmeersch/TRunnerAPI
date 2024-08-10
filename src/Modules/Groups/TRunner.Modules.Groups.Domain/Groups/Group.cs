using TRunner.Common.Domain;
using TRunner.Modules.Groups.Domain.JoinTables;
using TRunner.Modules.Groups.Domain.Runners;

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
    private IList<RunnerGroup> Runners { get; set; }

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

    public int RunnersCount => Runners.Count;

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

    public Result RemoveRunner(Runner oldRunner)
    {
        RunnerGroup? runner = Runners.FirstOrDefault(gr => gr.RunnerId == oldRunner.Id);

        if (runner is null)
        {
            return Result.Failure(GroupErrors.RunnerNotFound(oldRunner.Id));
        }

        Runners.Remove(runner);

        RaiseDomainEvent(new RunnerRemovedFromGroupDomainEvent(oldRunner.Id, Id));

        return Result.Success();
    }

    public Result AddRunner(Runner newRunner)
    {

        if (Runners.Count >= Size)
        {
            return Result.Failure(GroupErrors.GroupIsFull);
        }

        RunnerGroup? runner = Runners.FirstOrDefault(gr => gr.RunnerId == newRunner.Id);

        if (runner is not null)
        {
            return Result.Failure(GroupErrors.RunnerAlreadyInGroup(newRunner.Id));
        }

        var runnerGroup = new RunnerGroup
        {
            GroupId = Id,
            RunnerId = newRunner.Id
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

    public void Remove()
    {
        RaiseDomainEvent(new GroupRemovedDomainEvent(Id));
    }


}
