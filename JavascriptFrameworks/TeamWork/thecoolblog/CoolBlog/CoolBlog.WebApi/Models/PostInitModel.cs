using System;
using System.Collections.Generic;
using System.Linq;
using CoolBlog.Model;

namespace BloggingSystem.Service.Models
{
    public class PostInitModel
    {
        //{ 
        //"title": "NEW POST",
        //"tags": ["post"],
        //"text": "this is just a test post" 
        //}
        public string Title { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Text { get; set; }
        public bool Approved { get; set; }

        public Post CreatePost()
        {
            Post result = new Post()
            {
                Title = this.Title,
                PostContent = this.Text,
                CreationDare = DateTime.Now
            };

            return result;
        }
    }
}