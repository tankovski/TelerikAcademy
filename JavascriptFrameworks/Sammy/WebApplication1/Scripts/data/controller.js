/// <reference path="libs/require.js" />


define(["Class","jquery","ui","persister"], function (Class,$,ui,persisters) {

    var controllers = (function () {
        var rootUrl = "http://localhost:22954/api/";
        function initialisUnits(gameState) {
            for (var i = 0; i < gameState.red.units.length; i++) {
                var UnitPossition = gameState.red.units[i].position.x + "" + gameState.red.units[i].position.y;

                var unitType = gameState.red.units[i].type + "";
                $("." + UnitPossition).addClass("red").html(unitType[0]).attr('id', gameState.red.units[i].id);
            }
            for (var i = 0; i < gameState.blue.units.length; i++) {
                var UnitPossition = gameState.blue.units[i].position.x + "" + gameState.blue.units[i].position.y;

                var unitType = gameState.red.units[i].type + "";
                $("." + UnitPossition).addClass("blue").html(unitType[0]).attr('id', gameState.blue.units[i].id);
            }

            var div = document.createElement("div");

            var bluePlayers = document.getElementsByClassName("blue");
            for (var i = 0; i < bluePlayers.length; i++) {
                bluePlayers[i].draggable = "true";
            }

            var redPlayers = document.getElementsByClassName("red");
            for (var i = 0; i < redPlayers.length; i++) {
                redPlayers[i].draggable = "true";
            }


        }
        var Controller = Class.create({
            init: function () {
                this.persister = persisters.get(rootUrl);
            },
            loadUI: function (selector) {
                if (this.persister.isUserLoggedIn()) {
                    this.loadGameUI(selector);
                }
                else {
                    this.loadLoginFormUI(selector);
                }
                this.attachUIEventHandlers(selector);
            },
            loadLoginFormUI: function (selector) {
                var loginFormHtml = ui.loginForm()
                $(selector).html(loginFormHtml);
            },
            loadGameUI: function (selector) {
                var list =
                    ui.gameUI(this.persister.nickname());
                $(selector).html(list);


                this.persister.game.open(function (games) {
                    var list = ui.openGamesList(games);
                    $(selector + " #open-games")
                        .html(list);
                });

                this.persister.game.myActive(function (games) {
                    var list = ui.activeGamesList(games);
                    $(selector + " #active-games")
                        .html(list);
                });
            },
            loadGame: function (selector, gameId) {

                var html = ui.gameField(selector);
                this.persister.game.field(gameId, function (gameState) {
                    var html = ui.gameField(gameState);
                    $(selector + " #game-holder").html(html);
                    initialisUnits(gameState);
                   
                }, function (data) {
                    alert(JSON.stringify(data));
                });
                this.persister.messages.unread(function (data) {
                    //$("#msg-container").html("");
                    //for (var i = 0; i < data.length; i++) {
                    //    $("#msg-container").append(data[i].text);
                    //}
                    if (data[0]) {
                        $("#msg-container").html("<h3>" + JSON.stringify(data[0].text) + "</h3>");
                    }
                    
                }, function (data) {
                    alert(JSON.stringify(data));
                });
            },
            attachUIEventHandlers: function (selector) {
                var wrapper = $(selector);
                var self = this;
                var currentId;
                wrapper.on("click", "#btn-show-login", function () {
                    wrapper.find(".button.selected").removeClass("selected");
                    $(this).addClass("selected");
                    wrapper.find("#login-form").show();
                    wrapper.find("#register-form").hide();
                });
                wrapper.on("click", "#btn-show-register", function () {
                    wrapper.find(".button.selected").removeClass("selected");
                    $(this).addClass("selected");
                    wrapper.find("#register-form").show();
                    wrapper.find("#login-form").hide();
                });

                wrapper.on("click", "#btn-login", function () {
                    var user = {
                        username: $(selector + " #tb-login-username").val(),
                        password: $(selector + " #tb-login-password").val()
                    }

                    self.persister.user.login(user, function () {
                        self.loadGameUI(selector);
                        window.location.href = '#/Joined';
                    }, function (data) {
                        alert("Error! " + JSON.stringify(data));
                    });
                    return false;
                });
                wrapper.on("click", "#btn-register", function () {
                    var userData = {
                        username: $("#tb-register-username").val(),
                        nickname: $("#tb-register-nickname").val(),
                        authCode: $("#tb-register-password").val()
                    };

                    self.persister.user.register(userData, function () {
                        document.location.reload();
                        //self.loadGameUI(selector);
                    }, function (data) {
                        alert("Error! " + JSON.stringify(data));
                    })
                });
                wrapper.on("click", "#btn-logout", function () {
                    self.persister.user.logout(function () {
                        //self.loadLoginFormUI(selector);
                        
                        window.location = "#/Register-Login";
                        document.location.reload();
                    }, function (data) {
                        alert("Error! " + JSON.stringify(data));

                    });
                });

                wrapper.on("click", "#open-games-container a", function () {
                    $("#game-join-inputs").remove();
                    var html = ui.joinGame();
                    $(this).after(html);
                });
                wrapper.on("click", "#btn-join-game", function () {
                    var game = {
                        gameId: $(this).parents("li").first().data("game-id")
                    };

                    var password = $("#tb-game-pass").val();

                    if (password) {
                        game.password = password;
                    }
                    self.persister.game.join(game, function () {
                        document.location.reload();
                    });
                });
                wrapper.on("click", "#btn-create-game", function () {
                    var game = {
                        title: $("#tb-create-title").val()
                    }
                    var password = $("#tb-create-pass").val();
                    if (password) {
                        game.password = password;
                    }
                    self.persister.game.create(game, function () {
                        document.location.reload();
                    }, function (data) {
                        alert("Error! " + JSON.stringify(data.responseText));
                    });
                });

                wrapper.on("click", ".active-games .in-progress", function () {
                    
                    var id = $(this).parent().data("game-id")                 
                    localStorage.setItem("GameId", id);
                    //$("body").html()+='<div id="TempGameId" data-game-id="' + id + '"></div>';
                   // document.location.href = "#/ActiveGame";
                  //  self.loadGame(selector, $(this).parent().data("game-id"));
                });

                wrapper.on("click", ".active-games .full", function () {
                    $("#start-game-btn").remove();
                    var html = ui.startBtn();
                    $(this).after(html);
                });
                wrapper.on("click", "#start-game-btn", function () {
                    var id = $(this).parent().data("game-id");
                    self.persister.game.start(id, function () {
                        document.location.reload();
                    }, function (data) {
                        alert("Error!!!" + JSON.stringify(data));
                    })
                });

                wrapper.on("click", ".red", function (ev) {
                    if (!($(this).hasClass("clickable"))) {
                        $(".clickable").removeClass("clickable");
                        currentId = $(this).attr('id');
                        var buttons = ui.battleButtons(currentId);
                        $("#game-state h2").after(buttons);
                    }

                });
                wrapper.on("click", ".blue", function (ev) {
                    if (!($(this).hasClass("clickable"))) {
                        $(".clickable").removeClass("clickable");
                        currentId = $(this).attr('id') + "";
                        var buttons = ui.battleButtons(currentId);
                        $("#game-state h2").after(buttons);
                    }
                });

                wrapper.on("click", ".clickable", function (ev) {
                    cellId = $(this).data("cell-pisition") + "";

                    var gameId = $("#game-state").data("game-id");
                    var unit = {
                        unitId: currentId,
                        position: {
                            x: cellId[0],
                            y: cellId[1]
                        }
                    };
                    if (!($(this).hasClass("red") || $(this).hasClass("blue"))) {

                        self.persister.battle.move(gameId, unit, function () {
                            self.loadGame(selector, gameId);
                        }, function (data) {
                            alert(JSON.stringify(data));
                        });
                    }
                    else {
                        var AttackUnit = {
                            unitId: currentId,
                            position: {
                                x: cellId[0],
                                y: cellId[1]
                            }
                        };
                        self.persister.battle.attack(gameId, AttackUnit, function () {
                            alert("baaaaam");
                            self.loadGame(selector, gameId);
                        }, function (data) {
                            alert(JSON.stringify(data));
                        });
                    }
                });

                wrapper.on("click", "#action-btn", function () {
                    $(".cell").addClass("clickable");
                    var html = ui.atackMsg();
                    $("#game-state h2").after(html);
                });

                wrapper.on("click", "#defend-btn", function () {
                    var gameId = $("#game-state").data("game-id");
                    self.persister.battle.defend(gameId, currentId, function () {
                        self.loadGame(selector, gameId);
                    }, function (data) {
                        alert("Error!!!" + JSON.stringify(data));
                    })

                });
            },
            start: function () {
                this.loadUI("#content");
                
            }
        });
        return {
            get: function () {
                return new Controller();
            }
        }
    }());

    return controllers;
});
//$(function () {
//    var controller = controllers.get();
//    controller.loadUI("#content");
//});