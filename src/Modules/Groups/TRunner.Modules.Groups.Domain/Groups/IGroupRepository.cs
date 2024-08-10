namespace TRunner.Modules.Groups.Domain.Groups;
public interface IGroupRepository
{
    Task<Group?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Group group);
    void Remove(Group group);
}
