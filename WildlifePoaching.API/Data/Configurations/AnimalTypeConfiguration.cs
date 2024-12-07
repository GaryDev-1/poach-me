using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Configurations
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.ToTable("AnimalTypes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.SpecialRequirements)
                .HasMaxLength(500);

            // Indexes
            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.Category);
        }
    }
}
