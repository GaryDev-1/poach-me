using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain.Animals;

namespace WildlifePoaching.API.Data.Configurations
{
    public class TigerConfiguration : IEntityTypeConfiguration<Tiger>
    {
        public void Configure(EntityTypeBuilder<Tiger> builder)
        {
            builder.Property(e => e.Subspecies)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsWild)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => e.Subspecies);
        }
    }
}
