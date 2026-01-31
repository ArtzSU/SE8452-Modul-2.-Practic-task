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