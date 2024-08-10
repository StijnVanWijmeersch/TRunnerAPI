using Microsoft.EntityFrameworkCore;
using TRunner.Modules.Groups.Domain.Runners;
using TRunner.Modules.Groups.Infrastructure.Database;

namespace TRunner.Modules.Groups.Infrastructure.Runners;
public sealed class RunnerRepository(GroupsDbContext context) : IRunnerRepository
{
    public async Task<Runner?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Runners.SingleOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
}
