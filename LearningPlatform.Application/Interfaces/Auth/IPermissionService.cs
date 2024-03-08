using LearningPlatform.Core.Enums;

namespace LearningPlatform.Infrastructure.Authentication
{
    public interface IPermissionService
    {
        Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}