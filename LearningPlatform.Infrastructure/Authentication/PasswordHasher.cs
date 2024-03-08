using LearningPlatform.Application.Interfaces.Auth;

namespace LearningPlatform.Infrastructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string passwordHash) =>
            BCrypt.Net.BCrypt.HashPassword(passwordHash);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
