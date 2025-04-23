using System;

namespace OurNotificationAPP.Services.Interfaces
{
    public interface INotificationService
    {
        void SendNotification(string message);
    }
}