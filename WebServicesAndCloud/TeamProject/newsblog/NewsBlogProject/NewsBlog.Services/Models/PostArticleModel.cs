using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBlog.Services.Models
{
    public class PostArticleModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}