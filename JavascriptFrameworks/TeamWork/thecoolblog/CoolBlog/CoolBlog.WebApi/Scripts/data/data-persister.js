/// <reference path="../lib/_references.js" />

window.persisters = (function () {
    var username = localStorage.getItem("username");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("username", userData.Nickname);
        localStorage.setItem("sessionKey", userData.SessionKey);
        bashUsername = userData.Nickname;
        sessionKey = userData.SessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("sessionKey");
        username = "";
        sessionKey = "";
    }

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UserPersister(apiUrl + "users/");
            this.posts = new PostPersister(apiUrl + "posts/");
        }
    });

    var UserPersister = Class.create({
        init: function (url) {
            this.url = url;
        },

        login: function (username, password) {
            var user = {
                username: username,
                authKey: CryptoJS.SHA1(password).toString()
            };
            return httpRequester.postJSON(this.url + "login", user)
				.then(function (data) {
				    saveUserData(data);
				});
        },

        register: function (username, password, nickname, gender, email) {
            var user = {
                username: username,
                authKey: CryptoJS.SHA1(password).toString(),
                nickname: nickname,
                gender: gender,
                rankId: 1,
                email: email
            };
            return httpRequester.postJSON(this.url + "register", user)
				.then(function (data) {
				    saveUserData(data);
				    return data.displayName;
				});
        },

        logout: function () {
            var key;
            if (!sessionKey) {
                //error
            }
            else {
                key = sessionKey;
            }

            clearUserData();
            return httpRequester.getJSON(this.url + "logout?sessionKey=" + key);
        },

        currentUser: function () {
            return localStorage.getItem("username");
        },

        getAll: function () {
            var url = this.url + "all/" + sessionKey;

            return httpRequester.getJSON(url);
        },
        getSingle: function (id) {
            var url = this.url + id + "/info/" + sessionKey;

            return httpRequester.getJSON(url);
        }
    })

    var PostPersister = Class.create({
        init: function (baseUrl) {
            this.baseUrl = baseUrl;
        },
        getAll: function () {
            var url = this.baseUrl + "getall";
            return httpRequester.getJSON(url);
        },
        getAllByTag: function (tag) {
            var url = this.baseUrl + "getByTag?tag=" + tag;
            return httpRequester.getJSON(url);
        },
        getSingle: function (id) {
            var url = this.baseUrl + "getsingle/" + id + '/item';
            return httpRequester.getJSON(url);
        },
        comment: function (commentData, postId) {
            var url = this.baseUrl + 'comment/' + postId + '/' + sessionKey;
            return httpRequester.postJSON(url, commentData);
        },
        create: function (post) {
            var url = this.baseUrl + "create/" + sessionKey;

            return httpRequester.postJSON(url, post);
        }
    });


    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());