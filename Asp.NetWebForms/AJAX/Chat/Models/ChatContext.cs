using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext()
            : base("ChatDb")
        {  }

        public DbSet<Message> Messages { get; set; }
    }
}