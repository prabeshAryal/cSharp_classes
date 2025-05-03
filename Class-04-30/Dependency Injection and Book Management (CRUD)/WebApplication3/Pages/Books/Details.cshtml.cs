using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public DetailsModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Book Book { get; set; } = new Book();

        public IActionResult OnGet(int id)
        {
            Book = _bookService.GetBookById(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}