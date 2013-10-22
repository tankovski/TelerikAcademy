using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["TicketsHomePage"] == null)
            {
                var tickets = Data.Tickets.All().OrderByDescending(ticket => ticket.Comments.Count)
                 .Select(TicketViewModel.FromTicket).Take(6).ToList();

                this.HttpContext.Cache.Add("TicketsHomePage", tickets, null, DateTime.Now.AddHours(1),
                    TimeSpan.Zero, CacheItemPriority.Default, null);

            }



            return View(this.HttpContext.Cache["TicketsHomePage"]);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}