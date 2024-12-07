using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Models.Domain;
using WildlifePoaching.API.Models.Domain.Animals;
using WildlifePoaching.API.Models.Enums;

namespace WildlifePoaching.API.Data.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
                await SeedRolesAsync(context);

            if (!context.Users.Any())
                await SeedUsersAsync(context);

            if (!context.AnimalTypes.Any())
                await SeedAnimalTypesAsync(context);

            if (!context.Locations.Any())
                await SeedLocationsAsync(context);

            if (!context.UserPermissions.Any())
                await SeedPermissionsAsync(context);

            if (!context.Animals.Any())
                await SeedSampleAnimalsAsync(context);

            if (!context.Transactions.Any())
                await SeedSampleTransactionsAsync(context);

            if (!context.AnimalImages.Any())
                await SeedAnimalImagesAsync(context);
        }

        private static async Task SeedRolesAsync(ApplicationDbContext context)
        {
            var roles = new List<Role>
        {
            new Role { Name = "Admin", Description = "Administrator" },
            new Role { Name = "User", Description = "Standard User" },
            new Role { Name = "Manager", Description = "Manager" },
            new Role { Name = "Viewer", Description = "Standard Viewer" }
        };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        private static async Task SeedUsersAsync(ApplicationDbContext context)
        {
            var adminRole = await context.Roles.FirstAsync(r => r.Name == "Admin");

            var adminUser = new User
            {
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Salt = Guid.NewGuid().ToString(),
                RoleId = adminRole.Id,
                Status = UserStatus.Active
            };

            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAnimalTypesAsync(ApplicationDbContext context)
        {
            var animalTypes = new List<AnimalType>
        {
            new AnimalType
            {
                Name = "Dog",
                Category = "Domestic",
                SpecialRequirements = "Regular exercise, vaccinations required"
            },
            new AnimalType
            {
                Name = "Tiger",
                Category = "Wild",
                SpecialRequirements = "Secure facility, specialized care, meat diet"
            },
            new AnimalType
            {
                Name = "Fish",
                Category = "Aquatic",
                SpecialRequirements = "Temperature controlled environment, specific water conditions"
            }
        };

            await context.AnimalTypes.AddRangeAsync(animalTypes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAnimalImagesAsync(ApplicationDbContext context)
        {
            var animals = await context.Animals.ToListAsync();
            var images = new List<AnimalImage>();

            foreach (var animal in animals)
            {
                images.Add(new AnimalImage
                {
                    AnimalId = animal.Id,
                    FilePath = $"/uploads/animals/{animal.Id}/primary.jpg",
                    FileName = "primary.jpg",
                    ContentType = "image/jpeg",
                    FileSize = 1024 * 1024, // 1MB placeholder
                    IsPrimary = true,
                    UploadedAt = DateTime.UtcNow
                });
            }

            await context.AnimalImages.AddRangeAsync(images);
            await context.SaveChangesAsync();
        }

        private static async Task SeedLocationsAsync(ApplicationDbContext context)
        {
            var locations = new List<Location>
        {
            new Location
            {
                Name = "Central Zoo",
                Latitude = 40.7829f,
                Longitude = -73.9654f,
                Country = "USA",
                City = "New York",
                SecurityLevel = 1
            },
            new Location
            {
                Name = "Wildlife Park",
                Latitude = 51.5074f,
                Longitude = -0.1278f,
                Country = "UK",
                City = "London",
                SecurityLevel = 2
            }
        };

            await context.Locations.AddRangeAsync(locations);
            await context.SaveChangesAsync();
        }

        private static async Task SeedPermissionsAsync(ApplicationDbContext context)
        {
            var adminRole = await context.Roles.FirstAsync(r => r.Name == "Admin");
            var permissions = new List<UserPermission>
            {
                new UserPermission { RoleId = adminRole.Id, Permission = "Animals.Create" },
                new UserPermission { RoleId = adminRole.Id, Permission = "Animals.Read" },
                new UserPermission { RoleId = adminRole.Id, Permission = "Animals.Update" },
                new UserPermission { RoleId = adminRole.Id, Permission = "Animals.Delete" },
                new UserPermission { RoleId = adminRole.Id, Permission = "Users.Manage" }
            };

            await context.UserPermissions.AddRangeAsync(permissions);
            await context.SaveChangesAsync();
        }

        private static async Task SeedSampleAnimalsAsync(ApplicationDbContext context)
        {
            var dogType = await context.AnimalTypes.FirstAsync(t => t.Name == "Dog");
            var tigerType = await context.AnimalTypes.FirstAsync(t => t.Name == "Tiger");
            var fishType = await context.AnimalTypes.FirstAsync(t => t.Name == "Fish");
            var location = await context.Locations.FirstAsync();

            var animals = new List<Animal>
            {
                new Dog
                {
                    Name = "Max",
                    Price = 1000M,
                    AcquisitionDate = DateTime.UtcNow.AddDays(-30),
                    LocationId = location.Id,
                    AnimalTypeId = dogType.Id,
                    Status = AnimalStatus.Available.ToString(),
                    Description = "German Shepherd",
                    Breed = "German Shepherd",
                    IsTrainable = true
                },
                new Tiger
                {
                    Name = "Raja",
                    Price = 50000M,
                    AcquisitionDate = DateTime.UtcNow.AddDays(-60),
                    LocationId = location.Id,
                    AnimalTypeId = tigerType.Id,
                    Status = AnimalStatus.Available.ToString(),
                    Description = "Bengal Tiger",
                    Subspecies = "Bengal",
                    IsWild = true
                },
                new Fish
                {
                    Name = "Nemo",
                    Price = 100M,
                    AcquisitionDate = DateTime.UtcNow.AddDays(-15),
                    LocationId = location.Id,
                    AnimalTypeId = fishType.Id,
                    Status = AnimalStatus.Available.ToString(),
                    Description = "Clownfish",
                    Species = "Clownfish",
                    WaterType = "Saltwater",
                    OptimalTemperature = 25.5f
                }
            };

            await context.Animals.AddRangeAsync(animals);
            await context.SaveChangesAsync();
        }

        private static async Task SeedSampleTransactionsAsync(ApplicationDbContext context)
        {
            var user = await context.Users.FirstAsync();
            var animal = await context.Animals.FirstAsync();

            var transactions = new List<Transaction>
        {
            new Transaction
            {
                AnimalId = animal.Id,
                UserId = user.Id,
                TransactionType = TransactionType.Purchase,
                Amount = animal.Price,
                Status = "Completed",
                TransactionDate = DateTime.UtcNow.AddDays(-7),
                CreatedById = user.Id
            }
        };

            await context.Transactions.AddRangeAsync(transactions);
            await context.SaveChangesAsync();
        }
    }
}
