

namespace LearningPlatform.Persistence.Entities
{
    public class LessonEntity
    {
        public Guid Id { get; set; }
        public string Theme { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public Guid CourseId { get; set; }
        public CourseEntity? Course { get; set; }
    }
}
