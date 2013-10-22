using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Priority Priority { get; set; }
        public string PriorityAsString { get; set; }
        public string ScreenShotUrl { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    Id = ticket.Id,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Description = ticket.Description,
                    Priority = ticket.Priority,
                    ScreenShotUrl = ticket.ScreenShotUrl,
                    Title = ticket.Title,
                    Comments = ticket.Comments.AsQueryable().Select(CommentViewModel.FromComment).ToList(),
                   
                };
            }
        }
    }
}