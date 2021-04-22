using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AdvancedCSharpConceptsConsole.Logic;
using Action = AdvancedCSharpConceptsConsole.Logic.Action;

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
                    case ("ANONYMOUSMETHOD"):
                        var service2 = _serviceProvider.GetService<AnonymousMethod>();
                        service2.RunAnonymusMethodExample();
                        break;
                    case ("FUNC"):
                        var service3 = _serviceProvider.GetService<Func>();
                        service3.RunFuncExample();
                        break;
                    case ("ACTION"):
                        var service4 = _serviceProvider.GetService<Action>();
                        service4.RunActionExample();
                        break;
                    case ("EVENT"):
                        var service5 = _serviceProvider.GetService<Event>();
                        service5.RunEventExample();
                        break;
                    case ("ANONYMOUSTYPE"):
                        var service6 = _serviceProvider.GetService<AnonymousType>();
                        service6.RunAnonymousTypeExample();
                        break;
                    case ("LAMBDA"):
                        var service7 = _serviceProvider.GetService<LambdaExpression>();
                        service7.RunLambdaExample();
                        break;
                    case ("LINQ"):
                        var service8 = _serviceProvider.GetService<Linq>();
                        service8.RunLinqExample();
                        break;
                    case ("EXTENSIONMETHOD"):
                        var service9 = _serviceProvider.GetService<ExtensionMethod>();
                        service9.RunExtensionMethodExample();
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
