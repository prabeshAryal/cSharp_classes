// File: Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using SareeClientApp.Models; // Use your client app's namespace
using System.Diagnostics;
using System.Net.Http; // Required for HttpClient
using System.Net.Http.Json; // Required for GetFromJsonAsync

namespace SareeClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory; // Inject HttpClientFactory
        private const string ApiClientName = "SareeApiClient"; // Consistent client name

        // Update constructor to inject IHttpClientFactory
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // Modify Index action to fetch sarees
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(ApiClientName);
            List<Saree>? sarees = null;
            string errorMessage = null;

            try
            {
                _logger.LogInformation("Attempting to fetch sarees from API.");
                // Fetch the list of sarees from the relative API endpoint
                sarees = await client.GetFromJsonAsync<List<Saree>>("api/Sarees");
                _logger.LogInformation("Successfully fetched {Count} sarees.", sarees?.Count ?? 0);
            }
            catch (HttpRequestException ex)
            {
                // Log specific HTTP errors
                _logger.LogError("API request failed: {StatusCode} - {Message}", ex.StatusCode, ex.Message);
                errorMessage = $"Sorry, we couldn't retrieve the saree list at this time. Please try again later. (Error: {ex.StatusCode})";
            }
            catch (Exception ex) // Catch other potential errors (network, deserialization)
            {
                _logger.LogError("An unexpected error occurred while fetching sarees: {Message}", ex.Message);
                errorMessage = "An unexpected error occurred while loading sarees. Please try again later.";
            }

            // Pass error message to the view if something went wrong
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
            }

            // Pass the fetched list (or an empty list if null or error) to the view
            return View(sarees ?? new List<Saree>());
        }

        // Privacy action remains the same
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}