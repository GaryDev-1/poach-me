using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.TransactionDate)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => e.AnimalId);
            builder.HasIndex(e => e.UserId);
            builder.HasIndex(e => e.TransactionDate);
            builder.HasIndex(e => e.Status);

            // Relationships
            builder.HasOne(e => e.Animal)
                .WithMany(a => a.Transactions)
                .HasForeignKey(e => e.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
