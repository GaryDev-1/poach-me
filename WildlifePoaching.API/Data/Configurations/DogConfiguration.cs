using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain.Animals;

namespace WildlifePoaching.API.Data.Configurations
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.Property(e => e.Breed)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsTrainable)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => e.Breed);
        }
    }
}
