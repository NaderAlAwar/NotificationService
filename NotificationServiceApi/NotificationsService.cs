using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NotificationServiceApi
{
    public class NotificationsService
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IQueueClient queueClient;
        private readonly ILogger<NotificationsService> logger;

        public NotificationsService(IHubContext<NotificationHub> hubContext, IQueueClient queueClient, ILogger<NotificationsService> logger)
        {
            this.hubContext = hubContext;
            this.queueClient = queueClient;
            this.logger = logger;
            queueClient.RegisterMessageHandler(PostNotification, ExceptionReceivedHandler);
        }

        public async Task PostNotification(Message message, CancellationToken token)
        {
            string body = Encoding.UTF8.GetString(message.Body);
            NotificationPayload notificationPayload = JsonConvert.DeserializeObject<NotificationPayload>(body);
            foreach (var username in notificationPayload.Users)
            {
                await hubContext.Clients.Group(username).SendAsync("ReceiveNotification", notificationPayload, token);
            }
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            logger.LogError(Events.ServiceBusException, exceptionReceivedEventArgs.Exception, "Message handler encountered an exception");
            return Task.CompletedTask;
        }

    }
}
