using LearningPlatform.Persistence.Configurations;
using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LearningPlatform.Persistence
{
    public class LearningDbContext : DbContext
    {
        private readonly IOptions<AuthorizationOptions> _authOptions;

        public LearningDbContext(
            DbContextOptions<LearningDbContext> options,
            IOptions<AuthorizationOptions> authOptions)
            : base(options)
        {
            _authOptions = authOptions;
        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LearningDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authOptions.Value));
        }

    }
}
