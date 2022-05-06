using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class LibrarianController : Controller
    {
        public IActionResult LibrarianHome()
        {
            return View();
        }
    }
}
