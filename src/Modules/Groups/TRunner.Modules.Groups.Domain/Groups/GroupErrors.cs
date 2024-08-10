using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Groups;
public static class GroupErrors
{
    public static Error NotFound(Guid groupId) =>
        Error.NotFound("Groups.NotFound", $"Group with id {groupId} was not found");

    public static Error RunnerNotFound(Guid runnerId) => Error.NotFound(
      "Groups.RunnerNotFound",
      $"Runner with id {runnerId} was not found in the group");

    public static Error RunnerAlreadyInGroup(Guid runnerId) => Error.Conflict(
      "Groups.RunnerAlreadyInGroup",
      $"Runner with id {runnerId} is already in the group");

    public static Error SameOwner(Guid ownerId) => Error.Conflict(
      "Groups.SameOwner",
      $"Owner with id {ownerId} is the same as the current owner");

    public static Error NewOwnerNotInGroup(Guid ownerId) => Error.Conflict(
      "Groups.NewOwnerNotInGroup",
      $"New owner with id {ownerId} is not in the group");


    public static readonly Error AlreadyClosed = Error.Conflict(
        "Groups.AlreadyClosed",
        "Group is already closed");  
    
    public static readonly Error AlreadyOpen = Error.Conflict(
        "Groups.AlreadyOpen",
        "Group is already open");

    public static readonly Error GroupIsFull = Error.Conflict(
        "Groups.GroupIsFull",
        "Group is full");

  
}
