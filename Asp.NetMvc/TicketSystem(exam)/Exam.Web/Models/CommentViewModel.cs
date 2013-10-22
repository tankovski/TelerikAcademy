using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exam.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public int TicketId { get; set; }
        public string Ticket { get; set; }
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Ticket = comment.Ticket.Title,
                    TicketId = comment.TicketId,
                    Author = comment.Author.UserName
                };
            }
        }
    }
}
