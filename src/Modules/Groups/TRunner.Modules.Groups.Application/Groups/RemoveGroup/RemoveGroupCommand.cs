
using TRunner.Common.Application.Messaging;

namespace TRunner.Modules.Groups.Application.Groups.RemoveGroup;
public sealed record RemoveGroupCommand(Guid GroupId) : ICommand; 
