using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.AddRunner;
public sealed record AddRunnerCommand(Guid GroupId, Guid RunnerId) : ICommand;
