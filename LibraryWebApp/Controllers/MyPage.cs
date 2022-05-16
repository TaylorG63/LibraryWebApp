using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class My_Page : Controller
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
