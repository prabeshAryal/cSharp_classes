using Microsoft.AspNetCore.Mvc;
using OurNotificationAPP.Models;
using OurNotificationAPP.Services;
using OurNotificationAPP.Services.Interfaces;

namespace OurNotificationAPP.Controllers
{
    public class NotificationController : Controller
    {
        private readonly EmailNotificationService _emailService;
        private readonly SmsNotificationService _smsService;
        private readonly NotificationFactory _notificationFactory;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(
            EmailNotificationService emailService,
            SmsNotificationService smsService,
            NotificationFactory notificationFactory,
            ILogger<NotificationController> logger)
        {
            _emailService = emailService;
            _smsService = smsService;
            _notificationFactory = notificationFactory;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(NotificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                // Get the appropriate service based on selected notification type
                INotificationService service = _notificationFactory.GetNotificationService(model.NotificationType);

                // Create a manager with the selected service
                var manager = new NotificationManager(service);

                // Send the notification
                manager.Notify(model.Message);

                _logger.LogInformation($"Notification sent via {model.NotificationType}: {model.Message}");

                ViewBag.SuccessMessage = $"Notification sent successfully via {model.NotificationType}!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending notification");
                ModelState.AddModelError("", "Failed to send notification. Please try again.");
            }

            return View("Index", model);
        }

        public IActionResult SendDirect(string message, string type)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    return BadRequest("Message cannot be empty");
                }

                NotificationManager manager;

                if (type?.ToLower() == "email")
                {
                    manager = new NotificationManager(_emailService);
                }
                else if (type?.ToLower() == "sms")
                {
                    manager = new NotificationManager(_smsService);
                }
                else
                {
                    return BadRequest("Invalid notification type. Use 'email' or 'sms'");
                }

                manager.Notify(message);
                return Ok($"Notification sent via {type}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SendDirect");
                return StatusCode(500, "An error occurred while sending the notification");
            }
        }

        // This action demonstrates notification based on user preference
        public IActionResult NotifyUser(int userId, string message)
        {
            try
            {
                // In a real app, you would fetch the user from a database
                // This is just a simulation
                var user = new User
                {
                    Id = userId,
                    Name = "Test User",
                    Email = "test@example.com",
                    PhoneNumber = "555-1234",
                    PreferredNotificationType = userId % 2 == 0 ? NotificationPreference.Email : NotificationPreference.SMS
                };

                var service = _notificationFactory.GetNotificationService(user.PreferredNotificationType);
                var manager = new NotificationManager(service);

                manager.Notify($"Message for {user.Name}: {message}");

                return Ok($"Notification sent to user {userId} via their preferred method ({user.PreferredNotificationType})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error notifying user {userId}");
                return StatusCode(500, "An error occurred while sending the notification");
            }
        }
    }
}