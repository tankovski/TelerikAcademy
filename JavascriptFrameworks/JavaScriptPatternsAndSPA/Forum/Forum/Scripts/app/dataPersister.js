/// <reference path="../libs/class.js" />
/// <reference path="../libs/everlive.all.js" />
/// <reference path="../libs/jquery-2.0.3.js" />


var persisters = (function () {

    var username = localStorage.getItem("username");
    var authCode = localStorage.getItem("authCode");

    function saveUser(user,data) {
        localStorage.setItem("username", user.username);
        localStorage.setItem("authCode", data.result.access_token);
        username = localStorage.getItem("username");
        authCode = localStorage.getItem("authCode");
    }
    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("authCode");
        authCode = "";
        username = "";
    }

    var MainPersister = Class.create({
        init: function (appKey) {
            this.app = new Everlive(appKey);
            this.user = new UsersPersister(this.app);
            this.post = new PostsPersister(this.app);
            this.tag = new TagPersister(this.app);
            this.comment = new CommentsPersister(this.app);
            
        },
        isUserLogedIn: function () {
            return username != null;
        },
        username: function () {
            return username;
        }
    })

    var UsersPersister = Class.create({
        init: function (app) {
            this.app = app;

        },
        register: function (user) {
            self = this;
            this.app.Users.register(user.username, user.password,
                {
                    DisplayName: user.displayName
                })
					.then(function (data) {
					    self.login(user);
					}, function (err) {
					    alert(JSON.stringify(err));
					});
        },
        login: function (user) {
            this.app.Users.login(user.username, user.password)
					.then(function (data) {
					    saveUser(user,data);
					    window.location.replace("#/posts");
					}, function (err) {
					    alert(JSON.stringify(err));
					});
        },
        logout: function () {

        }
    });

    var PostsPersister = Class.create({
        init: function (app) {
            this.app = app;
        },
        create: function (post) {
            this.app.setup.token = authCode;
            var data = Everlive.$.data('Posts');
            return  data
                  .create(
                  {
                      'Title': post.title,
                      'Content': post.content,
                      'Postdate': post.date,
                      'Tags': post.tags,
                      'Creator': post.creator
                  });

            
        },
        getPosts: function () {
            this.app.setup.token = authCode;
            var data = Everlive.$.data('Posts');
            var query = new Everlive.Query();
            query.orderDesc('CreatedAt');
            return data.get(query);
        },
        getPostById: function (id) {
            this.app.setup.token = authCode;
            var data = Everlive.$.data('Posts');
            return data.getById(id);
        },
        getByTags: function (tags) {
            this.app.setup.token = authCode;
            var data = Everlive.$.data('Posts');
            var query = new Everlive.Query();
            query.where().all('Tags', tags);
            query.orderDesc('CreatedAt');
            return data.get(query);
        },
        addComment:function (postId,comment) {
            this.app.setup.token = authCode;
            var data = Everlive.$.data('Posts');
            data.getById(postId)
                .then(function myfunction(data) {
                    var comments = data.result.Comments;
                    comments[comments.length] = comment;

                    var posts = Everlive.$.data('Posts');
                    posts.updateSingle({ Id: postId, 'Comments': comments })
                        .then(function () {
                            window.location.replace("#post/" + postId);
                        }, function (data) {
                            alert(JSON.stringify(data));
                        })
                });
    }
    });
  
    var CommentsPersister = Class.create({
        init: function (app) {
            this.app = app;
        },
        addComment: function (comment) {
            this.app.setup.token = authCode;
            var data = Everlive.$.data('Comments');
            return data
                  .create(
                  {
                      'Content': comment.content,
                      'CreatedAt': comment.date,
                      'Author': comment.author,
                      'PostId': comment.postId
                  });
        },
        getComments: function (id) {
            this.app.setup.token = authCode;
            var filter = new Everlive.Query();
            filter.where().eq('PostId', id);
            var data = Everlive.$.data('Comments');
            return data.get(filter);
        }
    })
return {
    get: function (appKey) {
        return new MainPersister(appKey);
    }
}
}());