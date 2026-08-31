using KTP.Configurations.Options;
using KTP.Infrastructure.Events;
using KTP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KTP.Configurations.Registers;

internal static class RegisterInfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        public void RegisterInfrastructure(IConfiguration configuration)
        {
            // Register the KTP.Infrastructure services
            services.RegisterServices();
            services.RegisterEvents();
            services.RegisterDbContext(configuration);
        }

        private void RegisterServices()
        {
        }

        private void RegisterEvents()
        {
            services.AddSingleton<IEventHandlerRegistry, EventHandlerRegistry>();
            services.AddSingleton<IEventBus, EventBus>();
        }

        private void RegisterDbContext(IConfiguration configuration)
        {
            var databaseOptions = configuration.GetConnectionString(DatabaseOptions.CONNECTION_STRING_KEY) 
                ?? throw new InvalidOperationException("Connection string not found");
            var connectionString = string.Format(databaseOptions, FileSystem.AppDataDirectory);

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
        }
    }
}
