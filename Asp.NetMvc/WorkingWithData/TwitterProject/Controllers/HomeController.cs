using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterData;
using TwitterProject.ViewModels;

namespace TwitterProject.Controllers
{
    public class HomeController : Controller
    {
        IUowData db;

        public HomeController(IUowData db)
        {
            this.db = db;
        }

        public HomeController()
        {
            db = new UowData();
        }

        public ActionResult Index()
        {
            var users = db.Users.All().Select(UserModel.FromUser).ToList();

            return View(users);
        }


        public ActionResult UserTweets(string id)
        {

            var user = db.Users.GetById(id);
            var tweets = user.Tweets.AsQueryable().Select(TweetViewModel.FromTweet).ToList();

            return View(tweets);
        }

        public ActionResult UserProfile()
        {
            var user = db.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
            var tweets = user.Tweets.AsQueryable().Select(TweetViewModel.FromTweet).ToList();

            return View(tweets);
        }

        public ActionResult ShowForm()
        {
            return PartialView("_ShowForm");
        }

        public ActionResult HideForm()
        {
            return PartialView("_HideForm");
        }

        public ActionResult PostTweet(string text)
        {
            var userTweets = db.Users.All()
                    .FirstOrDefault(u => u.UserName == User.Identity.Name)
                    .Tweets;

            if (text.Length > 0)
            {
                Tweet newTweet = new Tweet()
                {
                    Text = text,
                    DatePosted = DateTime.Now
                };


                userTweets.Add(newTweet);
                db.SaveChanges();


            }

            return View("UserProfile", userTweets.AsQueryable().Select(TweetViewModel.FromTweet).ToList());
        }

        public ActionResult Search()
        {
            return View();
        }

        [OutputCacheAttribute(VaryByParam = "name", Duration = 900)]
        public ActionResult SearchByTag(string tag)
        {
            var tweets = db.Tweets.All().Select(TweetViewModel.FromTweet).Where(t => t.Text.Contains("#" + tag));

            return PartialView("_Tags", tweets.ToList());
        }

    }
}