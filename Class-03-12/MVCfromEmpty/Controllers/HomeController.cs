using Microsoft.AspNetCore.Mvc;
using MVCfromEmpty.Models;

namespace MVCfromEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<BookModel> list = new List<BookModel>()
            {
                new BookModel(1, "Noval", "Science-fiction", "Alexander Duma", "Caucasus Journey"),
                new BookModel(2, "Noval", "Science-fiction", "Alexander Duma", "Caucasus Journey"),
                new BookModel(3, "Noval", "Science-fiction", "Alexander Duma", "Caucasus Journey")
            };

            return View(list);
        }

    }
}  
