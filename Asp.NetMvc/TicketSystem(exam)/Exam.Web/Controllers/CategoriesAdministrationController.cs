using Exam.Web.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Exam.Models;

namespace Exam.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class CategoriesAdministrationController : BaseController
    {
        //
        // GET: /CategoriesAdministration/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {
            var result = Data.Categories.All().Select(CategoryViewModel.FromCategory);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = Data.Categories.All().FirstOrDefault(c => c.Id == category.Id);

            if (category != null && ModelState.IsValid)
            {
                existingCategory.Name = category.Name;


                this.Data.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {


            if (category != null && ModelState.IsValid)
            {

                var CategoryEntity = new Category()
                {
                    Name = category.Name
                };

                Data.Categories.Add(CategoryEntity);
                Data.SaveChanges();

                category.Id = CategoryEntity.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = Data.Categories.All().FirstOrDefault(x => x.Id == category.Id);
            
            foreach (var ticket in existingCategory.Tickets.ToList())
            {
                foreach (var comment in ticket.Comments.ToList())
                {
                    Data.Comments.Delete(comment);
                    
                }
                Data.SaveChanges();
                Data.Tickets.Delete(ticket);
            }
            Data.SaveChanges();

            this.Data.Categories.Delete(existingCategory);
            this.Data.SaveChanges();

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }
    }
}