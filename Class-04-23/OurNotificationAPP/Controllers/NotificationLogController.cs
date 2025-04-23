using Microsoft.AspNetCore.Mvc;
using OurNotificationAPP.Services;
using System;

namespace OurNotificationAPP.Controllers
{
    public class NotificationLogController : Controller
    {
        private readonly NotificationLogService _logService;
        private readonly ILogger<NotificationLogController> _logger;

        public NotificationLogController(
            NotificationLogService logService,
            ILogger<NotificationLogController> logger)
        {
            _logService = logService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var logs = _logService.GetAllNotifications();
            return View(logs);
        }

        [HttpPost]
        public IActionResult ClearLogs()
        {
            _logService.ClearLogs();
            _logger.LogInformation("Notification logs cleared");
            return RedirectToAction("Index");
        }
    }
}