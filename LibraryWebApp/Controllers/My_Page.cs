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
        #region AddGenre
        [HttpGet]
        public IActionResult AddGenre()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddGenre(GenreModel genre)
        {
            if (ModelState.IsValid)
            {
                CreateGenre(genre.Name, genre.Description, genre.IsFiction);
                return RedirectToAction("Genre");
            }
            return View();
        }
        #endregion
        #region AddBook
        public IActionResult AddBook()
        {
            List<BookDTO> books;
            return View();
        }
        #endregion
        #region AddAuthor
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
                int addressID = CreateAddressWithIDReturn(model.Address, model.City, model.Country, model.State, model.ZipCode);
                if (addressID != 0)
                {
                    int author = CreateAuthor(model.FirstName, model.LastName, model.DateOfBirth, addressID, model.Bio);
                }
                return RedirectToAction("Author");
            }
            return View();
        }
        #endregion
    }
}
