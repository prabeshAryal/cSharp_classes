// File: Models/Saree.cs
using System.ComponentModel.DataAnnotations;

namespace SareeClientApp.Models // Use your client app's namespace
{
    public class Saree
    {
        // We might not always need the ID from the user (e.g., create)
        // but it's useful to have it for display and edit/delete operations.
        public int Id { get; set; }

        [Required(ErrorMessage = "Saree name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Material is required.")]
        [StringLength(50)]
        public string Material { get; set; } = string.Empty;

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between 0.01 and 100,000.00.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)] // Display as currency
        public decimal Price { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Image URL")] // Display name for the label
        [DataType(DataType.ImageUrl)] // Hint for rendering (though we'll use <img>)
        [StringLength(2048)] // Max URL length
        public string? Image { get; set; } // Stores the URL/path as a string
    }
}