using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Runners;

namespace TRunner.Modules.Groups.Application.Groups.AddRunner;
internal sealed class AddRunnerCommandHandler(
    IGroupRepository groupRepository,
    IRunnerRepository runnerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<AddRunnerCommand>
{
    public async Task<Result> Handle(AddRunnerCommand request, CancellationToken cancellationToken)
    {
        Group? group = await groupRepository.GetAsync(request.GroupId, cancellationToken);

        if (group is null)
        {
            return Result.Failure(GroupErrors.NotFound(request.GroupId));
        }

        Runner? runner = await runnerRepository.GetAsync(request.RunnerId, cancellationToken);

        if (runner is null) 
        {
            return Result.Failure(RunnerErrors.NotFound(request.RunnerId));
        }

        Result result = group.AddRunner(runner);

        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
