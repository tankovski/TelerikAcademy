using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBlog.Services.Models
{
    public class CommentReceivedModel
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int ArticleId { get; set; }
    }
}