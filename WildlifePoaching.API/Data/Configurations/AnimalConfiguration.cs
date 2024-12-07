using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;
using WildlifePoaching.API.Models.Domain.Animals;

namespace WildlifePoaching.API.Data.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animals");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.AcquisitionDate)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Indexes
            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.AnimalTypeId);
            builder.HasIndex(e => e.LocationId);
            builder.HasIndex(e => e.AcquisitionDate);
            builder.HasIndex(e => e.IsDeleted);

            // Relationships
            builder.HasOne(e => e.StolenFrom)
                .WithMany(l => l.Animals)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Type)
                .WithMany(t => t.Animals)
                .HasForeignKey(e => e.AnimalTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Discriminator for TPH (Table Per Hierarchy)
            builder.HasDiscriminator<string>("AnimalType")
                .HasValue<Dog>("Dog")
                .HasValue<Tiger>("Tiger")
                .HasValue<Fish>("Fish");
        }
    }
}
