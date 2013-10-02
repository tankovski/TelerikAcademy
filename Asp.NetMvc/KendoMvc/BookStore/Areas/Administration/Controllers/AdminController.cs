using BookStore.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using KendoForMVCDemos.Areas.Administration.ViewModels;
using BookStore.Areas.ViewModels;

namespace BookStore.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        private KendoLibraryEntities db;

        public AdminController()
        {
            this.db = new KendoLibraryEntities();
        }
        public ActionResult EditCategories()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {

            var result = this.db.Categories.Select(CategoryViewModel.FromCategory);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
               
                var newCategory = new Category
                {
                    Name=category.Name
                };

                this.db.Categories.Add(newCategory);
                this.db.SaveChanges();

                category.Id = newCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.db.Categories.FirstOrDefault(cat => cat.Id == category.Id);

            if (category != null && ModelState.IsValid)
            {
                existingCategory.Name = category.Name;

                this.db.SaveChanges();
            }
            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.db.Categories.FirstOrDefault(cat => cat.Id == category.Id);

            this.db.Categories.Remove(existingCategory);
            this.db.SaveChanges();

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }
	}
}