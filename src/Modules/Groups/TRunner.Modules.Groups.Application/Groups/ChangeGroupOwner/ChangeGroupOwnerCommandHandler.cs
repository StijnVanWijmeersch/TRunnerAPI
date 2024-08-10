using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;

namespace TRunner.Modules.Groups.Application.Groups.ChangeGroupOwner;
internal sealed class ChangeGroupOwnerCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<ChangeGroupOwnerCommand>
{
    public async Task<Result> Handle(ChangeGroupOwnerCommand request, CancellationToken cancellationToken)
    {
        Group? group = await groupRepository.GetAsync(request.GroupId, cancellationToken);

        if (group is null)
        {             
            return Result.Failure(GroupErrors.NotFound(request.GroupId));
        }

        Result result = group.ChangeOwner(request.NewOwnerId);

        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
