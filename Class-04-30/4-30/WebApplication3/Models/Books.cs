using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string Description { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Author name cannot be longer than 100 characters.")]
        public string Author { get; set; }

        [Required]
        [Range(1450, 2100, ErrorMessage = "Publication year must be between 1450 and 2100.")]
        public int PublicationYear { get; set; }

        [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN must be between 10 and 13 characters.")]
        public string ISBN { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Optional: You can add methods for additional functionality
        public void UpdateBook(string title, string description, string author, int publicationYear, string isbn)
        {
            Title = title;
            Description = description;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
            UpdatedAt = DateTime.Now;
        }
    }
}