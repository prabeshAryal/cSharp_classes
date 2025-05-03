using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> SearchBooks(string searchTerm);
    }
}