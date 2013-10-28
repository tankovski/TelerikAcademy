/// <reference path="persister.js" />
/// <reference path="http-requester.js" />
/// <reference path="jquery-2.0.3.js" />

var ui = (function () {

    function LoadBlogNoUserUi(articles) {
        var html =
            '<div id="LogRegForm">' +
                '<button class="registerBtn">Register</button>' +
                '<button class="loginBtn">Login</button>' +
            '</div>';

        return html;
    }

    function LoadLoginForm(container) {
        var html =
            '<label for="usernameInput">Username</label>' +
            '<input type="text" id="usernameInput"/>' +
            '</br>' +
            '<label for="passwordInput">Password</label>' +
            '<input type="password" id="passwordInput"/>' +
            '</br>' +
        '<button id="LogBtn">Login</button>' +
        '<button class = "registerBtn">RegistrationForm</button>';

        return html;

    }

    function LoadRegistrationForm(container) {
        var html =
            '<label for="usernameInput">Username</label>' +
            '<input type="text" id="usernameInput"/>' +
            '</br>' +
            '<label for="passwordInput">Password</label>' +
            '<input type="password" id="passwordInput"/>' +
            '</br>' +
        '<button id="RegBtn">Register</button>' +
        '<button class = "loginBtn">LoginForm</button>';

        return html;

    }

    function LoadArticles(articles) {

        var html = "";

        if (articles) {
            for (var i = 0; i < articles.length; i++) {
                var yes = 0;
                var no = 0;
                if (articles[i].Votes.length > 0) {

                    for (var j = 0; j < articles[i].Votes.length; j++) {

                        if (articles[i].Votes[j].Value) {
                            yes += 1;
                        }
                        else if (!articles[i].Votes[j].Value) {
                            no += 1;
                        }
                    }
                }
                html +=
                    '<div id="' + articles[i].Id + '" class="titlesHolder">' +
                    '<a href="#" class = "fullArticleLink"><h3>' + articles[i].Title +
                    '</h3></a>' +
                    '<p> by <strong>' + articles[i].Author + '</strong> posted on ' +
                    '<time>' + articles[i].Date + '</time> ' +
                    '<span class="yes">' + yes +
                    '</span> <span class="no">' + no + '</span></p>' +
                    '</div>';
            }
        }

        return html;
    }

    function LoadFullArticleNoUser(article, selector) {

        var yes = 0;
        var no = 0;
        if (article.Votes.length > 0) {

            for (var j = 0; j < article.Votes.length; j++) {

                if (article.Votes[j].Value) {
                    yes += 1;
                }
                else if (!article.Votes[j].Value) {
                    no += 1;
                }
            }
        }
        var html =
            LoadBlogNoUserUi() +
           '<div id = "fullArticle">' +
            '<h2>' + article.Title + '</h2>' +
            '<p> by <strong>' + article.Author + '</strong> posted on <time>' + article.Date + '</time> ' +
            '<span class="yes">' + yes +
        '</span> <span class="no">' + no + '</span>' +
            '</p>';
        html += '<div><div id="fullArticleContent">';
        if (article.Images) {

            for (var i = 0; i < article.Images.length; i++) {
                //var image = persister. (article.Images[i].Url,function()
                {
                    html += '<img src="' + image + '"/>';
                }
            }
        }

        html +=
            article.Content + '</div>';
        if (article.Comments) {

            for (var i = 0; i < article.Comments.length; i++) {
                html +=
                    '<div id="' + article.Comments[i].Id + '" class="commentContainer">' + article.Comments[i].Content +
                    '<p>by <strong>' + article.Comments[i].Author + '</strong> posted on <time>' + article.Comments[i].Date + '</time></p>';

                if (article.Comments[i].SubComments) {

                    for (var l = 0; l < article.Comments[i].SubComments.length; l++) {
                        html +=
                            '<div id="' + article.Comments[i].SubComments[l].Id + '" class="subcomentContainer">' +
                            article.Comments[i].SubComments[l].Content +
                            '<p> by <strong>' + article.Comments[i].SubComments[l].Author + '</strong> posted on <time>' +
                            article.Comments[i].SubComments[l].Date + '</time></p>' +
                            '</div>';
                    }
                }
                html += '</div>';
            }
        }

        html += '</div>';
        html += '<button id="backBtn">Back</button>';
        html += '</div>';

        return html;
    }

    //With User
    function LoadLogoutForm(user) {
        var html =
            '<div id="LogRegForm">' +
            '<h3>Hello, ' + user + '</h3>' +
            '<button id="LogoutBtn">Logout</button>' +
            '<button id="postFormBtn">PostArticle</button>' +
        '</div>';

        return html;
    }

    function LoadBlogWithUserUi(user) {
        var html = LoadLogoutForm(user);

        return html;
    }

    function loadPostArticleForm(selector) {
        var html =
            '<div id="mistDiv">' +
            '<div class="postForm">' +
            '<label for="titleInput">Title: </label>' +
            '<input type="text" id="titleInput"/>' +
            '</br>' +
            '<label for="contentInput" id="contentLabel">Content: </label>' +
            '<textarea id="contentInput"/>' +
            '</br>' +
            '<label for="imageInput">ImgUrl: </label>' +
            '<input type="text" id="imageInput"/>' +
            '</br>' +
            '<button id="cancelBtn">Cancel</button>' +
            '<button id="publishBtn">Publish</button>' +
            '</div>' +
            '</div>';

        $(selector).prepend(html);

        var height = $("#wrapper").css("height");
        $("#mistDiv").css("height", height);
    }

    function loadFullArticleWithUser(article, user) {

        var yes = 0;
        var no = 0;
        var votable = "votable";
        if (article.Votes.length > 0) {

            for (var j = 0; j < article.Votes.length; j++) {

                if (article.Votes[j].Author == user) {
                    votable = "unvotable";
                }

                if (article.Votes[j].Value) {
                    yes += 1;
                }
                else if (!article.Votes[j].Value) {
                    no += 1;
                }
            }
        }

        var html =
            LoadLogoutForm(user) +
              '<div id = "fullArticle" data-autor="' + article.Author + '" class="' + votable + '">' +
        '<h2>' + article.Title + '</h2>' +
        '<p> by <strong>' + article.Author + '</strong> posted on <time>' + article.Date + '</time>' +
        '<span class="yes">' + yes +
        '</span> <span class="no">' + no + '</span>' +
        '</p></br>';

        html += '<div><div id="fullArticleContent">';
        if (article.Images) {

            for (var i = 0; i < article.Images.length; i++) {
                html += '<img src="' + article.Images[i] + '"/>';
            }
        }

        html +=
            article.Content + '</div>';
        if (article.Comments) {

            for (var i = 0; i < article.Comments.length; i++) {
                html +=
                    '<div id="' + article.Comments[i].Id + '" class="commentContainer" data-autor="' + article.Comments[i].Author + '">' + article.Comments[i].Content +
                    '<p>by <strong>' + article.Comments[i].Author + '</strong> posted on <time>' + article.Comments[i].Date + '</time></p>' +
                    '<button data-comment-id="' + article.Comments[i].Id + '" class="SubcomentFormBtn">Subcoment</button>';

                if (article.Comments[i].SubComments) {

                    for (var l = 0; l < article.Comments[i].SubComments.length; l++) {
                        html +=
                            '<div id="' + article.Comments[i].SubComments[l].Id + '" class="subcomentContainer" class="commentContainer" data-autor="' + article.Comments[i].SubComments[l].Author + '">' +
                            article.Comments[i].SubComments[l].Content +
                            '<p> by <strong>' + article.Comments[i].SubComments[l].Author + '</strong> posted on <time>' +
                            article.Comments[i].SubComments[l].Date + '</time></p>' +
                            '</div>';
                    }
                }
                html += '</div>';
            }
        }

        html += '</div>';
        html += '<button id="backBtn">Back</button>' +
            '<button id="commentArticleBtn">Comment</button>';
        html += '</div>';



        return html;
    }

    function loadPostCommentForm(selector) {

        var html =
            '<div id="mistDiv">' +
            '<div class="postForm" id="commentsForm" >' +
            '<label for="contentInput" id="contentLabel">Content: </label>' +
            '<textarea id="contentInput"/>' +
            '</br>' +
            '<button id="cancelBtn">Cancel</button>' +
            '<button id="publishCommentBtn">Publish</button>' +
            '</div>' +
            '</div>';

        $(selector).prepend(html);
        var height = $("#wrapper").css("height");
        $("#mistDiv").css("height", height);
    }

    function loadPostSubCommentForm(selector, id) {

        var html =
           '<div id="mistDiv">' +
           '<div class="postForm" id="commentsForm" data-comment-id ="' + id + '">' +
           '<label for="contentInput" id="contentLabel">Content: </label>' +
           '<textarea id="contentInput"/>' +
           '</br>' +
           '<button id="cancelBtn">Cancel</button>' +
           '<button id="publishSubCommentBtn">Publish</button>' +
           '</div>' +
           '</div>';

        $(selector).prepend(html);
        var height = $("#wrapper").css("height");
        $("#mistDiv").css("height", height);

    }
    return {
        LoadNoUserUi: LoadBlogNoUserUi,
        LoadLoginForm: LoadLoginForm,
        LoadRegistrationForm: LoadRegistrationForm,
        LoadArticles: LoadArticles,
        LoadFullArticleNoUser: LoadFullArticleNoUser,
        LoadBlogWithUserUi: LoadBlogWithUserUi,
        loadPostArticleForm: loadPostArticleForm,
        loadFullArticleWithUser: loadFullArticleWithUser,
        loadPostCommentForm: loadPostCommentForm,
        loadPostSubCommentForm: loadPostSubCommentForm
    }

}());