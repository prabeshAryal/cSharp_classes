// File: Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc; // Ensure this is present
using System.Diagnostics;
using Classwork_04_16.Models; // Your project's namespace

namespace Classwork_04_16.Controllers // Your project's namespace
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // --- MODIFIED Index Action ---
        // This action now redirects to the Swagger UI page
        public IActionResult Index()
        {
            // Redirect to the default Swagger UI route
            return Redirect("/swagger");
        }
        // --- End Modification ---

        // Privacy action remains unchanged, but might not be reachable via UI
        // if you remove links to it.
        public IActionResult Privacy()
        {
            // You could potentially redirect this too, or remove it if unused.
            // return Redirect("/swagger");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}