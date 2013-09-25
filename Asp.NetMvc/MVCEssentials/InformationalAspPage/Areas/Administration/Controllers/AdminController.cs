using InformationalAspPage.Controllers;
using InformationalAspPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationalAspPage.Areas.Administration.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IList<Book> booksList;

        public AdminController()
        {
            var bookController = new BooksController();

           this.booksList = bookController.booksList;
        }
        public ActionResult SeeAllBooks()
        {
           

            return View(booksList);
        }

        public ActionResult SingleBook(int id)
        {
            Book book = booksList.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        public ActionResult AllBooksFromAuthor(string author)
        {
            var books = this.booksList.Where(b => b.Author == author).ToList();

            return View(books);
        }
	}
}