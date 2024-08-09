using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.CreateGroup;
public sealed record CreateGroupCommand(
    string Name,
    string Description,
    int Size,
    Guid OwnerId
    ) : ICommand<Guid>;
