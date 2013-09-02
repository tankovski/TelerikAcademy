/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getRegisterView() {
        return getTemplate("register-form");
    }

    function getAllUsersView() {
        return getTemplate("allUsers");
    }

    function getSingleUserView() {
        return getTemplate("singleUser");
    }

    function getPostsView() {
        return getTemplate("posts-view");
    }

    function getRecentPostsView() {
        return getTemplate("recent-posts");
    }

    function getCreatePostView() {
        return getTemplate("createPost");
    }

    function getSinglePostView() {
        return getTemplate("single-post");
    }

    return {
        getLoginView: getLoginView,
        getRegisterView: getRegisterView,
        getAllUsersView: getAllUsersView,
        getSingleUserView: getSingleUserView,
        getPostsView: getPostsView,
        getRecentPostsView: getRecentPostsView,
        getSingleUserView: getSingleUserView,
        getCreatePostView: getCreatePostView,
        getSinglePostView: getSinglePostView
    };
}());