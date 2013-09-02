namespace CoolBlog.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using CoolBlog.Model;
    using CoolBlog.WebApi.Models;
    using CoolBlog.WebApi.Persisters;
    using System.Linq;

    public class UsersController : BaseApiController
    {
        private static CoolBlogEntity context = new CoolBlogEntity();

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisterModel user)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UserDataPersister.CreateUser(user);
                string nickname;
                int id;
                string rank;
                UserLoginModel loginUser = new UserLoginModel()
                {
                    Username = user.Username,
                    AuthKey = user.AuthKey
                };

                var sessionKey = UserDataPersister.LoginUser(loginUser, out nickname, out id,out rank);

                return new UserLoggedModel()
                {
                    Id = id,
                    Nickname = nickname,
                    SessionKey = sessionKey
                };
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserLoginModel user)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                string nickname;
                int id;
                string rank;
                var sessionKey = UserDataPersister.LoginUser(user, out nickname, out id,out rank);
                return new UserLoggedModel()
                {
                    Nickname = nickname,
                    SessionKey = sessionKey,
                    Rank=rank
                };
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UserDataPersister.LogoutUser(sessionKey);
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAllUsers(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UserDataPersister.LoginUser(sessionKey);
                IEnumerable<UserMinimalModel> users = UserDataPersister.GetAllUsers();

                return users;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("info")]
        public HttpResponseMessage GetUserInfo(string sessionKey, int userId)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UserDataPersister.LoginUser(sessionKey);
                UserExtendedModel user = UserDataPersister.GetUser(userId);

                return user;
            });

            return responseMsg;
        }

        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage DeleteUser(int userId, string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var context = new CoolBlogEntity();
                var admin = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (admin==null)
                {
                    throw new ArgumentNullException("There is no user with this sessionKey loged!");   
                }
                if (admin.RankId != 2)
                {
                    throw new InvalidOperationException("This User Is Not Admin!");
                }
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                context.Users.Remove(user);
                context.SaveChanges();
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("promote")]
        public HttpResponseMessage PromoteUser(int userId,string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var context = new CoolBlogEntity();
                var admin = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (admin == null)
                {
                    throw new ArgumentNullException("There is no user with this sessionKey loged!");
                }
                if (admin.RankId != 2)
                {
                    throw new InvalidOperationException("This User Is Not Admin!");
                }
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                user.RankId = 2;
                context.SaveChanges();
            });

            return responseMsg;
        }
    }
}

