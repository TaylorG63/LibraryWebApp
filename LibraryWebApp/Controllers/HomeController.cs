using static LibraryBuisnessLogicLayer.Processor.UserProccessor;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LibraryCommon.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string SessionUserName = "";
        public const string SessionFirstName = "";
        public const string SessionLastName = "";
        public const string SessionEmail = "";
        public const string SessionRole = "1";
        public const string SessionID = "";

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
            if (ModelState.IsValid)
            {
                if (CheckUserPass(model.Username, model.Password))
                {
                    UserModel _user = LoadUser(model.Username);
                    HttpContext.Session.SetString(SessionUserName, _user.UserName);
                    HttpContext.Session.SetString(SessionFirstName, _user.FirstName);
                    HttpContext.Session.SetString(SessionLastName, _user.LastName);
                    HttpContext.Session.SetString(SessionEmail, _user.Email);
                    HttpContext.Session.SetInt32(SessionID, _user.Id);
                    HttpContext.Session.SetInt32(SessionRole, _user.Role);
                }
                return RedirectToAction("Index");
            }
            else 
            { 
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var Users = GetUserNames();
                int recordsCreated = CreateUser(register.FirstName, register.LastName, register.Username, register.Email, register.Password);
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public JsonResult DoesUserNameExist(string UserName)
        {
            var Users = GetUserNames();
            return Json(Users.Contains(UserName));
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}