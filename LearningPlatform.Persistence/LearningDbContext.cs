using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence
{
    public class LearningDbContext : DbContext
    {
        public LearningDbContext(DbContextOptions<LearningDbContext> options)
            : base(options)
        {
        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
