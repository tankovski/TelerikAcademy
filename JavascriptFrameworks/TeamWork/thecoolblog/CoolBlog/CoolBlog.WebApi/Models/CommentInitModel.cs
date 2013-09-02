using System;
using System.Linq;
using CoolBlog.Model;

namespace CoolBlog.WebApi.Models
{
    public class CommentInitModel
    {
        public string Text { get; set; }

        public Comment CreateComment(int postId, string sessionKey, CoolBlogEntity context)
        {
            var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
            var post = context.Posts.Find(postId);

            if (user == null || post == null)
            {
                throw new ArgumentNullException("User or post is not found!");    
            }

            return new Comment()
            {
                User = user,
                Post = post,
                PostId = postId,
                CreatorId = user.Id,
                CommentContent = this.Text,
                CreationDate = DateTime.Now
            };
        }
    }
}