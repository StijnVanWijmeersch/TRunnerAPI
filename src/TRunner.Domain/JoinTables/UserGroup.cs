using System.Text.RegularExpressions;
using TRunner.Domain.Users;

namespace TRunner.Domain.JoinTables;
public sealed class UserGroup
{
    public Guid UserId { get; init; }
    public Guid GroupId { get; init; }

    // Navigational properties
    public User User { get; init; }
    public Group Group { get; init; }

    public UserGroup(Guid userId, Guid groupId)
    {
        UserId = userId;
        GroupId = groupId;
    }
}
