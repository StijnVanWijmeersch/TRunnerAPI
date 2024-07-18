using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Runs;
public sealed class Run : Entity
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime? StartedOn { get; private set; }
    public DateTime? FinishedOn { get; private set; }
    public TimeSpan? Duration { get; private set; }
    public double? DistanceKm { get; private set; }
    public double? DistanceMiles { get; private set; }
    public RunStatus Status { get; private set; }

    private Run() { }

    public static Run Create(Guid userId)
    {
        var run = new Run
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            StartedOn = DateTime.UtcNow,
            Status = RunStatus.InProgress
        };

        run.RaiseDomainEvent(new RunStartedDomainEvent(run.UserId));

        return run;
    }

    public Result Finish()
    {
        if (Status == RunStatus.Finished)
        {
            return Result.Failure(RunErrors.RunAlreadyFinished(Id));
        }

        FinishedOn = DateTime.UtcNow;
        Duration = FinishedOn - StartedOn;
        Status = RunStatus.Finished;

        RaiseDomainEvent(new RunFinishedDomainEvent(Id, UserId));

        return Result.Success();
    }

    public Result Cancel()
    {
        if (Status == RunStatus.Finished)
        {
            return Result.Failure(RunErrors.RunAlreadyFinished(Id));
        }

        if (Status == RunStatus.Cancelled)
        {
            return Result.Failure(RunErrors.RunAlreadyCancelled(Id));
        }

        StartedOn = null;
        Status = RunStatus.Cancelled;

        return Result.Success();
    }


}
