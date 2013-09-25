using InformationalAspPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationalAspPage.Controllers
{
    public class BooksController : Controller
    {
        public IList<Book> booksList;

        public BooksController()
        {
            this.booksList = new List<Book>()
            {
                new Book(1,"FirstCoolBook","FirstCoolAuthor"),
                new Book(2,"SecondCoolBook","SecondCoolAuthor")
                {
                 Description="Wow very cool"   
                },
                new Book(3,"ThirdCoolBook","ThirdCoolAuthor"),
                new Book(4,"FourthCoolBook","FourthCoolAuthor")
                {
                   Description="Yeah this book is for cool stuff"
                },
                new Book(3,"FifthCoolBook","ThirdCoolAuthor")

            };
        }

        public ActionResult GetAll()
        {


            return View(this.booksList);
        }

        public ActionResult SingleBook(int id)
        {
            Book book = booksList.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

    }
}