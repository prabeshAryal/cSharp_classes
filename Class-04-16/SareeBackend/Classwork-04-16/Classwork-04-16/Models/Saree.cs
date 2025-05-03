// File: Models/Saree.cs
namespace Classwork_04_16.Models // Use your actual project's namespace
{
    public class Saree
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // e.g., "Kanjeevaram Silk", "Banarasi Georgette"
        public string Material { get; set; } = string.Empty; // e.g., "Silk", "Cotton", "Georgette"
        public string Color { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; } // Optional description

        public string? Image { get; set; }
    }
}