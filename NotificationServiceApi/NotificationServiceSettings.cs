using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationServiceApi
{
    public class NotificationServiceSettings
    {
        public string ServiceBusConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
