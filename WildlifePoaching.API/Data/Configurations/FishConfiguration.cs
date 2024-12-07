using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain.Animals;

namespace WildlifePoaching.API.Data.Configurations
{
    public class FishConfiguration : IEntityTypeConfiguration<Fish>
    {
        public void Configure(EntityTypeBuilder<Fish> builder)
        {
            builder.Property(e => e.Species)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.WaterType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.OptimalTemperature)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => e.Species);
            builder.HasIndex(e => e.WaterType);
        }
    }
}
