/// <reference path="libs/require.js" />

require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        httpRequester: "libs/http-requester",
        mustache: "libs/mustache",
        ui: "data/ui",
        controllers: "data/controller",
        persister: "data/persister",
        Class: "libs/class",
        crypto: "libs/crypto",
        sammy: "libs/sammy-0.7.4",
        underscore:"libs/underscore"
    }
});

require(["jquery", "controllers", "sammy", "persister","ui","mustache"], function ($, controllers, sammy, persisters,ui,mustache) {
    var controller = controllers.get();
    var url = "http://localhost:22954/api/";
    var persister = persisters.get(url);
    var selector = "#content";


    var app = sammy("#wrapper", function () {
        this.get("#/Register-Login", function () {

            controller.start();
            var nickname = localStorage.getItem("nickname");
            var sessionKey = localStorage.getItem("sessionKey");
            var isLoged = nickname != null && sessionKey != null;
            if (isLoged) {
                document.location.href = "#/Joined";
            }

        });

        this.get("#/Joined", function () {
            
                controller.start();
            
            controller.loadGameUI(selector);

        });

        this.get("#/ActiveGame/:id", function () {
            var id = localStorage.getItem("GameId");
            var testItem = document.getElementById("msg-container");
            if (!testItem) {
                controller.start();
                controller.loadGameUI(selector);
               
               // window.location.href = "#/Joined";
                window.location.href = "#/ActiveGame/"+id;
                controller.loadGame(selector, id);
            }
            else {
                controller.loadGame(selector, id);
            }
            
          
        })

        this.get("#/MyGames", function () {

            var gamesTemplateString = $("#games-template").html();
            var template = mustache.compile(gamesTemplateString);

            persister.game.open(function (games) {
                var list = document.createElement("ul");
                list.id = "MyOpenGames";
                list.innerHTML += '<li><h3>MyOpenGames</h3></li>';
                list = ui.buildMyGames(list,template, games);
                $(selector)
                    .html(list);
            });

            persister.game.myActive(function (games) {
                var list = document.createElement("ul");
                list.id = "MyActiveGames";
                list.innerHTML += '<li><h3>MyActiveGames</h3></li>';
                var list = ui.buildMyGames(list,template,games);
                $(selector).append(list);
                    
            });

        })
    });

    
    app.run("#/Register-Login");
});
