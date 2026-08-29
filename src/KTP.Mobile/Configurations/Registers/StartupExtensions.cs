using KTP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KTP.Configurations.Registers;

internal static class StartupExtensions
{
    extension(MauiAppBuilder builder)
    {
        internal MauiAppBuilder AddConfiguration()
        {
            using var baseStream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
            builder.Configuration.AddJsonStream(baseStream)
                .Build();

            var envFile = $"appsettings.{builder.Environment.EnvironmentName}.json";
            try
            {
                using var envStream = FileSystem.OpenAppPackageFileAsync(envFile).Result;
                builder.Configuration
                    .AddJsonStream(baseStream)
                    .AddJsonStream(envStream)  // Environment file overrides base
                    .Build();
            }
            catch
            {
                // Environment file not found, use base only
            }

            return builder;
        }
    }

    extension(MauiApp app)
    {
        internal void InitializeDatabase()
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database initialization error: {ex.Message}");
            }
        }
    }
}
