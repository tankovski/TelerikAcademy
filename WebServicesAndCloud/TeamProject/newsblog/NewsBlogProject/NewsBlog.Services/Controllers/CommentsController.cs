using NewsBlog.Model;
using NewsBlog.Repository;
using NewsBlog.Services.Models;
using NewsBlog.Services.Persisters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsBlog.Services.Controllers
{
    public class CommentsController : ApiController
    {
        private CommentsRepository commentsRepository;


        public CommentsController()
        {
            DbContext dbContext = new NewsBlogEntities();
            this.commentsRepository = new CommentsRepository(dbContext);
        }

        public CommentsController(CommentsRepository repository)
        {
            this.commentsRepository = repository;
        }

        [HttpPost]
        public HttpResponseMessage Add(string sessionKey, [FromBody]CommentReceivedModel comment)
        {
            if (comment == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send null comment.");
            }

            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace comment.");
            }

            if (string.IsNullOrWhiteSpace(comment.Author))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send comment with no author name.");
            }

            if (comment.ArticleId < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send comment with no article name.");
            }

            if (comment.Date == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send comment with no date.");
            }

            var isValidSessionKey = UserPersister.ValidateSessionKey(sessionKey);
            if (!isValidSessionKey)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Session Key.");
            }

            Comment newComment = CreateComment(comment);

            var addedComment = commentsRepository.Add(newComment);

            return Request.CreateResponse(HttpStatusCode.OK,addedComment.Id);
        }

        private Comment CreateComment(CommentReceivedModel comment)
        {
            var user = UserPersister.GetUser(comment.Author);
            var newComment = new Comment();
            newComment.ArticleId = comment.ArticleId;
            newComment.AuthorId = user.Id;
            newComment.Content = comment.Content;
            newComment.Date = comment.Date;

            return newComment;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string sessionKey, int id)
        {
            if (id < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Incorrect comment id.");
            }

            var isValidSessionKey = UserPersister.ValidateSessionKey(sessionKey);
            if (!isValidSessionKey)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Session Key.");
            }

            commentsRepository.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK,"Success");
        }
    }
}
