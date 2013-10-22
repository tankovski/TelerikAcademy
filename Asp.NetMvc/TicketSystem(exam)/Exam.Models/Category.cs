using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Category
    {
        private ICollection<Ticket> tickets;

        public Category()
        {
            this.tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets
        {
            get { return this.tickets; }
            set { this.tickets = value; }

        }
    }
}
