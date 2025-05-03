using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    // Singleton implementation of the BookRepository
    public class SingletonBookRepository : IBookRepository
    {
        private static SingletonBookRepository _instance;
        private static readonly object _lock = new();
        private readonly List<Book> _books;

        // Private constructor to prevent instantiation from outside
        private SingletonBookRepository()
        {
            _books = [
                new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", 1925),
                new Book(2, "1984", "George Orwell", 1949),
                new Book(3, "To Kill a Mockingbird", "Harper Lee", 1960)
            ];
        }

        // Singleton instance accessor
        public static SingletonBookRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonBookRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
                throw new KeyNotFoundException($"Book with ID {book.Id} not found.");

            existingBook.UpdateBook(book.Title, book.Author, book.Year);
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new KeyNotFoundException($"Book with ID {id} not found.");

            _books.Remove(book);
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _books;

            searchTerm = searchTerm.ToLower();
            return _books.Where(b => 
                b.Title.ToLower().Contains(searchTerm) || 
                b.Author.ToLower().Contains(searchTerm))
                .ToList();
        }
    }
}