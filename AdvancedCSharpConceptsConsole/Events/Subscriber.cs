using System;
using AdvancedCSharpConceptsConsole.Models;

namespace AdvancedCSharpConceptsConsole.Events
{
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
}
