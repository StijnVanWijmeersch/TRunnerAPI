using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;

namespace TRunner.Modules.Groups.Application.Groups.CloseGroup;

internal sealed class CloseGroupCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CloseGroupCommand>
{
    public async Task<Result> Handle(CloseGroupCommand request, CancellationToken cancellationToken)
    {
        Group? group = await groupRepository.GetAsync(request.GroupId, cancellationToken);

        if (group is null)
        {
            return Result.Failure(GroupErrors.NotFound(request.GroupId));
        }

        Result result = group.Close();

        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
