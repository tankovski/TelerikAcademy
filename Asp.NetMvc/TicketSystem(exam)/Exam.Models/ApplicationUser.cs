using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ApplicationUser : User
    {
        public int Points { get; set; }

        //[Required]
        //[StringLength(15, MinimumLength = 6, ErrorMessage = "UserName must be between {2} and {1} symbols!")]
        //public override string UserName { get; set; }

        public ApplicationUser()
        {
            this.Points = 10;
        }
    }
}
