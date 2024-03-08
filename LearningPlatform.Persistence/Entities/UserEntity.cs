

namespace LearningPlatform.Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<CourseEntity> Courses { get; set; } = [];

        // коллекция ролей нужна на случай нескольких ролей у пользователя
        public ICollection<RoleEntity> Roles { get; set; } = [];
    }
}
