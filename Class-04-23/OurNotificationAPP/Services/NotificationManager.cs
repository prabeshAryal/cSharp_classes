using OurNotificationAPP.Services.Interfaces;
using System;

namespace OurNotificationAPP.Services
{
    public class NotificationManager
    {
        private readonly INotificationService _notificationService;

        // Constructor injection
        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public void Notify(string message)
        {
            _notificationService.SendNotification(message);
        }
    }
}