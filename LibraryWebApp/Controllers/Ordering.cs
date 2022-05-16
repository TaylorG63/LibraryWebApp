using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class Ordering : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }
    }
}
