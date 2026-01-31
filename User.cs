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