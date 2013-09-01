using BankSystemAPI.Models;
using BankSystemAPI.Scripts;
using BankSystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BankSystemAPI.Controllers
{
    public class UsersController : ApiController
    {


        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostLoginUser(User user)
        {
            BankSystemEntities context = new BankSystemEntities();

            using (context)
            {
                context.Users.Add(user);
                context.SaveChanges();

                user.AuthKey = this.GenerateSessionKey(user.Id);
                context.SaveChanges();



                var response =
                    this.Request.CreateResponse(HttpStatusCode.Created,
                                    user);
                return response;
            }

        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var context = new BankSystemEntities();
            using (context)
            {

                var user = context.Users.FirstOrDefault(
                    u => u.Username == model.Username.ToLower()
                    && u.Password == model.Password);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }
                if (user.AuthKey == null)
                {
                    user.AuthKey = this.GenerateSessionKey(user.Id);
                    context.SaveChanges();
                }

                var loggedModel = new LoggedUserModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    SessionKey = user.AuthKey
                };

                var response =
               this.Request.CreateResponse(HttpStatusCode.Created,
                               loggedModel);
                return response;
            }
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
        {
            var context = new BankSystemEntities();
            using (context)
            {

                var user = context.Users.FirstOrDefault(
                    u => u.AuthKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("No user with such sessionKey logged");
                }
                user.AuthKey = null;
                context.SaveChanges();

                var response =
                this.Request.CreateResponse(HttpStatusCode.OK);

                return response;
            }
        }

        [HttpGet]
        [ActionName("get")]
        public UserMoneyModel GetUser(string sessionKey)
        {
            var context = new BankSystemEntities();
            using (context)
            {
                var user = context.Users.FirstOrDefault(
                    u => u.AuthKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("No user with such sessionKey logged");
                }
                else
                {
                    var model = new UserMoneyModel()
                    {
                        Id = user.Id,
                        AvelableMoney = user.AvelableMoney

                    };

                    return model;
                }
            }
        }

        [HttpPut]
        [ActionName("update")]
        public HttpResponseMessage PutLogoutUser(int money,string sessionKey)
        {
            var context = new BankSystemEntities();
            using (context)
            {
                
                var user = context.Users.FirstOrDefault(u => u.AuthKey == sessionKey);
                if (user==null)
                {
                    throw new InvalidOperationException("There is no such user loged");
                }
                user.AvelableMoney = money;
                context.SaveChanges();

                var model = new UserMoneyModel()
                {
                    Id = user.Id,
                    AvelableMoney = user.AvelableMoney
                };

                var response =
                this.Request.CreateResponse(HttpStatusCode.OK,model);

                return response;
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }
    }
}
