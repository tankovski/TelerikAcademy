using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BloggingSystemServices.Models;

namespace BloggingSystemServices.Controllers
{
    public class PostModel
    {
        public string Title { get; set; }
        public IList<string> Tags { get; set; }
        public string Text { get; set; }

        public PostModel()
        {
            this.Tags = new List<string>();
        }
    }
}
