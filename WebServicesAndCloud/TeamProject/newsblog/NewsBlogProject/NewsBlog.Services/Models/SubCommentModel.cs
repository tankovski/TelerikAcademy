using System;
using System.Linq;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class SubCommentModel
    {
        public int Id { get; set; }
        public int ParentCommentId { get; set; }
        public string Content { get; set; }
        public String Author { get; set; }
        public System.DateTime Date { get; set; }

        public SubCommentModel() { }

        public SubCommentModel(SubComment subcom)
        {
            this.ParentCommentId = subcom.ParentComment;
            this.Id = subcom.Id;
            this.Content = subcom.Content;
            this.Date = subcom.Date;
            this.Author = subcom.User.Username;
        }
    }
}