using System;

namespace NotificationServiceApi
{
    public class NotificationPayload
    {
        public NotificationPayload(DateTime utcTime, string type, string conversationId)
        {
            UtcTime = utcTime;
            Type = type;
            ConversationId = conversationId;
        }
        public DateTime UtcTime { get; set; }
        public string Type { get; set; }
        public string ConversationId { get; set; }
    }
}