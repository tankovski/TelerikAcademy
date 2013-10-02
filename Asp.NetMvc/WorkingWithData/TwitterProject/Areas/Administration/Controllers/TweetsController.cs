using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterData;

namespace TwitterProject.Areas.Administration.Controllers
{
    public class TweetsController : Controller
    {
        private TwitterEntities db = new TwitterEntities();

        // GET: /Administration/Tweets/
        public async Task<ActionResult> Index()
        {
            var tweets = db.Tweets.Include(t => t.AspNetUser);
            return View(await tweets.ToListAsync());
        }

        // GET: /Administration/Tweets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = await db.Tweets.FindAsync(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: /Administration/Tweets/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: /Administration/Tweets/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.DatePosted = DateTime.Now;
                db.Tweets.Add(tweet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", tweet.UserId);
            return View(tweet);
        }

        // GET: /Administration/Tweets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = await db.Tweets.FindAsync(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", tweet.UserId);
            return View(tweet);
        }

        // POST: /Administration/Tweets/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tweet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", tweet.UserId);
            return View(tweet);
        }

        // GET: /Administration/Tweets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = await db.Tweets.FindAsync(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Administration/Tweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tweet tweet = await db.Tweets.FindAsync(id);
            db.Tweets.Remove(tweet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
