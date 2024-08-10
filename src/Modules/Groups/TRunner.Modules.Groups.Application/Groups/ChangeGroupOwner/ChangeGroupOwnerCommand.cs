using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.ChangeGroupOwner;
public sealed record ChangeGroupOwnerCommand(Guid GroupId, Guid NewOwnerId) : ICommand;
