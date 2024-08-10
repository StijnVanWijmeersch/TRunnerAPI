using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public sealed class Runner : Entity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public int Score { get; set; }

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
