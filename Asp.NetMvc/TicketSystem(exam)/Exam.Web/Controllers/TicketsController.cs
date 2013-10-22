using Exam.Models;
using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace Exam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        public ActionResult Details(int id)
        {

            var ticket = Data.Tickets.All()
                .Select(TicketViewModel.FromTicket).FirstOrDefault(t => t.Id == id);

            return View(ticket);
        }

        [Authorize]
        public ActionResult AddTicketForm()
        {
            List<SelectListItem> lists = (from list in Data.Categories.All()
                                          select new SelectListItem()
                                          {
                                              Text = list.Name,
                                              Value = list.Name
                                          }).ToList();

            IList<Priority> priorities = new List<Priority>();
            priorities.Add(Priority.High);
            priorities.Add(Priority.Low);
            priorities.Add(Priority.Medium);

            List<SelectListItem> listsPriority = (from list in priorities
                                                  select new SelectListItem()
                                                  {
                                                      Text = list.ToString(),
                                                      Value = list.ToString()
                                                  }).ToList();

            ViewData["categories"] = lists;
            ViewData["priority"] = listsPriority;
            return View();
        }

        [Authorize]
        public ActionResult AddNewTicket(TicketAddModel ticket)
        {
            var userId = User.Identity.GetUserId();
            var user = Data.Users.All().FirstOrDefault(u => u.Id == userId);
            if (ModelState.IsValid && ticket != null)
            {
                Ticket ticketEntoty = new Ticket()
                {
                    Author = user,
                    AuthorId = user.Id,
                    Description = ticket.Description,
                    ScreenShotUrl = ticket.ScreenShotUrl,
                    Title = ticket.Title

                };

                switch (ticket.Priority)
                {

                    case "High": { ticketEntoty.Priority = Priority.High; } break;
                    case "Medium": { ticketEntoty.Priority = Priority.Medium; } break;
                    case "Low": { ticketEntoty.Priority = Priority.Low; } break;

                    default:
                        break;
                }

                var category = Data.Categories.All().FirstOrDefault(c => c.Name == ticket.Category);
                category.Tickets.Add(ticketEntoty);
                user.Points++;
                Data.SaveChanges();

                return RedirectToAction("Details/" + ticketEntoty.Id, "Tickets");
            }



            List<SelectListItem> lists = (from list in Data.Categories.All()
                                          select new SelectListItem()
                                          {
                                              Text = list.Name,
                                              Value = list.Name
                                          }).ToList();

            IList<Priority> priorities = new List<Priority>();
            priorities.Add(Priority.High);
            priorities.Add(Priority.Low);
            priorities.Add(Priority.Medium);

            List<SelectListItem> listsPriority = (from list in priorities
                                                  select new SelectListItem()
                                                  {
                                                      Text = list.ToString(),
                                                      Value = list.ToString()
                                                  }).ToList();

            ViewData["categories"] = lists;
            ViewData["priority"] = listsPriority;

            return View("AddTicketForm", ticket);
        }

        [Authorize]
        public ActionResult ViewAllTickets()
        {


            return View();
        }

        [Authorize]
        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            var tickets = Data.Tickets.All().Select(TicketViewModel.FromTicket).ToList();
            for (int i = 0; i < tickets.Count; i++)
            {
                tickets[i].PriorityAsString = tickets[i].Priority.ToString();
            }


            return Json(tickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostComment(CommentPostVIewModel comment)
        {
            if (ModelState.IsValid)
            {
                var ticket = Data.Tickets.All().FirstOrDefault(l => l.Id == comment.TicketId);
                var userId = User.Identity.GetUserId();
                var commentEntity = new Comment()
                {
                    AuthorId = userId,
                    TicketId = comment.TicketId,
                    Content = comment.Content
                };


                Data.Comments.Add(commentEntity);
                Data.SaveChanges();


                var comments = Data.Comments.All().Select(CommentViewModel.FromComment)
                    .Where(c => c.TicketId == commentEntity.TicketId).ToList();

                return PartialView("_AllComments", comments);
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
            }
        }

        public JsonResult GetCategories()
        {
            var manufacturers = Data.Categories.All().Select(CategoryViewModel.FromCategory).ToList();


            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchTickets(int? CategoryId)
        {
            if (CategoryId != null)
            {
                var tickets = Data.Categories.All().FirstOrDefault(c => c.Id == CategoryId)
               .Tickets.AsQueryable().Select(TicketViewModel.FromTicket).ToList();
                for (int i = 0; i < tickets.Count; i++)
                {
                    tickets[i].PriorityAsString = tickets[i].Priority.ToString();
                }
                return View("ViewSomeTickets", tickets);
            }
            else
            {

                return View("ViewSomeTickets");
            }



        }

    }
}