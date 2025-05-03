// File: Controllers/SareesAdminController.cs
using Microsoft.AspNetCore.Mvc;
using SareeClientApp.Models; // Client app's namespace
using System.Net.Http;
using System.Net.Http.Json; // For GetFromJsonAsync, ReadFromJsonAsync etc.
using System.Text.Json;
using System.Text;
using System.Diagnostics;

namespace SareeClientApp.Controllers // Client app's namespace
{
    public class SareesAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SareesAdminController> _logger;
        private const string ApiClientName = "SareeApiClient"; // Consistent client name

        public SareesAdminController(IHttpClientFactory httpClientFactory, ILogger<SareesAdminController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient(ApiClientName);

        // GET: SareesAdmin
        public async Task<IActionResult> Index()
        {
            var client = GetClient();
            List<Saree>? sarees = null;
            try
            {
                // Use the relative path, BaseAddress is set in Program.cs
                sarees = await client.GetFromJsonAsync<List<Saree>>("api/Sarees");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("API request failed: {message}", ex.Message);
                // Handle error - show an error view or message
                ViewBag.ErrorMessage = $"Error fetching sarees from API: {ex.Message}";
                sarees = new List<Saree>(); // Return empty list to prevent null error in view
            }
            catch (Exception ex) // Catch other potential errors like deserialization
            {
                _logger.LogError("An error occurred: {message}", ex.Message);
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                sarees = new List<Saree>();
            }

            return View(sarees ?? new List<Saree>()); // Ensure model is not null
        }

        // GET: SareesAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Saree ID is required.");
            }

            var client = GetClient();
            Saree? saree = null;
            try
            {
                saree = await client.GetFromJsonAsync<Saree>($"api/Sarees/{id}");
                if (saree == null)
                {
                    return NotFound($"Saree with ID {id} not found in API.");
                }
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound($"Saree with ID {id} not found in API.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("API request failed: {message}", ex.Message);
                ViewBag.ErrorMessage = $"Error fetching saree details from API: {ex.Message}";
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); // Generic error view
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred: {message}", ex.Message);
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View(saree);
        }

        // GET: SareesAdmin/Create
        public IActionResult Create()
        {
            // Just show the empty form
            return View();
        }

        // POST: SareesAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Material,Color,Price,Description,Image")] Saree saree)
        {
            if (ModelState.IsValid)
            {
                var client = GetClient();
                try
                {
                    // PostAsJsonAsync automatically serializes the object to JSON
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Sarees", saree);

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("Successfully created Saree ID (from location header if available or via another call)");
                        // Optionally read the created saree back if the API returns it
                        // var createdSaree = await response.Content.ReadFromJsonAsync<Saree>();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Log error details from API if possible
                        string errorContent = await response.Content.ReadAsStringAsync();
                        _logger.LogError("API returned error on create: {StatusCode} - {ReasonPhrase} - {Content}",
                            response.StatusCode, response.ReasonPhrase, errorContent);
                        ModelState.AddModelError(string.Empty, $"API Error: {response.ReasonPhrase} - {errorContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError("API request failed on create: {message}", ex.Message);
                    ModelState.AddModelError(string.Empty, $"Network Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred during create: {message}", ex.Message);
                    ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(saree);
        }

        // GET: SareesAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Saree ID is required.");
            }

            var client = GetClient();
            Saree? saree = null;
            try
            {
                saree = await client.GetFromJsonAsync<Saree>($"api/Sarees/{id}");
                if (saree == null)
                {
                    return NotFound($"Saree with ID {id} not found in API.");
                }
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound($"Saree with ID {id} not found in API.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("API request failed getting item for edit: {message}", ex.Message);
                ViewBag.ErrorMessage = $"Error fetching saree details for edit from API: {ex.Message}";
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred getting item for edit: {message}", ex.Message);
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View(saree);
        }

        // POST: SareesAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Material,Color,Price,Description,Image")] Saree saree)
        {
            if (id != saree.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                var client = GetClient();
                try
                {
                    // PutAsJsonAsync automatically serializes
                    HttpResponseMessage response = await client.PutAsJsonAsync($"api/Sarees/{id}", saree);

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("Successfully updated Saree ID {SareeId}", id);
                        return RedirectToAction(nameof(Index));
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return NotFound($"Saree with ID {id} not found in API during update.");
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        _logger.LogError("API returned error on update: {StatusCode} - {ReasonPhrase} - {Content}",
                           response.StatusCode, response.ReasonPhrase, errorContent);
                        ModelState.AddModelError(string.Empty, $"API Error: {response.ReasonPhrase} - {errorContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError("API request failed on update: {message}", ex.Message);
                    ModelState.AddModelError(string.Empty, $"Network Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred during update: {message}", ex.Message);
                    ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(saree);
        }

        // GET: SareesAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Saree ID is required.");
            }

            var client = GetClient();
            Saree? saree = null;
            try
            {
                // Fetch the item to display confirmation details
                saree = await client.GetFromJsonAsync<Saree>($"api/Sarees/{id}");
                if (saree == null)
                {
                    return NotFound($"Saree with ID {id} not found in API.");
                }
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound($"Saree with ID {id} not found in API.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("API request failed getting item for delete confirmation: {message}", ex.Message);
                ViewBag.ErrorMessage = $"Error fetching saree details for delete from API: {ex.Message}";
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred getting item for delete: {message}", ex.Message);
                ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View(saree); // Show confirmation view
        }

        // POST: SareesAdmin/Delete/5
        [HttpPost, ActionName("Delete")] // Maps POST request to Delete action, ActionName ensures routing works
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = GetClient();
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"api/Sarees/{id}");

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Successfully deleted Saree ID {SareeId}", id);
                    return RedirectToAction(nameof(Index));
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Item might have been deleted by someone else already
                    _logger.LogWarning("Attempted to delete Saree ID {SareeId} which was not found in API.", id);
                    return RedirectToAction(nameof(Index)); // Redirect to index, maybe with a message
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("API returned error on delete: {StatusCode} - {ReasonPhrase} - {Content}",
                           response.StatusCode, response.ReasonPhrase, errorContent);
                    // Show error on the confirmation page (or redirect with TempData)
                    ViewBag.ErrorMessage = $"API Error: {response.ReasonPhrase} - {errorContent}";
                    // Need to re-fetch the saree data if we redisplay the Delete view on error
                    // For simplicity, redirecting to Index might be easier here or show a generic error
                    TempData["ErrorMessage"] = $"Failed to delete Saree {id}. API Error: {response.ReasonPhrase}";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("API request failed on delete: {message}", ex.Message);
                TempData["ErrorMessage"] = $"Failed to delete Saree {id}. Network Error: {ex.Message}";
                return RedirectToAction(nameof(Index)); // Redirect to index with error message
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred during delete: {message}", ex.Message);
                TempData["ErrorMessage"] = $"Failed to delete Saree {id}. Unexpected Error: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}