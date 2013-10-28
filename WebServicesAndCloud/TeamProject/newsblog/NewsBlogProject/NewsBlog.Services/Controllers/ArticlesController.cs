using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsBlog.Model;
using NewsBlog.Repository;
using NewsBlog.Services.Models;
using NewsBlog.Services.Persisters;
using NewsBlog.Notifications;
using AccessinImagesViaDropbox;

namespace NewsBlog.Services.Controllers
{
    public class ArticlesController : ApiController
    {
        private NewsBlogEntities context;
        private IRepository<Article> repository;

        public ArticlesController()
        {
            this.context = new NewsBlogEntities();
            this.repository = new Repository<Article>(this.context);
        }

        public ArticlesController(IRepository<Article> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ActionName("all")]
        public IEnumerable<ArticleDetails> GetAllArticles()
        {
            var data = this.repository.All();

            List<ArticleDetails> articles = new List<ArticleDetails>();

            foreach (var article in data)
            {
                var newArticleDetails = new ArticleDetails(article);

                articles.Add(newArticleDetails);
            }

            return articles;
        }

        [HttpGet]
        [ActionName("singleArticle")]
        public HttpResponseMessage GetArticle(int id)
        {
            var article = this.repository.All().Where(x => x.Id == id).FirstOrDefault();

            if (article == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            var articleModel = new ArticleDetails(article);

            return this.Request.CreateResponse(HttpStatusCode.OK, articleModel);
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateArticle(string sessionKey, [FromBody]ArticleModelReceived value)
        {
            bool isValid = UserPersister.ValidateSessionKey(sessionKey);
            if (!isValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid session key");
            }

            if (value == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send null article.");
            }

            if (string.IsNullOrWhiteSpace(value.Title))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Title.");
            }

            if (string.IsNullOrWhiteSpace(value.Content))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Content.");
            }

            if (string.IsNullOrWhiteSpace(value.Author))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Author.");
            }

            var article = new Article();
            var articleAuthor = UserPersister.GetUser(value.Author);
            article.Title = value.Title;
            article.Content = value.Content;
            article.Date = DateTime.Now;
            article.AuthorId = articleAuthor.Id;

            foreach (var image in value.Images)
            {
                string imageUrl = null;
                if (image.Url == null)
                {
                    imageUrl = DropboxApp.ReturnUrlWhenBrowsingImageFromPC(image);
                }
                else
                {
                    imageUrl = DropboxApp.ReturnUrlWhenDownloadingImageFromIN(image.Url);
                }

                Image newImage = new Image { Url = imageUrl };
                article.Images.Add(newImage);
            }

            this.repository.Add(article);

            PubnubNotification.SendNotification(article.Title + " has been created.");

            return this.Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpDelete]
        [ActionName("Delete")]
        public HttpResponseMessage DeleteArticle(string sessionKey, int id)
        {
            bool isValid = UserPersister.ValidateSessionKey(sessionKey);
            if (!isValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid session key");
            }

            var article = this.repository.All().Where(x => x.User.SessionKey == sessionKey && x.Id == id).FirstOrDefault();

            if (article == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "You can delete only your articles!");
            }

            this.repository.Delete(article.Id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
