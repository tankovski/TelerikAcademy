using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using BookStore.Models;
using KendoForMVCDemos.ViewModels;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private KendoLibraryEntities db;

        public HomeController()
        {
            this.db = new KendoLibraryEntities();
        }

        public ActionResult Index()
        {
            var categories = db.Categories.Include("Books").ToList();

            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BookDetails(int id)
        {
            var book = db.Books.Find(id);

            return View(book);
        }

        public JsonResult GetAutocompleteData(string text)
        {
            var selectedBooks = this.db.Books
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .Select(ShortBookViewModel.FromBook);

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }

    }
}