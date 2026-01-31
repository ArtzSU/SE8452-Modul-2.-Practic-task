
public enum Role
{
    Admin,
    User,
    Guest
}

public class User
{
    // Если пользователь является гостем, nickname и email могут быть null
    public Guid UserId { get; } = Guid.NewGuid();
    public string? Nickname { get; private set; }
    public string? Email { get; private set; }
    public Role Role { get; set; }

    public User(string nickname, string email, Role role)
    {
        if (role == Role.Guest)
            throw new ArgumentException("Guest must use the Guest constructor");

        Nickname = nickname;
        Email = email;
        Role = role;
    }
    
    public User(Role role)
    {
        if (role != Role.Guest)
            throw new ArgumentException("Only Guest can use this constructor");

        Nickname = null;
        Email = null;
        Role = role;
    }
}


public class UserManager
{
    private List<User> Users = new List<User>();

    private User? FindUserById(Guid userId) =>
        Users.FirstOrDefault(u => u.UserId == userId);

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void UpdateUserRole(Guid userId, Role newRole)
    {
        var user = FindUserById(userId);
        if (user != null)
            user.Role = newRole;
    }

    public void RemoveUser(Guid userId)
    {
        var user = FindUserById(userId);
        if (user != null)
            Users.Remove(user);
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        User user1 = new User("john_doe", "john@example.com", Role.User);
        User user2 = new User("admin_user", "admin@example.com", Role.Admin);
        User user3 = new User(Role.Guest);
        userManager.AddUser(user1);
        userManager.AddUser(user2);
        userManager.AddUser(user3);
        userManager.UpdateUserRole(user1.UserId, Role.Admin);
        userManager.RemoveUser(user2.UserId);
        userManager.RemoveUser(user3.UserId);

        Console.WriteLine(user1.Role); // Output: Admin
    }
}