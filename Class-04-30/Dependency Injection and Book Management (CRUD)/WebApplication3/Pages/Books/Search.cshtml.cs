using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Pages.Books
{
    public class SearchModel : PageModel
    {
        private readonly IBookService _bookService;

        public SearchModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<Book> SearchResults { get; set; } = [];

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                SearchResults = _bookService.SearchBooks(SearchTerm);
            }
        }
    }
}