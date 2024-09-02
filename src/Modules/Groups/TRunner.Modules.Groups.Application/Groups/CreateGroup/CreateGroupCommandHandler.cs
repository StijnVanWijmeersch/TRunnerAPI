using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Runners;

namespace TRunner.Modules.Groups.Application.Groups.CreateGroup;
internal sealed class CreateGroupCommandHandler(
    IGroupRepository groupRepository,
    IMemberRepository runnerRepository,
    IUnitOfWork unitOfWork): ICommandHandler<CreateGroupCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        Member? member = await runnerRepository.GetAsync(request.OwnerId, cancellationToken);

        if (member is null)
        {
            return Result.Failure<Guid>(MemberErrors.NotFound(request.OwnerId));
        }

        var group = Group.Create(request.Size, request.Name, request.Description, request.OwnerId);

        groupRepository.Insert(group);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(group.Id);
    }
}
