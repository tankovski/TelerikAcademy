using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class CommentPostVIewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Max lenght of the UserName must be 100 symbols")]
        public string Content { get; set; }

        public int TicketId { get; set; }
    }
}