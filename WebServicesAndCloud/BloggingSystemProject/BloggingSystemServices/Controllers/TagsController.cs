using Forum.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystemData;
using BloggingSystemServices.Models;
using System.Web.Http.ValueProviders;
using Forum.WebAPI.Attributes;

namespace BloggingSystemServices.Controllers
{
    public class TagsController : BaseApiController
    {
        private const int SessionKeyLength = 50;

        public IQueryable<TagModel> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
            () =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BloggIngSystemEntities();
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("No user with this sessionKey is logged!");
                }

                var tagEntities = context.Tags.ToList();

                var tagModels =
                    (from tag in tagEntities
                     select new TagModel()
                     {
                         Id = tag.TagId,
                         Name = tag.TagName,
                         Posts = tag.Posts.Count
                     }).OrderBy(t => t.Name);



                return tagModels.AsQueryable();

            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<FullPostModel> GetAllPosts(int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
           () =>
           {
               this.ValidateSessionKey(sessionKey);

               var context = new BloggIngSystemEntities();
               var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

               if (user == null)
               {
                   throw new InvalidOperationException("No user with this sessionKey is logged!");
               }

               var tagEntitie = context.Tags.FirstOrDefault(t => t.TagId == tagId);

               if (tagEntitie == null)
               {
                   throw new InvalidOperationException("No tag with this id exists!");
               }

               var postModels =
                             (from post in tagEntitie.Posts
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
                              }).OrderByDescending(p => p.PostDate);

               return postModels.AsQueryable();

           });

            return responseMsg;
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
