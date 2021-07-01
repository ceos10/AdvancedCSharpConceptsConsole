using System;

namespace AdvancedCSharpConceptsConsole.Events
{
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
            // Event will be null if there are no subscribers
            if (RaiseCustomEvent != null)
            {
                e.Message += $" at {DateTime.Now}";

                // Call to raise the event
                RaiseCustomEvent.Invoke(this, e);
            }
        }
    }
}
