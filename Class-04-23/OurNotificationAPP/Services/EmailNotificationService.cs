using OurNotificationAPP.Services.Interfaces;
using OurNotificationAPP.Models;
using System;

namespace OurNotificationAPP.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;
        private readonly NotificationLogService _logService;

        public EmailNotificationService(
            ILogger<EmailNotificationService> logger,
            NotificationLogService logService)
        {
            _logger = logger;
            _logService = logService;
        }

        public void SendNotification(string message)
        {
            // In a real application, this would send an actual email
            _logger.LogInformation($"EMAIL NOTIFICATION: {message}");

            // Log the notification for demo purposes
            _logService.LogNotification(
                message,
                NotificationPreference.Email,
                "demo@example.com"
            );

            // Simulate email sending
            Console.WriteLine($"Sending EMAIL notification: {message}");
        }
    }
}