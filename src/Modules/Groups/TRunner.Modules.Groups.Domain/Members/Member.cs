using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public sealed class Member : Entity
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public int Score { get; private set; }

    private Member() { }

    public static Member Create(Guid id, string userName, int score)
    {
        return new Member
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

        RaiseDomainEvent(new MemberScoreChangedDomainEvent(Id, score));
    }
}
