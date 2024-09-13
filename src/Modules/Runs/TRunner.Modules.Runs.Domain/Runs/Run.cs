using TRunner.Common.Domain;

namespace TRunner.Modules.Runs.Domain.Runs;

public sealed class Run : Entity
{
    public Guid Id { get; private set; }
    public Guid RunnerId { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public double? Distance { get; private set; }
    public TimeSpan? Duration { get; private set; }
    public RunStatus Status { get; private set; }

    private Run() { }

    public static Run Create(Guid runnerId, DateTime startedAt)
    {
        var run = new Run
        {
            Id = Guid.NewGuid(),
            RunnerId = runnerId,
            StartedAt = startedAt,
            Status = RunStatus.InProgress
        };

        return run;
    }


}
