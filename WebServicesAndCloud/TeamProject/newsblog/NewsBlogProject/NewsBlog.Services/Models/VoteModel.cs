using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class VoteModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int ArticleId { get; set; }
        public bool Value { get; set; }

        public VoteModel(Vote vote)
        {
            Id = vote.Id;
            AuthorId = vote.AuthorId;
            ArticleId = vote.ArticleId;
            Value = vote.Value;
            this.Author = vote.User.Username;
        }
    }
}