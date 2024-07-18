using TRunner.Domain.Badges;
using TRunner.Domain.Users;

namespace TRunner.Domain.JoinTables;
public sealed class UserBadge
{
    public Guid BadgeId { get; set; }
    public Guid UserId { get; set; }

    // Navigational properties
    public Badge Badge { get; set; }
    public User User { get; set; }

    public UserBadge(Guid badgeId, Guid userId)
    {
        BadgeId = badgeId;
        UserId = userId;
    }
}
