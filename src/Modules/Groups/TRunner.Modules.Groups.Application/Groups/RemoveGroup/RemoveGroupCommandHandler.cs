using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;

namespace TRunner.Modules.Groups.Application.Groups.RemoveGroup;
internal sealed class RemoveGroupCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RemoveGroupCommand>
{
    public async Task<Result> Handle(RemoveGroupCommand request, CancellationToken cancellationToken)
    {
        Group? group = await groupRepository.GetAsync(request.GroupId, cancellationToken);

        if (group is null)
        {
            return Result.Failure(GroupErrors.NotFound(request.GroupId));
        }

        group.Remove();

        groupRepository.Remove(group);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
