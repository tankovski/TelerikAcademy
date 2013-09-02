using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CoolBlog.Model;
using CoolBlog.WebApi.Models;
using System.Net.Http;
using CoolBlog.WebApi.Persisters;

namespace CoolBlog.WebApi.Controllers
{
    public class PostsController : BaseApiController
    {
        private CoolBlogEntity context = new CoolBlogEntity();

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable<PostModel> GetAll()
        {
            return context.Posts.Where(p=>p.Approved==true).Select(PostModel.FromPost).ToList();
        }

        [HttpGet]
        [ActionName("getSingle")]
        public HttpResponseMessage GetSingle(int id)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var post = context.Posts.Find(id);
                if (post == null)
                {
                    throw new InvalidOperationException("Post doesn't exist or cannot be reached.");
                }

                var postModel = new PostModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    PostedBy = post.User.Username,
                    PostedById = post.User.Id,
                    PostDate = post.CreationDare,
                    Text = post.PostContent,
                    Comments = post.Comments.AsQueryable().Select(CommentModel.FromComment),
                    Tags =
                        from tag in post.Tags
                        select tag.Name
                };
                return postModel;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("getByTag")]
        public HttpResponseMessage GetByTag(string tag)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var posts = context.Posts.Where(post =>
                    post.Tags.Any(t => t.Name.ToLower() == tag.ToLower()))
                        .Select(PostModel.FromPost).ToList();

                return posts;
            });

            return responseMsg;
        }

        [ActionName("create")]
        [HttpPost]
        public HttpResponseMessage PostAPost(PostCreateModel model, string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                if (model.Title == null || model.Title.Length == 0)
                {
                    throw new ArgumentException("You must have post title!");
                }
                if (model.PostContent == null || model.PostContent.Length == 0)
                {
                    throw new ArgumentException("You must have post content!");
                }
                var context = new CoolBlogEntity();

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user==null)
                {
                    throw new InvalidOperationException("No user with this sessionKey");
                }
                
                Post post = new Post()
                {
                    Title = model.Title,
                    PostContent = model.PostContent,
                    CreationDare=model.CreationDate,
                    User=user,
                    Tags = PostDataPersister.GetPostTitleWords(model.Title).ToList(),
                    Approved = true
                };
                context.Posts.Add(post);
                context.SaveChanges();
                model.Id = post.Id;
                
                return model;
            });

            return responseMsg;
        }

        [ActionName("disapprove")]
        [HttpPut]
        public HttpResponseMessage UpdateAPost(PostApproveModel model, int id, string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var post = context.Posts.Find(id);
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("No user with this sessionKey");
                }
                if (post == null)
                {
                    throw new InvalidOperationException("No post with this id");
                }

                post.Approved = model.Approved;
                context.SaveChanges();

                return model;
            });

            return responseMsg;
        }

        [ActionName("comment")]
        [HttpPost]
        public HttpResponseMessage PostAComment(CommentInitModel model, int id, string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var context = new CoolBlogEntity();

                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("No user with this sessionKey");
                    }

                    Comment comment = model.CreateComment(id, sessionKey, context);
                    context.Comments.Add(comment);
                    context.SaveChanges();

                    return model;
                }
            });

            return responseMsg;
        }
    }
}
