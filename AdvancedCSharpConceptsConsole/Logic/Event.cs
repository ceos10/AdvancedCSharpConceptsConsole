using System;
using System.Threading;
using AdvancedCSharpConceptsConsole.Events;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class Event : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Event(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunEventExample()
        {
            var employees = _employeeRepository.GetEmployees();

            var publisher = new Publisher();
            int i = 1;

            foreach (var employee in employees)
            {
                Console.WriteLine($"Cycle n° {i}");
                new Subscriber(employee, publisher);
                Thread.Sleep(100);
                publisher.SendNotification();
                i++;
            }

            // Keep the console window open
            Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
    }
}
