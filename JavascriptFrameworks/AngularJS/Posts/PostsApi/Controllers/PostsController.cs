using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PostsData;
using PostsApi.Models;

namespace PostsApi.Controllers
{
    public class PostsController : ApiController
    {
        private PostsDBEntities db = new PostsDBEntities();

        // GET api/Posts
        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable<PostFullModel> GetPosts()
        {
            var posts= db.Posts.ToList();

            var models =
                from post in posts
                select new PostFullModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    PostContent = post.PostContent,
                    PostDate = post.PostDate
                };

            return models;
        }

        [HttpGet]
        [ActionName("byCat")]
        public IEnumerable<PostFullModel> GetPosts(int categoryId)
        {
            var posts = db.Posts.Where(p => p.Categories.Any(c => c.Id == categoryId)).ToList();
            var models =
                from post in posts
                select new PostFullModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    PostContent = post.PostContent,
                    PostDate = post.PostDate,
                    Categories =
                    from cat in post.Categories
                    select new CategoryModel()
                    {
                        Id = cat.Id,
                        Name = cat.Name
                    }

                };

            return models;
        }

        // GET api/Posts/5
        [HttpGet]
        [ActionName("single")]
        public PostFullModel GetPost(int id)
        {
            Post post = db.Posts.Find(id);
              
            if (post == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var model = new PostFullModel()
            {
                Id = post.Id,
                Title = post.Title,
                PostContent = post.PostContent,
                PostDate = post.PostDate,
                Categories =
                from cat in post.Categories
                select new CategoryModel()
                {
                    Id = cat.Id,
                    Name = cat.Name
                }

            };

            return model;
        }

        // PUT api/Posts/5
        public HttpResponseMessage PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != post.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Posts
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage PostPost(PostCreateModel model)
        {
           
                var post = new Post()
                {
                    Title = model.Title,
                    PostContent = model.PostContent,
                    PostDate = model.PostDate,
                };

                var categories = db.Categories.ToList();
                var categoryNames = categories.Select(c => c.Name).ToList();
                for (int i = 0; i < categoryNames.Count; i++)
                {
                    if (model.Categories.Contains(categoryNames[i]))
                    {
                        post.Categories.Add(categories[i]);
                        model.Categories.Remove(categoryNames[i]);
                    }
                }

                foreach (var cat in model.Categories)
                {
                    var category = new Category()
                    {
                        Name = cat
                    };

                    post.Categories.Add(category);
                }

                db.Posts.Add(post);
                db.SaveChanges();
                model.Id = post.Id;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = post.Id }));
                return response;
            
        }

        // DELETE api/Posts/5
        public HttpResponseMessage DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Posts.Remove(post);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}