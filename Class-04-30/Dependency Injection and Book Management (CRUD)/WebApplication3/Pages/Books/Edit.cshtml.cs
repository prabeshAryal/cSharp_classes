using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookService _bookService;

        public EditModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _bookService.UpdateBook(Book);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}