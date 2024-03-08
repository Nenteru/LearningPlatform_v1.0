using LearningPlatform.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace LearningPlatform.Infrastructure.Authentication
{
    // требование на разрешение
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission[] permissions)
        {
            Permissions = permissions;
        }
        public Permission[] Permissions { get; set; } = [];
    }
}
