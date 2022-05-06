using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class OrderingController : Controller
    {
        [HttpGet]
        public IActionResult MyPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Catalog()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
