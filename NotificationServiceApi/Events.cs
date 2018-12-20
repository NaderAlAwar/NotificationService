using Microsoft.Extensions.Logging;

namespace NotificationServiceApi
{
    public static class Events
    {
        public static readonly EventId ServiceBusException = CreateEvent(nameof(ServiceBusException));
        private static EventId CreateEvent(string eventName)
        {
            return new EventId(0, eventName);
        }
    }
}
