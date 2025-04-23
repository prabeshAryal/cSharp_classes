using System;
using System.Collections.Generic;
using System.Linq;
using OurNotificationAPP.Models;

namespace OurNotificationAPP.Services
{
    public class NotificationLogService
    {
        // In-memory storage for demo purposes
        private static readonly List<NotificationLogEntry> _notificationLog = new List<NotificationLogEntry>();
        private static int _nextId = 1;

        private readonly ILogger<NotificationLogService> _logger;

        public NotificationLogService(ILogger<NotificationLogService> logger)
        {
            _logger = logger;
        }

        public void LogNotification(string message, NotificationPreference type, string recipient = "demo@example.com")
        {
            var entry = new NotificationLogEntry
            {
                Id = _nextId++,
                Message = message,
                NotificationType = type,
                Recipient = recipient,
                SentTime = DateTime.Now,
                IsSuccessful = true
            };

            _notificationLog.Add(entry);
            _logger.LogInformation($"Notification logged: {type} to {recipient}");
        }

        public List<NotificationLogEntry> GetRecentNotifications(int count = 10)
        {
            return _notificationLog
                .OrderByDescending(n => n.SentTime)
                .Take(count)
                .ToList();
        }

        public List<NotificationLogEntry> GetAllNotifications()
        {
            return _notificationLog
                .OrderByDescending(n => n.SentTime)
                .ToList();
        }

        public void ClearLogs()
        {
            _notificationLog.Clear();
            _nextId = 1;
        }
    }
}