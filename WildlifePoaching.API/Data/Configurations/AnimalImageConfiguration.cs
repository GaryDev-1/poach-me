using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Configurations
{
    public class AnimalImageConfiguration : IEntityTypeConfiguration<AnimalImage>
    {
        public void Configure(EntityTypeBuilder<AnimalImage> builder)
        {
            builder.ToTable("AnimalImages");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FileSize)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => e.AnimalId);
            builder.HasIndex(e => e.IsPrimary);

            // Relationships
            builder.HasOne(e => e.Animal)
                .WithMany(a => a.Images)
                .HasForeignKey(e => e.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
