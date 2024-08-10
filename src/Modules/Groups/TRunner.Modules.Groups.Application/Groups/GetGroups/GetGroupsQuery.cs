using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.GetGroups;
public sealed record GetGroupsQuery : IQuery<IReadOnlyCollection<GroupResponse>>;
