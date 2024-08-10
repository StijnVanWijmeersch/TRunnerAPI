using TRunner.Common.Domain;

namespace TRunner.Modules.Users.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];

    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string IdentityId { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles.ToList();

    public static User Create(string userName, string email, string identityId)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            Email = email,
            IdentityId = identityId
        };

        user._roles.Add(Role.User);

        user.RaiseDomainEvent(new UserRegisteredDomainEvent(user.Id));

        return user;
    }
}
