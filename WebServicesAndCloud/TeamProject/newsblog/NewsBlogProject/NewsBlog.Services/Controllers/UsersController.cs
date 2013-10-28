using NewsBlog.Model;
using NewsBlog.Notifications;
using NewsBlog.Repository;
using NewsBlog.Services.Models;
using NewsBlog.Services.Persisters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsBlog.Services.Controllers
{
    public class UsersController : ApiController
    {
        private NewsBlogEntities context;
        private IRepository<User> repository;

        public UsersController()
        {
            this.context = new NewsBlogEntities();
            this.repository = new Repository<User>(this.context);
        }

        public UsersController(IRepository<User> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]User value)
        {
            if (value == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send null user.");
            }

            if (string.IsNullOrWhiteSpace(value.Username))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Username.");
            }

            if (string.IsNullOrWhiteSpace(value.Password))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Password.");
            }

            value = this.repository.Add(value);

            string sessionKey = UserPersister.CreateSessionKeyByUserId(value.Id);

            return this.Request.CreateResponse(HttpStatusCode.OK, new SessionKeyModel { UserId = value.Id, Username = value.Username, SessionKey = sessionKey });
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]User user)
        {
            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send null user.");
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Username.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Can't send empty or whitespace Password.");
            }

            var userInDB = this.repository.All().Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (userInDB == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
            }

            string sessionKey = UserPersister.CreateSessionKeyByUserId(userInDB.Id);
            return this.Request.CreateResponse(HttpStatusCode.OK, new SessionKeyModel {UserId=userInDB.Id, Username = userInDB.Username, SessionKey = sessionKey });
        }

        [HttpGet]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            bool isLogged = UserPersister.ValidateSessionKey(sessionKey);

            if (!isLogged)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
            }

            User user = this.repository.All().Where(x => x.SessionKey == sessionKey).FirstOrDefault();
            
            user.SessionKey = null;
            this.repository.Update(user.Id, user);

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
