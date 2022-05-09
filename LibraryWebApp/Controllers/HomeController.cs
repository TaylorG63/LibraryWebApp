using static LibraryBuisnessLogicLayer.Processor.UserProccessor;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region HttpGet
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Books()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Authors()
        {
            return View();
        }
        #endregion

        #region HttpPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateUser(register.FirstName, register.LastName, register.Username, register.Email);
                return RedirectToAction("Login");
            }
            return View();
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}