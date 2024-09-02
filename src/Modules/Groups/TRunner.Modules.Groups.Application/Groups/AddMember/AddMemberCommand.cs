using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.AddRunner;
public sealed record AddMemberCommand(Guid GroupId, Guid MemberId) : ICommand;
