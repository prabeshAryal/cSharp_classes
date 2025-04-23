using OurNotificationAPP.Models;
using OurNotificationAPP.Services.Interfaces;
using System;

namespace OurNotificationAPP.Services
{
    public class NotificationFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public INotificationService GetNotificationService(NotificationPreference preference)
        {
            return preference switch
            {
                NotificationPreference.Email => (INotificationService)_serviceProvider.GetService(typeof(EmailNotificationService)),
                NotificationPreference.SMS => (INotificationService)_serviceProvider.GetService(typeof(SmsNotificationService)),
                _ => throw new ArgumentException("Invalid notification preference")
            };
        }
    }
}