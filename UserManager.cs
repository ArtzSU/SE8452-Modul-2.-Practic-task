namespace UserManagerSystem
{
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
}