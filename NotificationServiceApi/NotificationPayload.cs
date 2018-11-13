﻿using System;

namespace NotificationServiceApi
{
    public class NotificationPayload
    {
        public NotificationPayload(DateTime utcTime, string type, string conversationId)
        {
            this.utcTime = utcTime;
            this.type = type;
            this.conversationId = conversationId;
        }
        public DateTime utcTime { get; set; }
        public string type { get; set; }
        public string conversationId { get; set; }
    }
}