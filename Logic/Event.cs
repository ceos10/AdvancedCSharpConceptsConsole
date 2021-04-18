using System;
using System.Collections.Generic;
using System.Threading;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    // Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    // Class that publishes an event
    public class Publisher
    {
        // Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void SendNotification()
        {
            OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                e.Message += $" at {DateTime.Now}";

                // Call to raise the event.
                raiseEvent(this, e);
            }
        }
    }

    //Class that subscribes to an event
    public class Subscriber
    {
        private readonly Employee _employee;

        public Subscriber(Employee employee, Publisher publisher)
        {
            _employee = employee;

            // Subscribe to the event
            publisher.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"{_employee.Name} received this message: {e.Message}");
        }
    }
    public class Event : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Event(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunEventExample()
        {
            List<Employee> employees = _employeeRepository.GetEmployees();

            var publisher = new Publisher();
            int i = 1;

            foreach (var e in employees)
            {
                Console.WriteLine($"Cycle n° {i}");
                new Subscriber(e, publisher);
                Thread.Sleep(100);
                publisher.SendNotification();
                i++;
            }

            // Keep the console window open
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
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
