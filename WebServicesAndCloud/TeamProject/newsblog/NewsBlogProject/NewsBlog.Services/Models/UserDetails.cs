using System;
using System.Collections.Generic;
using System.Linq;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class UserDetails : UserModel
    {
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SubComment> SubComments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }

        public UserDetails(User user)
            : base(user)
        {
            this.Comments = user.Comments;
            this.SubComments = user.SubComments;
            this.Votes = user.Votes;
        }

        public User CreateUser()
        {
            User user = new User();

            user.Username = this.Username;
            this.Password = user.Password;
            user.Comments = this.Comments;
            user.SubComments = this.SubComments;
            user.Votes = this.Votes;

            return user;
        }
    }
}