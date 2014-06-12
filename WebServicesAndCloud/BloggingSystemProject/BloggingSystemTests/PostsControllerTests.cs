using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BloggingSystemServices.Models;
using Newtonsoft.Json;
using Forum.Tests;
using System.Web.Http;
using System.Transactions;
using ForumServices.Controllers;
using System.Collections.Generic;
using BloggingSystemServices.Controllers;
using System.Net;
using System.Linq;

namespace BloggingSystemTests
{
    [TestClass]
    public class PostsControllerTests
    {
        public static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(PostsController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "ThreadsApi",
                    "api/posts/{postId}/comment",
                    new
                    {
                        controller = "posts",
                        action ="comment"
                    }),
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

        //Post new post tests
        [TestMethod]
        public void PostNewPost_WhenPostIsValid_MustReturnStatusCreatedAndPostId()
        {
            var post = new PostModel()
            {
                Title = "TESTPOST",
                Text = "TestText",
                Tags = new List<string> { "testTag" }
            };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", post, headers);
            var returnedPost = JsonConvert.DeserializeObject<AddedPost>(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.IsTrue(returnedPost.Id>0);
        }

        [TestMethod]
        public void PostNewPost_WhenPostDontHaveTags_MustReturnStatusCreatedAndPostId()
        {
            var post = new PostModel()
            {
                Title = "TESTPOST",
                Text = "TestText",
            };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", post, headers);
            var returnedPost = JsonConvert.DeserializeObject<AddedPost>(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.IsNotNull(returnedPost.Id);
        }

        [TestMethod]
        public void PostNewPost_WhenPostTitleIsNotValid_MustReturnStatusCodeBadRequest()
        {
            var post = new PostModel()
            {
                //not valid titel
                Title = null,
                Text = "TestText",
                Tags = new List<string> { "testTag" }
            };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", post, headers);
            var returnedPost = JsonConvert.DeserializeObject<AddedPost>(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void PostNewPost_WhenPostTextIsNotValid_MustReturnStatusCodeBadRequest()
        {
            var post = new PostModel()
            {
                //not valid titel
                Title = "TestTitle",
                Text = null,
                Tags = new List<string> { "testTag" }
            };

            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", post, headers);
            var returnedPost = JsonConvert.DeserializeObject<AddedPost>(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        //GetAll  posts by keywords
        [TestMethod]
        public void GetByTags_WhenOnePostHaveAllTags_MustReturnStatusCode200AndThePost()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var post = new PostModel()
            {
                Title = "TESTPOST",
                Text = "TestText",
                Tags = new List<string> { "testTag","random" }
            };

            AddedPost alreadyAdedPost = this.PostNewPost(post, headers);


            var response = this.httpServer.Get("api/posts?tags=testTag,random,TESTPOST", headers);
            var returnetPosts = JsonConvert.DeserializeObject<ICollection<FullPostModel>>(
                response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(returnetPosts.Count,1);
            Assert.AreEqual(returnetPosts.FirstOrDefault().Title, post.Title);
            Assert.AreEqual(returnetPosts.FirstOrDefault().Text, post.Text);

        }

        [TestMethod]
        public void GetByTags_NoPostHaveAllTags_MustReturnStatusCode200AndNoPosts()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var post = new PostModel()
            {
                Title = "TESTPOST",
                Text = "TestText",
                Tags = new List<string> { "testTag", "random" }
            };

            AddedPost alreadyAdedPost = this.PostNewPost(post, headers);


            var response = this.httpServer.Get("api/posts?tags=testTag,random2", headers);
            var returnetPosts = JsonConvert.DeserializeObject<ICollection<FullPostModel>>(
                response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(returnetPosts.Count, 0);

        }

        private AddedPost PostNewPost(PostModel post, Dictionary<string, string> headers)
        {
            
            var response = httpServer.Post("api/posts", post, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var addedPostModel = JsonConvert.DeserializeObject<AddedPost>(contentString);

            return addedPostModel;
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
