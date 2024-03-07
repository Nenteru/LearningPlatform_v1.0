namespace LearningPlatform.Application.Interfaces.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string passwordHash);
        bool Verify(string password, string hashedPassword);
    }
}