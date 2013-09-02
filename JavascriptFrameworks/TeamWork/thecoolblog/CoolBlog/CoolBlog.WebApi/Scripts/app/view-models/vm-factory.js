/// <reference path="../../lib/_references.js" />
/// <reference path="../../data/createPersister.js" />

window.vmFactory = (function () {
    var data = null;

    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getUsersVM() {

        
        return data.users.getAll()
              .then(function (users) {
                  var viewModel =
                      {
                          users: users
                      }
                  return new kendo.observable(viewModel);

              }, function (data) {
                  alert(JSON.stringify(data));
              })
    }

    function getLoginViewModel(successCallback) {
        var viewModel = {
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            },
        };
        return kendo.observable(viewModel);
    };

    function getRegisterViewModel(successCallback) {
        var viewModel = {
            register: function () {
                data.users.register(
                    this.get("username"),
                    this.get("password"),
                    this.get("nickname"),
                    this.get("gender"),
                    this.get("rankId"),
                    this.get("email")
                    )
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            }
        };

        return kendo.observable(viewModel);
    };

    function getSingleUserVM(id) {

        return data.users.getSingle(id)
              .then(function (user) {
                  var viewModel =
                      {
                          nickname: user.Nickname,
                          gender: user.Gender,
                          email: user.Email,
                          img: "../../imgs/" + user.Gender + ".ico"

                      }
                  return new kendo.observable(viewModel);

              }, function (data) {
                  alert(JSON.stringify(data));
              })
    }

    function getCreatePostVM(successCallback) {
        var viewModel =
            {
                postContent: "Content",
                title: "Title",
                creationDate: new Date().toLocaleString(),
                aproved: true,
                send: function () {
                    
                    var post =
                        {
                            postContent: this.get("postContent"),
                            title: this.get("title"),
                            creationDate: this.get("creationDate")
                        }
                    var self = this;
                    data.posts.create(post)
                        .then(function (data) {
                            self.set("postContent", "Content");
                            self.set("title", "Title");
                            self.set("title", new Date().toLocaleString());
                            if (successCallback) {

                                successCallback(data);
                            }
                        }, function (data) {
                            alert(JSON.stringify(data));
                        })
                }
            };

        return kendo.observable(viewModel);
    }

    function getPostsVM() {
        return data.posts.getAll().then(function (posts) {
            var filteredPosts = _.filter(posts, function (post) { return post.approved; });
            var sortedPosts = _.sortBy(filteredPosts, function (post) { return post.postDate; });
            var postsViewModel = {
                posts: sortedPosts.reverse()
            };
            return kendo.observable(postsViewModel);
        }, function (err) { alert("error in posts persister"); });
    }

    function getPostsByTagVM(tag) {
        console.log(data.posts.getAllByTag);
        return data.posts.getAllByTag(tag).then(function (posts) {
            var sortedPosts = _.sortBy(posts, function (post) { return post.postDate; });
            var postsViewModel = {
                posts: sortedPosts.reverse()
            };
            return kendo.observable(postsViewModel);
        }, function (err) { console.log(err.responseText); });
    }

    function getRecentPostsVM() {
        return data.posts.getAll().then(function (posts) {
            var sortedPosts = _.sortBy(posts, function (post) { return post.postDate; });
            var postsViewModel = {
                posts: _.first(sortedPosts.reverse(),5)
            };
            return kendo.observable(postsViewModel);
        }, function (err) { alert("error in posts persister"); });
    }

    function getSinglePostVM(id) {

        return data.posts.getSingle(id)
              .then(function (post) {
                  var date = post.postDate;
                  date = date.substring(0, date.indexOf('T'));
                  console.log(post.comments);
                  var viewModel =
                      {
                          id: post.id,
                          title: post.title,
                          postedBy: post.postedBy,
                          postedById: post.postedById,
                          postDate: date,
                          text: post.text,
                          tags: post.tags,
                          comments: post.comments,
                          publish: function () {
                              var commentData = {
                                  text: this.get("commentContent"),
                                  creatorId: localStorage.getItem("nickname")
                              }
                              data.posts.comment(commentData, post.id)
                                .then(function (data) {
                                    console.log(data);
                                }, function (err) {
                                    console.log(err);
                                });
                          },
                          commentContent: "Enter your comment here."
                      }
                  return new kendo.observable(viewModel);

              }, function (data) {
                  alert(JSON.stringify(data));
              })
    }

    return {
        getLoginVM: getLoginViewModel,
        getRegisterVM: getRegisterViewModel,
        getUsersVM: getUsersVM,
        getSingleUserVM: getSingleUserVM,
        getPostsVM: getPostsVM,
        getRecentPostsVM: getRecentPostsVM,
        getCreatePostVM: getCreatePostVM,
        getSinglePostVM: getSinglePostVM,
        getPostsByTagVM: getPostsByTagVM,
        setPersister: function (persister) {
            data = persister
        }
    };
}());