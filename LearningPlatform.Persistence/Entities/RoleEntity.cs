

namespace LearningPlatform.Persistence.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // набор разрешений
        public ICollection<PermissionEntity> Permissions { get; set; } = [];

        public ICollection<UserEntity> Users { get; set; } = [];
    }
}
