/// <reference path="../libs/_references.js" />
window.persisters = (function () {

    var bashUsername = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.Nickname);
        localStorage.setItem("sessionKey", userData.SessionKey);
        bashUsername = userData.Nickname;
        sessionKey = userData.SessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        bashUsername = "";
        sessionKey = "";
    }

    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                authKey: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    saveUserData(data);
				});
        },
        register: function (username, password, nickname, gender, rankId, email) {
            var user = {
                username: username,
                authKey: CryptoJS.SHA1(password).toString(),
                nickname: nickname,
                gender: gender,
                rankId: rankId,
                email: email
            };
            return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    saveUserData(data);
				    return data.displayName;
				});
        },
        logout: function () {
            if (!sessionKey) {
                //gyrmi
            }
            var headers = {
                "X-sessionKey": sessionKey
            };
            clearUserData();
            return putJSON(this.apiUrl + "logout", headers);
        },
        currentUser: function () {
            return bashUsername;
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());