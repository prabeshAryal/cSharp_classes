using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class BooksModel : PageModel
    {
        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = BookData.GetBooks();
        }
    }
}