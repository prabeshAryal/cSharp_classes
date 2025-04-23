using System;
using OurNotificationAPP.Models;

namespace OurNotificationAPP.Models
{
    public class NotificationLogEntry
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public NotificationPreference NotificationType { get; set; }
        public DateTime SentTime { get; set; }
        public string Recipient { get; set; }
        public bool IsSuccessful { get; set; }

        public NotificationLogEntry()
        {
            SentTime = DateTime.Now;
            IsSuccessful = true;
        }
    }
}