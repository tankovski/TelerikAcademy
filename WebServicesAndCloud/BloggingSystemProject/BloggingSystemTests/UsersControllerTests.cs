using BloggingSystemServices.Models;
using Forum.Tests;
using ForumServices.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;

namespace BloggingSystemTests
{
    [TestClass]
    public class UsersControllerTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                //new Route(
                //    "ThreadsApi",
                //    "api/threads/{threadId}/posts",
                //    new
                //    {
                //        controller = "threads",
                //        action ="posts"
                //    }),
                new Route(
                     "UsersApi",
                     "api/users/{action}",
                     new
                        {
                            controller = "users"
                        }),
                        
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };
            this.httpServer = new InMemoryHttpServer("http://localhost:/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        //RegisterUser
        [TestMethod]
        public void PostUser_RegisterValidUser_MustSaveInDbWithSessioKey()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            //var httpServer = new InMemoryHttpServer("http://localhost/");
            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]       
        public void PostUser_RegisterUserWithNotValidUsername_MustReturnBadRequestMsg()
        {
            var testUser = new UserModel()
            {
                //lenght must be at least 3
                Username = "NO",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostUser_RegisterUserWithNotValidPassword_MustReturnBadRequestMsg()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUsername",
                DisplayName = "VALIDNICK",
                //Must be at least 3
                AuthCode = new string('b', 3)
            };
            var response = httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        //LogoutUser
        [TestMethod]
        public void PutUser_LogoutUserThatIsLogged_MustReturnStatusCode200()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel model = this.RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = model.SessionKey;
            var response = this.httpServer.Put("api/users/logout",headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PutUser_LogoutUserThatIsNotLogged_MustReturnBadRequestMsg()
        {
                     
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = new string('b',50);
            var response = this.httpServer.Put("api/users/logout", headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PutUser_LogoutUserWithNotValidSessionKey_MustReturnBadRequestMsg()
        {

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = new string('b', 40);
            var response = this.httpServer.Put("api/users/logout", headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
