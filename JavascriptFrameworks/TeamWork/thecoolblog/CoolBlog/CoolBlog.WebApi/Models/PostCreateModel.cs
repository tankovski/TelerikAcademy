using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolBlog.WebApi.Models
{
    public class PostCreateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public DateTime CreationDate { get; set; }
    }
}