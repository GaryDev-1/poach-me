using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.RefreshToken)
                .IsRequired(false)
                .HasMaxLength(500);

            // Indexes
            builder.HasIndex(e => e.Username).IsUnique()
                .HasFilter("[IsDeleted] = 0");
            builder.HasIndex(e => e.Email).IsUnique()
                .HasFilter("[IsDeleted] = 0");
            builder.HasIndex(e => e.RefreshToken);
            builder.HasIndex(e => e.Status);

            // Relationships
            builder.HasOne(e => e.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
