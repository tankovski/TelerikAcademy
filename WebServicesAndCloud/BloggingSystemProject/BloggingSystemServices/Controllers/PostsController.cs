using BloggingSystemData;
using BloggingSystemServices.Models;
using Forum.WebAPI.Attributes;
using Forum.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;


namespace BloggingSystemServices.Controllers
{
    public class PostsController : BaseApiController
    {
        private const int SessionKeyLength = 50;

        public HttpResponseMessage PostNewPost(PostModel post,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggIngSystemEntities();
                    using (context)
                    {
                        this.ValidatePost(post);
                        this.ValidateSessionKey(sessionKey);

                        var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                        if (user==null)
                        {
                            throw new InvalidOperationException("No user with this sessionKey loged");
                        }

                        string[] tagsFromTitle = post.Title.Split(
                            new char[] { ' ', '.', ',', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var tag in tagsFromTitle)
                        {
                            if (!post.Tags.Contains(tag.ToLower()))
                            {
                                post.Tags.Add(tag.ToLower());
                            }
                        }

                        var postEntety = new Post()
                        {
                            UserId = user.UsersId,
                            Title = post.Title,
                            PostContent = post.Text,
                            Tags =
                                 (from tag in post.Tags
                                  select new Tag()
                                  {
                                      TagName = tag
                                  }).ToList()
                        };

                        context.Posts.Add(postEntety);
                        context.SaveChanges();

                        var AddedPost = new AddedPost()
                        {
                            Title = postEntety.Title,
                            Id = postEntety.PostId
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                                                                   AddedPost);
                        return response;
                    }                  
                });

            return responseMsg;
        }

        public IQueryable<FullPostModel> GetAllPosts(
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggIngSystemEntities();

                    
                        this.ValidateSessionKey(sessionKey);

                        var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                        if (user==null)
                        {
                            throw new InvalidOperationException("No user with this sessionKey logged!");
                        }

                        var postEnteties = context.Posts.ToList();

                        var postModels =
                            (from post in postEnteties
                             select new FullPostModel()
                             {
                                 Id = post.PostId,
                                 Title = post.Title,
                                 PostedBy = post.User.DisplayName,
                                 PostDate = post.PostDate,
                                 Text = post.PostContent,
                                 Tags = post.Tags != null ?
                                 (from tag in post.Tags
                                  select tag.TagName).ToList() : null,
                                 Comments = post.Comments != null ?
                                 (from comment in post.Comments
                                  select new CommentModel()
                                  {
                                      Text = comment.CommentContent,
                                      CommentedBy = comment.User.DisplayName,
                                      PostDate = comment.PostDate
                                  }).ToList() : null
                             });

                        return postModels.OrderByDescending(p=>p.PostDate).AsQueryable();
                   

                });

            return responseMsg;
        }

        public IQueryable<FullPostModel> GetAllPosts(int page, int count,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAllPosts(sessionKey)
                .Skip(page * count)
                .Take(count);

            return models.OrderByDescending(p => p.PostDate);
        }

        public IQueryable<FullPostModel> GetAllPosts(string keyword,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = GetAllPosts(sessionKey).Where(p => p.Title.ToLower()
                .Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Contains(keyword.ToLower()));

            return models.OrderByDescending(p => p.PostDate);
        }

        public IQueryable<FullPostModel> GetAllPostsByTag(string tags,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            string[] tagsArray = tags.ToLower().Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var models = GetAllPosts(sessionKey).Where(p=>tagsArray.All(t=> p.Tags.Select(x=> x.ToLower()).Contains(t.ToLower())));
            
            return models.OrderByDescending(p => p.PostDate);
        }

        [ActionName("comment")]
        public HttpResponseMessage PutCommentToPost(int postId,CommentModel commentModel,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggIngSystemEntities();

                    this.ValidateSessionKey(sessionKey);

                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                    if (user==null)
                    {
                        throw new InvalidOperationException("No user with this sessionKey logged!");
                    }

                    var post = context.Posts.FirstOrDefault(p => p.PostId == postId);
                    if (post==null)
                    {
                        throw new InvalidOperationException("No post with this Id!");
                    }

                    var comment = new Comment()
                    {
                        CommentContent = commentModel.Text,
                        PostDate = DateTime.Now,
                        UserId = user.UsersId
                    };

                    post.Comments.Add(comment);
                    context.SaveChanges();

                    var response =
                            this.Request.CreateResponse(HttpStatusCode.Created);
                    return response;
                    
                });

            return responseMsg;
        }



        private void ValidatePost(PostModel post)
        {
            if (post.Title == null || post.Title.Length == 0)
            {
                throw new ArgumentNullException("Posts must have title!");
            }
            else if (post.Text == null || post.Text.Length == 0)
            {
                throw new ArgumentNullException("Posts must have content!");
            }
        }

        private void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey == null || sessionKey.Length == 0)
            {
                throw new ArgumentNullException("There is no session key");
            }
            else if (sessionKey.Length != SessionKeyLength)
            {
                throw new InvalidOperationException("The sesionKey must be 50 symbols long");
            }
        }
    }
}
