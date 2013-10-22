using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketAddModel
    {
        [Required(ErrorMessage="The field is required!")]
        [ShouldNotContainBug(ErrorMessage = "The word BUG should not be used in the title!")]
        [MaxLength(100, ErrorMessage = "Max lenght of the UserName must be 100 symbols")]
        public string Title { get; set; }
        public string Priority { get; set; }

        [MaxLength(200, ErrorMessage = "Max lenght of the UserName must be 200 symbols")]
        public string ScreenShotUrl { get; set; }

        [MaxLength(500, ErrorMessage = "Max lenght of the UserName must be 500 symbols")]
        public string Description { get; set; }
        public string Category { get; set; }
    }
}