using OurNotificationAPP.Services.Interfaces;
using OurNotificationAPP.Models;
using System;

namespace OurNotificationAPP.Services
{
    public class SmsNotificationService : INotificationService
    {
        private readonly ILogger<SmsNotificationService> _logger;
        private readonly NotificationLogService _logService;

        public SmsNotificationService(
            ILogger<SmsNotificationService> logger,
            NotificationLogService logService)
        {
            _logger = logger;
            _logService = logService;
        }

        public void SendNotification(string message)
        {
            // In a real application, this would send an actual SMS
            _logger.LogInformation($"SMS NOTIFICATION: {message}");

            // Log the notification for demo purposes
            _logService.LogNotification(
                message,
                NotificationPreference.SMS,
                "+1234567890"
            );

            // Simulate SMS sending
            Console.WriteLine($"Sending SMS notification: {message}");
        }
    }
}