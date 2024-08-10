using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.CloseGroup;
public sealed record CloseGroupCommand(Guid GroupId) : ICommand;
