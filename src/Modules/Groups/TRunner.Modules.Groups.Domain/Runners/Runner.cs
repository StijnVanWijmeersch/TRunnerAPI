using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public sealed class Runner : Entity
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public int Score { get; private set; }

    private Runner() { }

    public static Runner Create(Guid id, string userName, int score)
    {
        return new Runner
        {
            Id = id,
            UserName = userName,
            Score = score
        };
    }

    public void UpdateUserName(string userName)
    {
        UserName = userName;
    }

    public void UpdateScore(int score)
    {
        Score = score;

        RaiseDomainEvent(new RunnerScoreChangedDomainEvent(Id, score));
    }
}
