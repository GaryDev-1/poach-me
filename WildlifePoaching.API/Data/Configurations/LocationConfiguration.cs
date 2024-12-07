using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.SecurityLevel)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => new { e.Latitude, e.Longitude });
            builder.HasIndex(e => e.Country);
            builder.HasIndex(e => e.City);
            builder.HasIndex(e => e.SecurityLevel);
        }
    }
}
