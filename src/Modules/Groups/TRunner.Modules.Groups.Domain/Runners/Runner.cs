using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Runners;
public sealed class Runner : Entity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public int Score { get; set; }
}
