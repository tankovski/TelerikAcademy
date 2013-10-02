using BookStore.Models;
using Kendo.Mvc.UI;
using KendoForMVCDemos.Areas.Administration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using BookStore.Areas.ViewModels;

namespace BookStore.Areas.Administration.Controllers
{
    public class BooksController : Controller
    {
        private KendoLibraryEntities db;
        public BooksController()
        {
        

            this.db = new KendoLibraryEntities();
        }


        public ActionResult Index()
        {
            ViewData["categories"] = db.Categories.Select(CategoryViewModel.FromCategory);

            return View();
        }

        public JsonResult AllCategories()
        {
            var categories = db.Categories.Select(CategoryViewModel.FromCategory).ToList();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateBook([DataSourceRequest] DataSourceRequest request, DetailedBookViewModel book)
        {
            

            if (book != null && ModelState.IsValid)
            {
                var category = this.db.Categories.FirstOrDefault(x => x.Id == int.Parse(book.CategoryName));

                
                var newBook = new Book
                {
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category=category
                  
                };

                this.db.Books.Add(newBook);
                this.db.SaveChanges();

                book.Id = newBook.Id;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadBooks([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.db.Books.Include("Categories").Select(DetailedBookViewModel.FromBook);
           

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBook([DataSourceRequest] DataSourceRequest request, DetailedBookViewModel book)
        {
            var existingBook = this.db.Books.FirstOrDefault(x => x.Id == book.Id);

            if (book != null && ModelState.IsValid)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;
                existingBook.Category = this.db.Categories.FirstOrDefault(x => x.Name == book.CategoryName);

                this.db.SaveChanges();
            }

            return Json((new[] { book }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBook([DataSourceRequest] DataSourceRequest request, DetailedBookViewModel book)
        {
            var existingBook = this.db.Books.FirstOrDefault(x => x.Id == book.Id);

            this.db.Books.Remove(existingBook);
            this.db.SaveChanges();

            return Json(new[] { book }, JsonRequestBehavior.AllowGet);
        }
	}
}