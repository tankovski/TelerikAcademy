using System;
using System.Collections.Generic;
using System.Linq;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public String Author { get; set; }
        public System.DateTime Date { get; set; }
        public virtual ICollection<SubCommentModel> SubComments { get; set; }

        public CommentModel(Comment comment)
        {
            this.Id = comment.Id;
            this.Content = comment.Content;
            this.Date = comment.Date;
            this.Author = comment.User.Username;
            this.SubComments = new List<SubCommentModel>();
            foreach (var subcomment in comment.SubComments)
            {
                this.SubComments.Add(new SubCommentModel(subcomment));
            }
        }
    }
}