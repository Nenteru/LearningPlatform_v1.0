using LearningPlatform.Core.Models;

namespace LearningPlatform.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}