using Forum.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystemData;
using System.Text;
using System.Web.Http.ValueProviders;
using Forum.WebAPI.Attributes;
using BloggingSystemServices.Models;

namespace ForumServices.Controllers
{
    public class UsersController : BaseApiController
    {

        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";

        private const int MinNicknameLength = 6;
        private const int MaxNicknameLength = 30;
        private const string ValidDisplayNameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggIngSystemEntities();
                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateDisplayName(model.DisplayName);
                        this.ValidateAuthCode(model.AuthCode);
                        var usernameToLower = model.Username.ToLower();
                        var nicknameToLower = model.DisplayName.ToLower();
                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == usernameToLower
                            || usr.DisplayName.ToLower() == nicknameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("Users exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            DisplayName = model.DisplayName,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.UsersId);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.DisplayName, 
                            SessionKey = user.SessionKey
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                                            loggedModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggIngSystemEntities();
                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateAuthCode(model.AuthCode);
                        var usernameToLower = model.Username.ToLower();
                        var user = context.Users.FirstOrDefault(
                            u => u.Username == usernameToLower
                            && u.AuthCode == model.AuthCode);

                        if (user == null)
                        {
                            throw new InvalidOperationException("Invalid username or password");
                        }
                        if (user.SessionKey == null)
                        {
                            user.SessionKey = this.GenerateSessionKey(user.UsersId);
                            context.SaveChanges();
                        }

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.DisplayName,
                            SessionKey = user.SessionKey
                        };

                        var response =
                       this.Request.CreateResponse(HttpStatusCode.Created,
                                       loggedModel);
                        return response;
                    }

                });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {

            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    

                    var context = new BloggIngSystemEntities();
                    using (context)
                    {
                        this.ValidateSessionKey(sessionKey);
                        var user = context.Users.FirstOrDefault(
                            u => u.SessionKey == sessionKey);

                        if (user == null)
                        {
                            throw new InvalidOperationException("No user with such sessionKey logged");
                        }
                        user.SessionKey = null;
                        context.SaveChanges();

                        var response =
                        this.Request.CreateResponse(HttpStatusCode.OK);

                        return response;
                    }

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

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateDisplayName(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (nickname.Length < MinNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at least {0} characters long",
                    MinNicknameLength));
            }
            else if (nickname.Length > MaxNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be less than {0} characters long",
                    MaxNicknameLength));
            }
            else if (nickname.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Nickname must contain only Latin letters, digits .,_");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }

        }
    }
}

