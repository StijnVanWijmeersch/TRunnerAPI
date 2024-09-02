using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Runners;

namespace TRunner.Modules.Groups.Application.Groups.AddRunner;
internal sealed class AddMemberCommandHandler(
    IGroupRepository groupRepository,
    IMemberRepository memberRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<AddMemberCommand>
{
    public async Task<Result> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        Group? group = await groupRepository.GetAsync(request.GroupId, cancellationToken);

        if (group is null)
        {
            return Result.Failure(GroupErrors.NotFound(request.GroupId));
        }

        Member? member = await memberRepository.GetAsync(request.MemberId, cancellationToken);

        if (member is null) 
        {
            return Result.Failure(MemberErrors.NotFound(request.MemberId));
        }

        Result result = group.AddMember(member);

        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
