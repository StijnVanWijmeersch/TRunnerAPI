using Microsoft.EntityFrameworkCore;
using TRunner.Modules.Groups.Domain.Runners;
using TRunner.Modules.Groups.Infrastructure.Database;

namespace TRunner.Modules.Groups.Infrastructure.Runners;
public sealed class MemberRepository(GroupsDbContext context) : IMemberRepository
{
    public async Task<Member?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Members.SingleOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
}
