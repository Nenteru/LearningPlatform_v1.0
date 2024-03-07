

namespace LearningPlatform.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;

        private User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public static User Create(Guid id, string userName, string passwordHash, string email)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passwordHash))
            {
                throw new Exception("not valid params by User");
            }

            return new User(id, userName, passwordHash, email);
        }
    }
}
