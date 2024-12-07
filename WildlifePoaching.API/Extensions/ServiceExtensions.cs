using Polly;
using Polly.Extensions.Http;
using WildlifePoaching.API.Data.Repositories.Implementations;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Services.Implementations;
using WildlifePoaching.API.Services.Interfaces;
using WildlifePoaching.API.Services.Policies;

namespace WildlifePoaching.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Get logger factory
            var serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("HttpClient");

            // Add Repositories
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IAnimalImageRepository, AnimalImageRepository>();
            services.AddScoped<IAnimalTypeRepository, AnimalTypeRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            // Add Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITransactionService, TransactionService>();

            // HTTP Client with Polly
            services.AddHttpClient("DefaultClient")
                .AddPolicyHandler(PollyPolicies.GetCombinedPolicy(logger));

            return services;
        }

    }
}
