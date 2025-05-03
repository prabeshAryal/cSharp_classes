// File: Controllers/SareesController.cs
using Microsoft.AspNetCore.Mvc;
using Classwork_04_16.Models; // Use your actual project's namespace
using Classwork_04_16.Data;  // Use your actual project's namespace + .Data
using System.Collections.Generic;

namespace Classwork_04_16.Controllers // Use your actual project's namespace
{
    [Route("api/[controller]")] // Base route: /api/sarees
    [ApiController]             // Enables API-specific features
    public class SareesController : ControllerBase // Inherit from ControllerBase for API controllers
    {
        // --- GET All Sarees ---
        // GET: /api/sarees
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Saree>> GetSarees()
        {
            return Ok(SareeDataStore.GetSarees()); // Return 200 OK with the list
        }

        // --- GET Saree By ID ---
        // GET: /api/sarees/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Saree> GetSaree(int id)
        {
            var saree = SareeDataStore.GetSareeById(id);

            if (saree == null)
            {
                return NotFound($"Saree with ID {id} not found."); // Return 404 Not Found
            }

            return Ok(saree); // Return 200 OK with the saree
        }

        // --- CREATE a new Saree ---
        // POST: /api/sarees
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Saree> CreateSaree([FromBody] Saree newSaree)
        {
            if (newSaree == null)
            {
                return BadRequest("Saree data is required."); // Return 400 Bad Request
            }

            // Basic validation (you might add more complex validation)
            if (string.IsNullOrWhiteSpace(newSaree.Name) || newSaree.Price <= 0)
            {
                return BadRequest("Saree name must be provided and price must be positive.");
            }

            // In a real scenario, you might check if an ID was accidentally provided and ignore/reject it.
            // Here, the DataStore assigns the ID.

            var createdSaree = SareeDataStore.AddSaree(newSaree);

            // Return 201 Created status with the location of the new resource and the resource itself
            return CreatedAtAction(nameof(GetSaree), // Name of the action to get the resource
                                   new { id = createdSaree.Id }, // Route values for the location header
                                   createdSaree); // The created resource in the body
        }

        // --- UPDATE an existing Saree ---
        // PUT: /api/sarees/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateSaree(int id, [FromBody] Saree updatedSaree)
        {
            if (updatedSaree == null || id != updatedSaree.Id) // Check if ID in URL matches ID in body (if provided)
            {
                // Optionally: If updatedSaree.Id is 0 or doesn't match, still proceed but use 'id' from the route.
                // For strictness, we require them to match if the body Id is present and non-zero.
                // If Id is not part of the body DTO, just check for null body.
                // Let's simplify and assume Id might not be in the body or should be ignored.
                // We will always use the 'id' from the route parameter.
                // So, just check for null body:
                if (updatedSaree == null)
                {
                    return BadRequest("Saree data is required for update.");
                }
                // We'll force the ID from the route onto the object before updating in the store
                updatedSaree.Id = id;

            }

            // Basic validation (similar to POST)
            if (string.IsNullOrWhiteSpace(updatedSaree.Name) || updatedSaree.Price <= 0)
            {
                return BadRequest("Saree name must be provided and price must be positive for update.");
            }


            var success = SareeDataStore.UpdateSaree(id, updatedSaree);

            if (!success)
            {
                return NotFound($"Saree with ID {id} not found for update."); // Return 404 Not Found
            }

            return NoContent(); // Return 204 No Content (standard for successful PUT)
        }

        // --- DELETE a Saree ---
        // DELETE: /api/sarees/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteSaree(int id)
        {
            var success = SareeDataStore.DeleteSaree(id);

            if (!success)
            {
                return NotFound($"Saree with ID {id} not found for deletion."); // Return 404 Not Found
            }

            return NoContent(); // Return 204 No Content (standard for successful DELETE)
        }
    }
}