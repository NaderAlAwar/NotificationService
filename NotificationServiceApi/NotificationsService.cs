using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace NotificationServiceApi
{
    public class NotificationsService
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IQueueClient queueClient;

        public NotificationsService(IHubContext<NotificationHub> hubContext, IQueueClient queueClient)
        {
            this.hubContext = hubContext;
            this.queueClient = queueClient;
            queueClient.RegisterMessageHandler(PostNotification, ExceptionReceivedHandler);
        }

        public async Task PostNotification(Message message, CancellationToken token)
        {
            string body = Encoding.UTF8.GetString(message.Body);
            NotificationPayload notificationPayload = JsonConvert.DeserializeObject<NotificationPayload>(body);
            foreach (var username in notificationPayload.Users)
            {
                await hubContext.Clients.Group(username).SendAsync("ReceiveNotification", notificationPayload);
            }
        }

        //TODO: Need to log this
        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }

    }
}
