/// <reference path="../libs/class.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="dataPersister.js" />
/// <reference path="../libs/sammy-0.7.4.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="contorls.js" />

var controllers = (function () {
    var appKey = "Ri8HJoZQn5NEI7MG";

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(appKey);

        },
        initialisePaging: function (content) {
            this.attachUIEventHandlers(content);
            var self = this;
            var app = Sammy("#wrapper", function () {

                this.get("#/Home", function () {
                    localStorage.clear();
                    $("#mistDiv").remove();
                    self.loadNoUserUi(content);
                });
                this.get("#/posts", function () {
                    var isLoged = self.persister.isUserLogedIn();
                    if (isLoged) {
                        $("#mistDiv").remove();
                        self.loadPostsUi(content);
                    }
                    else {
                        window.location.replace('#/Home');
                    }

                });

                this.get("#/posts/create", function () {
                    self.loadPostForm("#wrapper");
                });

                this.get("#/posts/:tags", function () {

                    var tags = this.params["tags"].split(',');
                  
                      
                            self.loadPostsByTags(tags);
                       
                  

                    
                    
                });

                this.get("#/post/:id", function () {
                  
                    var id = this.params["id"];
                    
                        self.loadSinglePost(content, id);
                 
                    
                });

                this.get("#/post/:id/comment", function () {

                    var id = this.params["id"];
                    
                    self.loadCommentForm(content);


                });
            });

            app.run("#/Home");
        },
        loadNoUserUi: function (content) {
            var formsemplate = Mustache.compile(document.getElementById("log/reg-template").innerHTML);
            var startPage = controls.startPageView(formsemplate);
            startPage.render(content, "#tabs");
        },
        loadPostsUi: function (content) {
            var wellcomeTemplate = Mustache.compile(document.getElementById("wellcome-template").innerHTML);
            var postsTemplate = Mustache.compile(document.getElementById("posts-template").innerHTML);

            this.persister.post.getPosts()
                .then(function (data) {
                    
                    var postsPage = controls.PostsPageView(data);
                    postsPage.render(wellcomeTemplate, postsTemplate, content);
                }, function (data) {
                    alert(JSON.stringify(data));
                });




        },
        loadPostForm: function (content) {
            var postFormTemplate = Mustache.compile(document.getElementById("make-post-template").innerHTML);
            var postForm = controls.PostsFormView(postFormTemplate);

            postForm.render(content);
        },
        loadSinglePost: function (content, id) {
            var home = this;
            this.persister.post.getPostById(id)
                .then(function (post) {                    
                    home.persister.comment.getComments(id)
                        .then(function (comments) {
                            console.log(comments);
                            var wellcomeTemplate = Mustache.compile(document.getElementById("wellcome-template").innerHTML);
                            var postTemplate = Mustache.compile(document.getElementById("single-post-content").innerHTML);
                            var tagsTemplate = Mustache.compile(document.getElementById("tags-template").innerHTML);
                            var commentsTemplate = Mustache.compile(document.getElementById("comment-template").innerHTML);


                            var singlePostView = controls.SinglePostView(post,comments);
                            singlePostView.render(content, postTemplate, tagsTemplate, commentsTemplate, wellcomeTemplate);


                        }, function (data) {
                            alert(JSON.stringify(data));
                        });

                }, function (data) {
                    alert(JSON.stringify(data));
                });
            
        },
        loadPostsByTags:function (tags) {
            this.persister.post.getByTags(tags)
                .then(function (data) {
                    var wellcomeTemplate = Mustache.compile(document.getElementById("wellcome-template").innerHTML);
                    var postsTemplate = Mustache.compile(document.getElementById("posts-template").innerHTML);
                    var postsPage = controls.PostsPageView(data);
                    postsPage.render(wellcomeTemplate, postsTemplate, content);
                                }, function (data) {
                                    alert(JSON.stringify(data));
                                });
        },
        loadCommentForm: function (content) {

            var wellcomeTemplate = Mustache.compile(document.getElementById("leave-comment-template").innerHTML);
            var commentForm = controls.CommentsFormView(wellcomeTemplate);
            commentForm.render(content);
        },
        attachUIEventHandlers: function (content) {
            var wrapper = $("#wrapper");
            var that = this;
            var currentPostId="";
            wrapper.on('click', "#RegBtn", function () {
                var user = {
                    username: $("#usernameRegister").val(),
                    displayName: $("#displayNameRegister").val(),
                    password: $("#passwordRegister").val(),
                }

                that.persister.user.register(user);
            });

            wrapper.on('click', "#loginBtn", function () {
                var user = {
                    username: $("#usernameLogin").val(),
                    password: $("#passwordLogin").val(),
                }

                that.persister.user.login(user);
            });


            wrapper.on('click', "#logoutBtn", function () {

                localStorage.clear();
            });

            wrapper.on('click', "#postBtn", function () {
                var tagsInput = $("#tagsInput").val();
                tagsInput = tagsInput.split(',');
              
                var currentdate = new Date();
                var user = localStorage.getItem("username");
                var post = {
                    title: $("#titleInput").val(),
                    content: $("#ContentInput").val(),
                    date: currentdate.toLocaleString(),
                    creator: user,
                    tags:tagsInput
                };

                that.persister.post.create(post)
                    .then(function (data) {
                        window.location.replace("#/posts");

                    }, function (data) {
                        alert( JSON.stringify(data));
                    });
            });

            wrapper.on('click', "#tagsSearchBtn", function () {
                
                var tags = $("#TagsSearchInput").val();
                
                if (tags) {
                    window.location.replace("#/posts/" + tags);
                }
                else {
                    window.location.replace("#/posts");
                }
            });
            
            wrapper.on('click', "#CommentFormBtn", function () {

                var id = $(this).data("post-id");
                currentPostId = id;
                window.location.replace("#/post/" + id + "/comment");
            });

            wrapper.on('click', "#commentBtn", function () {

                var currentdate = new Date();
                var name = localStorage.getItem("username");
                var comment = {
                    content: $("#ContentCommentInput").val(),
                    author: name,
                    postId: currentPostId,
                    date:currentdate.toLocaleString()
                }

                that.persister.comment.addComment(comment)
                    .then(function () {
                        window.location.replace("#/post/" + currentPostId);
                    }, function (data) {
                        alert(JSON.stringify(data));
                    });
            });
            
        },
       

    });

    return {
        get: function () {
            return new Controller();
        }
    }
}());

$(function () {
    var controller = controllers.get();
    controller.initialisePaging("#content");
});