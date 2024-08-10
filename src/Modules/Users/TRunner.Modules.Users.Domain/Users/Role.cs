namespace TRunner.Modules.Users.Domain.Users;
public sealed class Role
{
    public static readonly Role Administator = new ("Administrator");
    public static readonly Role User = new ("User");

    public string Name { get; private set; }

    private Role() { }

    private Role(string name)
    {
        Name = name;
    }
}
