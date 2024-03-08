using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRoleEntity>( // таблица для М-М
                    leftEntity => leftEntity.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                    rightEntity => rightEntity.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.UserId));
        }
    }
}
