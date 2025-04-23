using System;
using System.ComponentModel.DataAnnotations;

namespace OurNotificationAPP.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public NotificationPreference PreferredNotificationType { get; set; }

        public User()
        {
            // Default constructor
        }

        public User(string name, string email, string phoneNumber, NotificationPreference preferredNotificationType)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            PreferredNotificationType = preferredNotificationType;
        }
    }
}