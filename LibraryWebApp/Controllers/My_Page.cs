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

        #region Dashboards
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Author()
        {
            return View();
        }
        public IActionResult Genre()
        {
            return View();
        }
        public IActionResult Book()
        {
            return View();
        }
        #endregion
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
        [HttpGet]
        public IActionResult AddBook()
        {
            List<AuthorDTO> authors = LoadAuthores();
            List<GenreDTO> genres = LoadGenrees();
            ViewBag.Author = authors;
            ViewBag.Genre = genres;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookDTO model)
        {
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
