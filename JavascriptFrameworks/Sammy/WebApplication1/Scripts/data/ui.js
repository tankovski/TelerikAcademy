
/// <reference path="../libs/require.js" />

define(["jquery"], function ($) {


    var ui = (function () {

        function buildLoginForm() {
            var html =
                '<div id="login-form-holder">' +
                    '<div>' +
                        '<div id="login-form">' +
                            '<label for="tb-login-username">Username: </label>' +
                            '<input type="text" id="tb-login-username"><br />' +
                            '<label for="tb-login-password">Password: </label>' +
                            '<input type="text" id="tb-login-password"><br />' +
                            '<a href="#/Joined" id="btn-login" class="button">Login</a>' +
                        '</div>' +
                        '<div id="register-form" style="display: none">' +
                            '<label for="tb-register-username">Username: </label>' +
                            '<input type="text" id="tb-register-username"><br />' +
                            '<label for="tb-register-nickname">Nickname: </label>' +
                            '<input type="text" id="tb-register-nickname"><br />' +
                            '<label for="tb-register-password">Password: </label>' +
                            '<input type="text" id="tb-register-password"><br />' +
                            '<a href="#" id="btn-register" class="button">Register</a>' +
                        '</div>' +
                        '<a href="#" id="btn-show-login" class="button selected">Login</a>' +
                        '<a href="#" id="btn-show-register" class="button">Register</a>' +
                    '</div>' +
                '</div>';
            return html;
        }

        function buildGameUI(nickname) {
            var html = '<div id ="msg-container"></div>' +
                '<span id="user-nickname">' +
                    nickname +
            '</span>' +
            '<button id="btn-logout">Logout</button>' +
            '<a href="#/MyGames" class="button2">MyGames</a><br/>' +
            '<div id="create-game-holder">' +
                'Title: <input type="text" id="tb-create-title" />' +
                'Password: <input type="text" id="tb-create-pass" />' +
                '<button id="btn-create-game">Create</button>' +
            '</div>' +
            '<div id="open-games-container">' +
                '<h2>Open</h2>' +
                '<div id="open-games"></div>' +
            '</div>' +
            '<div id="active-games-container">' +
                '<h2>Active</h2>' +
                '<div id="active-games"></div>' +
            '</div>' +
            '<div id="game-holder">' +
            '</div>';
            return html;
        }

        function buildOpenGamesList(games) {
            var list = '<ul class="game-list open-games">';
            for (var i = 0; i < games.length; i++) {
                var game = games[i];
                list +=
                    '<li data-game-id="' + game.id + '">' +
                        '<a href="#" >' +
                            $("<div />").html(game.title).text() +
                        '</a>' +
                        '<span> by ' +
                            game.creator +
                        '</span>' +
                    '</li>';
            }
            list += "</ul>";
            return list;
        }

        function buildMyGames(list,template,data) {
           
            var nickname = localStorage.getItem("nickname");
            for (var i = 0; i < data.length; i++) {

                var item = data[i];
                
                if (nickname == data[i].creator) {
                    list.innerHTML += template(item);
                }
            }
            return list.outerHTML;
        }

        function buildActiveGamesList(games) {
            var gamesList = Array.prototype.slice.call(games, 0);
            gamesList.sort(function (g1, g2) {
                if (g1.status == g2.status) {
                    return g1.title > g2.title;
                }
                else {
                    if (g1.status == "in-progress") {
                        return -1;
                    }
                }
                return 1;
            });

            var list = '<ul class="game-list active-games">';
            for (var i = 0; i < gamesList.length; i++) {
                var game = gamesList[i];
                if (game.status == "in-progress") {
                    list +=
                    '<li data-game-id="' + game.id + '">' +
                        '<a href="#/ActiveGame/'+game.id+'" class="' + game.status + '">' +
                            $("<div />").html(game.title).text() +
                        '</a>' +
                        '<span> by ' +
                            game.creator +
                        '</span>' +
                    '</li>';
                }
                else {
                    list +=
                    '<li data-game-id="' + game.id + '">' +
                        '<a href="#" class="' + game.status + '">' +
                            $("<div />").html(game.title).text() +
                        '</a>' +
                        '<span> by ' +
                            game.creator +
                        '</span>' +
                    '</li>';
                }
                
            }
            list += "</ul>";
            return list;
        }

        function buildGuessTable(guesses) {
            var tableHtml =
                '<table border="1" cellspacing="0" cellpadding="5">' +
                    '<tr>' +
                        '<th>Number</th>' +
                        '<th>Cows</th>' +
                        '<th>Bulls</th>' +
                    '</tr>';
            for (var i = 0; i < guesses.length; i++) {
                var guess = guesses[i];
                tableHtml +=
                    '<tr>' +
                        '<td>' +
                            guess.number +
                        '</td>' +
                        '<td>' +
                            guess.cows +
                        '</td>' +
                        '<td>' +
                            guess.bulls +
                        '</td>' +
                    '</tr>';
            }
            tableHtml += '</table>';
            return tableHtml;
        }

        function buildGameState(GameInformation) {

            //GameInformation.id
            //GameInformation.title
            $("#game-state").remove();
            var html =
                '<div id="game-state" data-game-id="' + GameInformation.gameId + '">' +
                    '<h2>' + GameInformation.title + '</h2>' +
                    '</br>' +
                    buildGameField(GameInformation) +
            '</div>';

            return html;
        }

        function buildGameField(GameInformation) {
            var html = "";
            for (var i = 0; i < 9; i++) {

                for (var l = 0; l < 9; l++) {
                    html += '<div class="cell ' + l + '' + i + '" data-cell-pisition="' + l + '' + i + '">&nbsp</div>'
                }
                html += "</br>"
            }

            return html;
        }

        function buildJoinGameMenu() {
            var html =
                        '<div id="game-join-inputs">' +
                            'Password: <input type="text" id="tb-game-pass"/>' +
                            '<button id="btn-join-game">join</button>' +
                        '</div>';
            return html;
        };

        function createStartBtn() {
            var html =

                '<button id="start-game-btn">start</button>';

            return html;
        }

        function createBattleButtons(currentId) {
            $("#battleButtonsContainer").remove();
            var html =
                '<div id ="battleButtonsContainer">' +
                '<button id="defend-btn">Defend</button>' +
                '<button id="action-btn">Action</button>' +
                "</br>UnitId: " + currentId
            '</div>';
            return html;
        }

        function atackMsg() {
            $("#battleButtonsContainer").remove();
            var html =
                '<div id ="battleButtonsContainer">Click where to move or atack</div>';
            return html;
        }

        return {
            gameUI: buildGameUI,
            openGamesList: buildOpenGamesList,
            loginForm: buildLoginForm,
            activeGamesList: buildActiveGamesList,
            gameState: buildGameState,
            joinGame: buildJoinGameMenu,
            startBtn: createStartBtn,
            gameField: buildGameState,
            battleButtons: createBattleButtons,
            atackMsg: atackMsg,
            buildMyGames: buildMyGames
        }

    }());

    return ui;
});