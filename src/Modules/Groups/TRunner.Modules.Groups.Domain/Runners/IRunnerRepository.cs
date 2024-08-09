namespace TRunner.Modules.Groups.Domain.Runners;
public interface IRunnerRepository
{
    Task<Runner?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
