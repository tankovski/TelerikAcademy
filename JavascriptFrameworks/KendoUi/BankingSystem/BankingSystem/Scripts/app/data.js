window.persisters = (function () {
    var sessionKey = localStorage.getItem("sessionKey");;
    var username = localStorage.getItem("username");

    function saveUserData(user) {
        localStorage.setItem("username", user.username);
        localStorage.setItem("sessionKey", user.sessionKey);
        sessionKey = localStorage.getItem("sessionKey");
        username = localStorage.getItem("username");
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

    function putJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
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
                password: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    saveUserData(data);

				});
        },
        register: function (user) {

            var password = CryptoJS.SHA1(user.password).toString()

            user.password = password;
            return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    saveUserData(data);
				});
        },
        logout: function () {
            if (!sessionKey) {
                //gyrmi
            }
            var headers = {
                "X-sessionKey": sessionKey
            };
            //clear sessionKey
            sessionKey = "";
            return putJSON(this.apiUrl + "logout", headers);
        },
        get: function () {
            return getJSON(this.apiUrl + "get?sessionKey=" + sessionKey)
                .then(function (data) {

                    return data;
                }, function (data) {
                    alert(JSON.stringify(data));
                });
        },
        updateMoney: function (money) {
            return putJSON(this.apiUrl + "update?money=" + money + "&sessionKey=" + sessionKey)
        },
        currentUser: function () {
            return username;
        }
    });

    var LogPersister = Class.create({
        init: function (url) {
            this.url = url;
        },
        getLog: function () {

            return getJSON(this.url + "get?sessionKey=" + sessionKey)
        }
    })

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.log = new LogPersister(apiUrl + "log/");
        }
    });


    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());