using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using CoolBlog.Model;

namespace CoolBlog.WebApi.Models
{
    [DataContract]
    public class PostModel
    {
       //[{ "id" : 1,
       //  "title" : "I want more homework",
       //  "postedBy" : "Ivan Ivanov",
       //  "postDate" : "2013-08-17T10:16:34",
       //  "text" : "I think that the homework that the trainers are giving us is too little for our capabilities",
       //  "tags" : ["homework", "домашна", "i", "want", "more", "homework"],
       //  "comments" : [{
       //      "text" : "I fully agree with you!",
       //      "commentedBy" : "Tedko the Server",
       //      "postDate" : "2013-08-17T10:18:00"
       //      }, {
       //      "text" : "More! More! More! MOREEEEEE!",
       //      "commentedBy" : "Stamo Stamov",
       //      "postDate" : "2013-08-16T10:20:24.9550631+03:00"}]

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postedById")]
        public int PostedById { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime? PostDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }

        [DataMember(Name = "approved")]
        public bool? Approved { get; set; }

        public static Expression<Func<Post, PostModel>> FromPost
        {
            get
            {
                return p => new PostModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    PostedBy = p.User.Nickname,
                    PostedById = p.User.Id,
                    PostDate = p.CreationDare,
                    Text = p.PostContent,
                    Tags = p.Tags.Select(t => t.Name),
                    Comments = p.Comments.AsQueryable().Select(CommentModel.FromComment),
                    Approved = p.Approved
                };
            }
        }

    }
}