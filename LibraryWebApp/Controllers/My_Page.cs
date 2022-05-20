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
        #region Librarian
        public IActionResult Author()
        {
            Security();
            return View();
        }
        public IActionResult Genre()
        {
            Security();
            return View();
        }
        public IActionResult Book()
        {
            Security();
            return View();
        }
        public IActionResult Librarian()
        {
            Security();
            return View();
        }
        #region AddGenre
        [HttpGet]
        public IActionResult AddGenre()
        {
            Security();
            return View();
        }
        [HttpPost]
        public IActionResult AddGenre(GenreModel genre)
        {
            Security();
            if (ModelState.IsValid)
            {
                CreateGenre(genre.Name, genre.Description, genre.IsFiction);
                return RedirectToAction("Genre");
            }
            return View();
        }
        #endregion
        #region AddBook
        [HttpGet]
        public IActionResult AddBook()
        {
            Security();
            List<AuthorDTO> authors = LoadAuthores();
            List<GenreDTO> genres = LoadGenrees();
            ViewBag.Author = authors;
            ViewBag.Genre = genres;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookDTO model)
        {
            Security();
            List<AuthorDTO> authors = LoadAuthores();
            List<GenreDTO> genres = LoadGenrees();
            ViewBag.Author = authors;
            ViewBag.Genre = genres;
            if (ModelState.IsValid)
            {
                CreateBook(model.Title, model.Description, model.IsPaperBack, model.PublishDate, model.Author, model.Genre);
                return RedirectToAction("Author");
            }
            return View();
        }
        #endregion
        #region AddAuthor
        [HttpGet]
        public IActionResult AddAuthor()
        {
            Security();
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorModel model)
        {
            Security();
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
        #endregion
        #region Administrator

        #endregion
        public IActionResult? Security()
        {
            if (true) //this would be set up to detect the role of a session, if true, do nothing, if false redirect the webpage to an access denied page
            {
                return null;
            }
            else
            {
                return View();
            }
            
        }
    }
}
