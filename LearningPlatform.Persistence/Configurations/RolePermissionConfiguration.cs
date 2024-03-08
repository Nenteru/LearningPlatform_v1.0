

using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistence.Configurations
{
    public partial class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
    {
        public RolePermissionConfiguration(AuthorizationOptions authorization)
        {
            
        }
        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            // дописать
        }
    }
}
