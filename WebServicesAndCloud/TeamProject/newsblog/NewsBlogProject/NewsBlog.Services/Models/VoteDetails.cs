using NewsBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBlog.Services.Models
{
    public class VoteDetails : VoteModel
    {
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }

        public VoteDetails(Vote vote) : base(vote)
        {
            this.Article = vote.Article;
            this.User = vote.User;
        }
    }
}