using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    public class Ticket
    {
        private ICollection<Comment> comments;

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public Priority Priority { get; set; }
        public string ScreenShotUrl { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public Ticket()
        {
            this.Priority = Priority.Medium;
            this.comments = new HashSet<Comment>();
        }
    }
}
