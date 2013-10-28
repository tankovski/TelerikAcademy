/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />
/// <reference path="jquery-2.0.3.js" />

var persisters = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");
    var autorId = localStorage.getItem("userId");
    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.Username);
        localStorage.setItem("sessionKey", userData.SessionKey);
        localStorage.setItem("userId", userData.UserId);

        nickname = userData.Nickname;
        sessionKey = userData.SessionKey;
        autorId = userData.UserId;
    }
    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = "";
        sessionKey = "";
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.article = new ArticlePersister(this.rootUrl);
            this.comment = new CommentsPersister(this.rootUrl);
            this.subComment = new SubCommentPersister(this.rootUrl);
            this.vote = new VotesPersister(this.rootUrl);
        },
        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null
            && sessionKey != null;
            return isLoggedIn;
        },
        nickname: function () {
            return nickname;
        }
    });
    var UserPersister = Class.create({
        init: function (rootUrl) {
            //...api/user/
            this.rootUrl = rootUrl + "users/";
        },
        login: function (user, success, error) {
            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                password: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData,
				function (data) {
				    saveUserData(data);
				    success(data);
				}, error);
        },
        register: function (user, success, error) {
            var url = this.rootUrl + "register";
            var userData = {
                username: user.username,
                password: CryptoJS.SHA1(user.username + user.password).toString()
            };
            httpRequester.postJSON(url, userData,
				function (data) {
				    saveUserData(data);
				    success(data);
				}, error);
        },
        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;
            httpRequester.getJSON(url, function (data) {
                clearUserData();
                success(data);
            }, error)
        }
    });
    var ArticlePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "Articles/";
        },
        loadArticle: function (id, succes, error) {
            var url = this.rootUrl + "singleArticle/" + id;

            httpRequester.getJSON(url, succes, error);
        },
        loadAllArticles: function (succes, error) {
            var url = this.rootUrl + "all";

            httpRequester.getJSON(url, succes, error);
        },
        postArticle: function (article,succes,error) {
            var url = this.rootUrl + "create/" + sessionKey;

            httpRequester.postJSON(url, article, succes, error);
        },
        deleteArticle: function myfunction(id,succes,error) {
            var url = this.rootUrl + "delete/" + sessionKey + "/" + id;

            httpRequester.deleteJSON(url, succes, error);
        }
    });
    var CommentsPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "Comments/";
        },
        postComment: function (commentData,succes,error) {
            var url = this.rootUrl + "Add/" + sessionKey;

            httpRequester.postJSON(url, commentData, succes, error);
        },
        deleteComment: function myfunction(id,succes,error) {
            var url = this.rootUrl + "delete/" +sessionKey +"/"+id;

            httpRequester.deleteJSON(url, succes, error);
        }
    });

    var SubCommentPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "SubComments/";
        },
        postSubComment: function (subcomment,succes,error) {
            var url = this.rootUrl + "create/" + sessionKey;

            httpRequester.postJSON(url, subcomment, succes, error);
        },
        deleteSubComment: function (id,succes,error) {
            var url = this.rootUrl + "delete/" + sessionKey + "/" + id;

            httpRequester.deleteJSON(url, succes, error);
        }
    });

    var VotesPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "Votes/";
        },
        postVote: function (vote,succes,error) {
            var url = this.rootUrl + "create/" + sessionKey;

            httpRequester.postJSON(url, vote, succes, error);
        }
    });
    return {
        get: function (url) {
            return new MainPersister(url);
        }
    };
}());