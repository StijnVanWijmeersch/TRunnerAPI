using Microsoft.EntityFrameworkCore;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Infrastructure.Database;

namespace TRunner.Modules.Groups.Infrastructure.Groups;
public sealed class GroupRepository(GroupsDbContext context) : IGroupRepository
{
    public async Task<Group?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Groups.SingleOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public void Insert(Group group)
    {
        context.Groups.Add(group);
    }

    public void Remove(Group group)
    {
        context.Groups.Remove(group);
    }
}
