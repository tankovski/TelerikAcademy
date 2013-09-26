using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public int PostsCount { get; set; }
        public int RatingPlace { get; set; }
    }
}