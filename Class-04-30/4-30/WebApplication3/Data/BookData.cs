using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public static class BookData
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, ISBN = "9780743273565", Description = "A novel set in the Roaring Twenties." },
                new Book { Id = 2, Title = "1984", Author = "George Orwell", PublicationYear = 1949, ISBN = "9780451524935", Description = "A dystopian novel about totalitarianism." },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, ISBN = "9780061120084", Description = "A novel about racial injustice in the Deep South." },

            };
        }
    }
}