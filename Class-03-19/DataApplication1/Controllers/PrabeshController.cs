using DataApplication1.DatabaseConfigs;
using DataApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataApplication1.Controllers
{
    [Route("[controller]")]
    public class PrabeshController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<PrabeshController> _logger;

        public PrabeshController(AppDbContext db, ILogger<PrabeshController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // Display the list of entries
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Fetching all Prabesh entries");

                // Check if database connection is working
                if (!_db.Database.CanConnect())
                {
                    _logger.LogWarning("Database connection failed in Index action");
                    ViewBag.ErrorMessage = "Cannot connect to database. Please check your connection string.";
                    return View(new List<Prabesh>());
                }

                var entries = await _db.Prabesh.ToListAsync();
                _logger.LogInformation($"Found {entries.Count} entries");
                return View(entries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching entries: {ex.Message}");
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View(new List<Prabesh>());
            }
        }

        // GET action that returns plain text for debugging
        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Content("PrabeshController is responding!");
        }

        // Add new entry - POST action to handle form submission
        [HttpPost]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Prabesh prabesh)
        {
            try
            {
                if (prabesh == null)
                {
                    _logger.LogWarning("Add: Prabesh object is null");
                    return BadRequest("Invalid data submitted");
                }

                _logger.LogInformation($"Adding new entry: {prabesh.Name}, Age: {prabesh.Age}, Sex: {prabesh.Sex}");

                if (ModelState.IsValid)
                {
                    _db.Prabesh.Add(prabesh);
                    int result = await _db.SaveChangesAsync();

                    if (result > 0)
                    {
                        _logger.LogInformation($"Successfully added entry with ID: {prabesh.Id}");
                        TempData["SuccessMessage"] = "Record added successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogWarning("SaveChangesAsync returned 0 - no records were added");
                        ModelState.AddModelError("", "No changes were saved to the database");
                    }
                }
                else
                {
                    _logger.LogWarning($"Model validation failed: {string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");
                }

                var entries = await _db.Prabesh.ToListAsync();
                return View("Index", entries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding entry: {ex.Message}");
                TempData["ErrorMessage"] = "Error adding record. Please try again.";
                return StatusCode(500, "Database error occurred while adding entry");
            }
        }

        // Edit an existing entry - GET action
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching entry with ID: {id} for editing");
                var prabesh = await _db.Prabesh.FindAsync(id);

                if (prabesh == null)
                {
                    _logger.LogWarning($"Entry with ID: {id} not found");
                    return NotFound($"Entry with ID: {id} not found");
                }

                return View(prabesh);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching entry {id} for edit: {ex.Message}");
                return StatusCode(500, "Database error occurred while fetching entry");
            }
        }

        // Edit an existing entry - POST action
        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Prabesh prabesh)
        {
            try
            {
                if (prabesh == null)
                {
                    _logger.LogWarning("Edit: Prabesh object is null");
                    return BadRequest("Invalid data submitted");
                }

                _logger.LogInformation($"Updating entry ID: {prabesh.Id}, Name: {prabesh.Name}, Age: {prabesh.Age}, Sex: {prabesh.Sex}");

                if (ModelState.IsValid)
                {
                    _db.Entry(prabesh).State = EntityState.Modified;
                    int result = await _db.SaveChangesAsync();

                    if (result > 0)
                    {
                        _logger.LogInformation($"Successfully updated entry with ID: {prabesh.Id}");
                        TempData["SuccessMessage"] = "Record updated successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogWarning($"No changes detected for entry ID: {prabesh.Id}");
                        ModelState.AddModelError("", "No changes were detected");
                    }
                }
                else
                {
                    _logger.LogWarning($"Model validation failed: {string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");
                }

                return View(prabesh);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError($"Concurrency error updating entry {prabesh.Id}: {ex.Message}");
                return StatusCode(409, "The record was modified by another user");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating entry {prabesh.Id}: {ex.Message}");
                TempData["ErrorMessage"] = "Error updating record. Please try again.";
                return StatusCode(500, "Database error occurred while updating entry");
            }
        }

        // Delete an entry
        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting entry with ID: {id}");
                var prabesh = await _db.Prabesh.FindAsync(id);

                if (prabesh == null)
                {
                    _logger.LogWarning($"Delete: Entry with ID: {id} not found");
                    return NotFound($"Entry with ID: {id} not found");
                }

                _db.Prabesh.Remove(prabesh);
                int result = await _db.SaveChangesAsync();

                if (result > 0)
                {
                    _logger.LogInformation($"Successfully deleted entry with ID: {id}");
                    TempData["SuccessMessage"] = "Record deleted successfully!";
                }
                else
                {
                    _logger.LogWarning($"Delete operation for ID: {id} did not affect any records");
                    TempData["ErrorMessage"] = "Delete operation failed. No records affected.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting entry {id}: {ex.Message}");
                TempData["ErrorMessage"] = "Error deleting record. Please try again.";
                return StatusCode(500, "Database error occurred while deleting entry");
            }
        }

        // Test database connection
        [HttpGet]
        [Route("TestConnection")]
        public IActionResult TestConnection()
        {
            try
            {
                bool canConnect = _db.Database.CanConnect();
                return Json(new { success = canConnect, message = canConnect ? "Database connection successful" : "Cannot connect to database" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }
    }
}