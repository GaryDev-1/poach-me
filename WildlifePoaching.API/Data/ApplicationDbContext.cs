using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Models.Domain.Animals;
using WildlifePoaching.API.Models.Domain;
using System.Reflection;
using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,ILogger<ApplicationDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalImage> AnimalImages { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Tiger> Tigers { get; set; }
        public DbSet<Fish> Fish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            entry.Entity.IsDeleted = false;
                            break;

                        case EntityState.Modified:
                            entry.Entity.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during SaveChangesAsync");
                throw;
            }
        }
    }
}
