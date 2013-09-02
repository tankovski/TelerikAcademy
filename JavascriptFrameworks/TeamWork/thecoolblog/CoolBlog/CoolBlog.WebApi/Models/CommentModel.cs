using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using CoolBlog.Model;

namespace CoolBlog.WebApi.Models
{
    [DataContract]
    public class CommentModel
    {
        //   {
        //    "text" : "I fully agree with you!",
        //    "commentedBy" : "Tedko the Server",
        //    "postDate" : "2013-08-17T10:18:00"
        //   }
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string CommentedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime? PostDate { get; set; }

        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get { return c => new CommentModel() { Text = c.CommentContent, CommentedBy = c.User.Nickname, PostDate = c.CreationDate }; }
        }
    }
}
