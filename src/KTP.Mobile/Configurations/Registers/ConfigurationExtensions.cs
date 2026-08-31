using Microsoft.Extensions.Configuration;

namespace KTP.Configurations.Registers;

internal static class ConfigurationExtensions
{
    extension(IServiceCollection services)
    {
        public void AddOptions<TOptions>(IConfiguration configuration, string sectionName) where TOptions : class
        {
            services.Configure<TOptions>(configuration.GetSection(sectionName));
        }

        public TOptions GetOptions<TOptions>() where TOptions : class
        {
            return services.BuildServiceProvider().GetRequiredService<TOptions>();
        }
    }
}
