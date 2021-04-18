using System.IO;
using AdvancedCSharpConceptsConsole.Logic;
using AdvancedCSharpConceptsConsole.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvancedCSharpConceptsConsole
{
    internal static class Startup
    {
        internal static IServiceCollection ConfigureServices(string parameter)
        {
            var services = new ServiceCollection();

            var configuration = CreateConfiguration();
            services.AddConfigurationSettings(configuration);

            services.AddLogging(c =>
            {
                c.AddConfiguration(configuration.GetSection("Logging"));
                c.AddConsole();
            });

            services.AddHttpClient();

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            switch (parameter)
            {
                case "DELEGATES":
                    services.AddSingleton<Delegates>();
                    break;

                case "EVENT":
                    services.AddSingleton<Event>();
                    break;

                case "ANONYMOUSTYPE":
                    services.AddSingleton<AnonymousType>();
                    break;
            }

            return services;
        }

        private static IConfigurationRoot CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            return builder.Build();
        }

        private static void AddConfigurationSettings(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var appSettings = new AppSettings();
            configuration.Bind("appSettings", appSettings);
            services.AddSingleton(appSettings);
        }
    }
}
