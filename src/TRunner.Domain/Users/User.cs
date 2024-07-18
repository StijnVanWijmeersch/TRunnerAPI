using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Users;

public sealed class User : Entity
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string LastName { get; private set; }
    public string FirstName { get; private set; }
    public string Email { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string HashedPassword { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private User() { }

    public static Result<User> Create(string userName, string lastName, string firstName, string email, string hashedPassword)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            LastName = lastName,
            FirstName = firstName,
            Email = email,
            EmailConfirmed = false,
            HashedPassword = hashedPassword
        };

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public Result UpdatePassword(string newHashedPassword)
    {
        HashedPassword = newHashedPassword;
        return Result.Success();
    }

    public Result UpdateUserName(string newUserName)
    {
        UserName = newUserName;
        return Result.Success();
    }

    public Result UpdateEmail(string newEmail)
    {
        Email = newEmail;
        EmailConfirmed = false;

        RaiseDomainEvent(new UserEmailChangedDomainEvent(Id, Email));

        return Result.Success();
    }

}
