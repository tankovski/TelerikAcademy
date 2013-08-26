/// <reference path="../libs/require.js" />

define(["Class", "httpRequester","crypto"],
    function (Class, httpRequester, CryptoJS) {

            var persisters = (function () {
                var nickname = localStorage.getItem("nickname");
                var sessionKey = localStorage.getItem("sessionKey");
                function saveUserData(userData) {
                    localStorage.setItem("nickname", userData.nickname);
                    localStorage.setItem("sessionKey", userData.sessionKey);
                    nickname = userData.nickname;
                    sessionKey = userData.sessionKey;
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
                        this.game = new GamePersister(this.rootUrl);
                        this.battle = new BattlePersister(this.rootUrl);
                        this.messages = new MessagesPersister(this.rootUrl);
                    },
                    isUserLoggedIn: function () {
                        var isLoggedIn = nickname != null && sessionKey != null;
                        return isLoggedIn;
                    },
                    nickname: function () {
                        return nickname;
                    }
                });
                var UserPersister = Class.create({
                    init: function (rootUrl) {
                        //...api/user/
                        this.rootUrl = rootUrl + "user/";
                    },
                    login: function (user, success, error) {
                        var url = this.rootUrl + "login";
                        var userData = {
                            username: user.username,
                            authCode: CryptoJS.SHA1(user.username + user.password).toString()
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
                            nickname: user.nickname,
                            authCode: CryptoJS.SHA1(user.username + user.authCode).toString()
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
                    },
                    scores: function (success, error) {
                    }
                });
                var GamePersister = Class.create({
                    init: function (url) {
                        this.rootUrl = url + "game/";
                    },
                    create: function (game, success, error) {
                        var gameData = {
                            title: game.title
                        };
                        if (game.password) {
                            gameData.password = CryptoJS.SHA1(game.password).toString();
                        }
                        var url = this.rootUrl + "create/" + sessionKey;
                        httpRequester.postJSON(url, gameData, success, error);
                    },
                    join: function (game, success, error) {
                        var gameData = {
                            id: game.gameId
                        };
                        if (game.password) {
                            gameData.password = CryptoJS.SHA1(game.password).toString();
                        }
                        var url = this.rootUrl + "join/" + sessionKey;
                        httpRequester.postJSON(url, gameData, success, error);
                    },
                    start: function () {

                    },
                    myActive: function (success, error) {
                        var url = this.rootUrl + "my-active/" + sessionKey;
                        httpRequester.getJSON(url, success, error);
                    },
                    open: function (success, error) {
                        var url = this.rootUrl + "open/" + sessionKey;
                        httpRequester.getJSON(url, success, error);
                    },
                    state: function (gameId, success, error) {
                        var url = this.rootUrl + gameId + "/state/" + sessionKey;
                        httpRequester.getJSON(url, success, error);
                    },
                    start: function (gameID, success, error) {
                        var url = this.rootUrl + gameID + "/start/" + sessionKey;
                        httpRequester.getJSON(url, success, error);
                    },
                    field: function (id, success, error) {
                        var url = this.rootUrl + id + "/field/" + sessionKey;
                        httpRequester.getJSON(url, success, error);
                    }
                });
                var BattlePersister = Class.create({
                    init: function (url) {
                        this.rootUrl = url + "battle/";
                    },
                    move: function (GameId, unit, success, error) {
                        var url = this.rootUrl + GameId + "/move/" + sessionKey;
                        httpRequester.postJSON(url, unit, success, error);
                    },
                    defend: function (GameId, unit, success, error) {
                        var url = this.rootUrl + GameId + "/defend/" + sessionKey;
                        httpRequester.postJSON(url, unit, success, error);
                    },
                    attack: function (GameId, unit, success, error) {
                        var url = this.rootUrl + GameId + "/attack/" + sessionKey;
                        httpRequester.postJSON(url, unit, success, error);
                    }
                });

                var MessagesPersister = Class.create({
                    init: function (url) {
                        this.rootUrl = url + "messages/";

                    },
                    unread: function () {

                    },
                    all: function () {

                    },
                    unread: function (success, error) {
                        var url = this.rootUrl + "unread/" + sessionKey;
                        httpRequester.getJSON(url, success, error);
                    }
                });
                return {
                    get: function (url) {
                        return new MainPersister(url);
                    }
                };
            }());
            return persisters;

});