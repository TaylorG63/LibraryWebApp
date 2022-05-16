using Microsoft.AspNetCore.Mvc;
using LibraryCommon.Models;
using static LibraryBuisnessLogicLayer.Processor.AuthorProcessor;
using static LibraryBuisnessLogicLayer.Processor.AddressProcessor;
using static LibraryBuisnessLogicLayer.Processor.BookProcessor;
using static LibraryBuisnessLogicLayer.Processor.GenreProcessor;
using LibraryWebApp.Models;

namespace LibraryWebApp.Controllers
{
    public class My_Page : Controller
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Author()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }
            [HttpPost]
        public IActionResult AddAuthor(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateAuthor(model.FirstName, model.LastName, model.DateOfBirth, 1, model.Bio);
            }
            return View();
        }
    }
}
