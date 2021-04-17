using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AdvancedCSharpConceptsConsole.Logic;

namespace AdvancedCSharpConceptsConsole
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        private static AppSettings _appSettings;
        protected static AppSettings AppSettings
        {
            get { return _appSettings ??= _serviceProvider.GetService<AppSettings>(); }
        }

        private static ILogger<Program> _logger;

        protected static ILogger<Program> Logger
        {
            get { return _logger ??= _serviceProvider.GetService<ILogger<Program>>(); }
        }

        private static async Task Main(string[] args)
        {
            try
            {
                var parameter = args.Length < 1 ? "DELEGATES" : args[0];

                var services = Startup.ConfigureServices(parameter);
                _serviceProvider = services.BuildServiceProvider();

                switch (parameter.ToUpper())
                {
                    case ("DELEGATES"):
                        var service1 = _serviceProvider.GetService<Delegates>();
                        service1.RunDelegateExample();
                        break;
                    case ("LINQ"):
                        var service2 = _serviceProvider.GetService<Linq>();
                        await service2.CallStoredProcedure();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }

            Console.WriteLine("Batch Done");
        }
    }
}
