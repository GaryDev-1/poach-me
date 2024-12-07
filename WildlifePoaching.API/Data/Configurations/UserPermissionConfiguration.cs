using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Configurations
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UserPermissions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Permission)
                .IsRequired()
                .HasMaxLength(100);

            // Indexes
            builder.HasIndex(e => e.RoleId);
            builder.HasIndex(e => new { e.RoleId, e.Permission }).IsUnique();

            // Relationships
            builder.HasOne(e => e.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
