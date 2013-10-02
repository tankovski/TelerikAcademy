using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesMVCEntities db = new MoviesMVCEntities();

        // GET: /Movies/
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Actior).Include(m => m.Actior1).Include(m => m.Studio);
            return View(movies.ToList());
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return PartialView("_MovieDetails", movy);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            ViewBag.LeadingMaelRole = new SelectList(db.Actiors, "Id", "Name");
            ViewBag.LeadeingFemaleRole = new SelectList(db.Actiors, "Id", "Name");
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name");
            return PartialView("_GetAddForm");
        }

        // POST: /Movies/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movy movy)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeadingMaelRole = new SelectList(db.Actiors, "Id", "Name", movy.LeadingMaelRole);
            ViewBag.LeadeingFemaleRole = new SelectList(db.Actiors, "Id", "Name", movy.LeadeingFemaleRole);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movy.StudioId);
            return View(movy);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeadingMaelRole = new SelectList(db.Actiors, "Id", "Name", movy.LeadingMaelRole);
            ViewBag.LeadeingFemaleRole = new SelectList(db.Actiors, "Id", "Name", movy.LeadeingFemaleRole);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movy.StudioId);
            return PartialView("_GetEditForm",movy);
        }

        // POST: /Movies/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movy movy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeadingMaelRole = new SelectList(db.Actiors, "Id", "Name", movy.LeadingMaelRole);
            ViewBag.LeadeingFemaleRole = new SelectList(db.Actiors, "Id", "Name", movy.LeadeingFemaleRole);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movy.StudioId);
            return PartialView("_GetEditForm", movy);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            db.Movies.Remove(movy);
            db.SaveChanges();
            var movies = db.Movies.Include(m => m.Actior).Include(m => m.Actior1).Include(m => m.Studio);
            return PartialView("_MoviesList", movies.ToList());
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movy movy = db.Movies.Find(id);
            db.Movies.Remove(movy);
            db.SaveChanges();
            var movies = db.Movies.Include(m => m.Actior).Include(m => m.Actior1).Include(m => m.Studio);
            return PartialView("_MoviesList", movies.ToList());
        }

        public ActionResult AllBooks()
        {
            var movies = db.Movies.Include(m => m.Actior).Include(m => m.Actior1).Include(m => m.Studio);
            return PartialView("_MoviesList",movies.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
