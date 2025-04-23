using System.ComponentModel.DataAnnotations;

namespace OurNotificationAPP.Models
{
    public class NotificationViewModel
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public NotificationPreference NotificationType { get; set; }
    }
}