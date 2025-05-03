using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;

        public IndexModel(IBookService bookService)
        {
            _bookService = bookService;
            Books = [];
        }

        public IList<Book> Books { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Books = _bookService.SearchBooks(SearchString);
            }
            else
            {
                Books = _bookService.GetAllBooks();
            }
        }
    }
}