namespace TRunner.Modules.Groups.Domain.Runners;
public interface IMemberRepository
{
    Task<Member?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
