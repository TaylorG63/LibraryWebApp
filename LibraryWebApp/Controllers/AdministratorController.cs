using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult AdministratorHome()
        {
            return View();
        }
    }
}
