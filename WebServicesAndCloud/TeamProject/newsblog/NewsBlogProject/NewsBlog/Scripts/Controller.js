/// <reference path="class.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:49725/api/";

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                var nickname = this.persister.nickname();

                this.loadBlogWithUser(selector, nickname);
            }
            else {

                this.loadBlogNoUserUi(selector);
            }
            this.attachUIEventHandlers(selector);
        },
        loadLoginFormUI: function () {
            var html = ui.LoadLoginForm();
            $("#LogRegForm").html(html);
        },
        loadBlogNoUserUi: function (selector) {
            var html = ui.LoadNoUserUi();

            this.persister.article.loadAllArticles(function (data) {
                html += ui.LoadArticles(data);
                $(selector).html(html);
            }, function (data) {
                alert("Error! " + JSON.stringify(data));
            });

        },
        loadRegFormUi: function () {

            var html = ui.LoadRegistrationForm();
            $("#LogRegForm").html(html);

        },
        loadFullArticleNoUser: function (selector, articleDate) {

            var html = ui.LoadFullArticleNoUser(articleDate, selector);

            $(selector).html(html);
        },
        //WithUser
        loadBlogWithUser: function (selector, user) {

            var html = ui.LoadBlogWithUserUi(user);

            this.persister.article.loadAllArticles(function (data) {
                html += ui.LoadArticles(data);
                $(selector).html(html);
            }, function (data) {
                alert("Error! " + JSON.stringify(data));
            });
        },
        loadFullArticleWithUser: function (selector, articleData) {
            var nickname = this.persister.nickname();
            var html = ui.loadFullArticleWithUser(articleData, nickname);

            $(selector).html(html);
            var nickname = this.persister.nickname();

           
            var delArticleButton =
                '<button class="delArticleBtn">Delete</button>';
            $("[data-autor=" + nickname + "]").filter("#fullArticle").append(delArticleButton);

            var delCommentButton =
               '<button class="delCommentBtn">Delete</button>';
            $("[data-autor=" + nickname + "]").filter(".commentContainer").append(delCommentButton);

            var delSubCommentButton =
              '<button class="delSubCommentBtn">Delete</button>';
            $("[data-autor=" + nickname + "]").filter(".subcomentContainer").append(delSubCommentButton);

            $(".votable").append('<a href="#" id="voteYesLink"><img src="imgs/voteUp.png"/></a>');
            $(".votable").append('<a href="#" id="voteNoLink"><img src="imgs/voteDown.png"/></a>');

        },
        convertImgTo64bitArray:function getBase64Image(img) {
			//img.style.width="auto";
			//img.style.height="auto";
            // Create an empty canvas element
            var canvas = document.createElement("canvas");
            canvas.width = 300;
            canvas.height = 300;

            // Copy the image contents to the canvas
            var ctx = canvas.getContext("2d");
            ctx.drawImage(img, 0, 0);

            // Get the data-URL formatted image
            // Firefox supports PNG and JPEG. You could check img.src to
            // guess the original format, but be aware the using "image/jpg"
            // will re-encode the image.
            var dataURL = canvas.toDataURL("image/png");

            return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
        },

        //Atach Events
        attachUIEventHandlers: function (selector) {
            var wrapper = $("body");
            var self = this;
            var currentArticleId = 0;

            wrapper.on("click", ".loginBtn", function () {

                self.loadLoginFormUI();
            });

            wrapper.on("click", ".registerBtn", function () {

                self.loadRegFormUi();
            });

            wrapper.on("click", "#LogBtn", function () {

                var user = {
                    username: $(selector + " #usernameInput").val(),
                    password: $(selector + " #passwordInput").val()
                }

                self.persister.user.login(user, function (data) {
                    location.reload();
                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
            });

            wrapper.on("click", "#RegBtn", function () {
                var user = {
                    username: $(selector + " #usernameInput").val(),
                    password: $(selector + " #passwordInput").val()
                }

                self.persister.user.register(user, function (data) {
                    location.reload();
                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
            });

            wrapper.on("click", ".fullArticleLink", function () {

                var articleId = $(this).parent().attr('id');

                self.persister.article.loadArticle(articleId, function (date) {
                    if (self.persister.isUserLoggedIn()) {
                        self.loadFullArticleWithUser(selector, date);
                        currentArticleId = articleId;
                    }
                    else {

                        self.loadFullArticleNoUser(selector, date);
                        currentArticleId = articleId;
                    }
                },
                function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
            });

            wrapper.on("click", "#LogoutBtn", function () {
                localStorage.clear();
                location.reload();
                //self.persister.user.logout(function () {
                //    self.loadBlogNoUserUi(selector);
                //}, function (data) {
                //    alert("Error! " + JSON.stringify(data));
                //});
            });

            wrapper.on("click", "#backBtn", function () {
                location.reload();
            });

            wrapper.on("click", "#postFormBtn", function () {
                ui.loadPostArticleForm("#wrapper");
            });

            wrapper.on("click", "#cancelBtn", function () {
                $("#mistDiv").remove();
            });

            wrapper.on("click", "#publishBtn", function () {
                var currentdate = new Date();
                var datetime = +currentdate.getDate() + "/"
                                + (currentdate.getMonth() + 1) + "/"
                                + currentdate.getFullYear() + " "
                                + currentdate.getHours() + ":"
                                + currentdate.getMinutes() + ":"
                                + currentdate.getSeconds();

                var imgValue = $("#imageInput").val();
                var domImg = document.createElement("img");
                domImg.src = imgValue;
                
                var imgName = imgValue.substring(imgValue.lastIndexOf("\\")+1,imgValue.length-4);
                var img =
                    {
                        Content:self.convertImgTo64bitArray(domImg).toString(),
                        Name:imgName
                    }

                var article =
                    {
                        Title: $("#titleInput").val(),
                        Content: $("#contentInput").val(),
                        Author: self.persister.nickname(),
                        Date: datetime,
                        Images:[img]
                    };

                self.persister.article.postArticle(article, function () {
                    location.reload();
                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
            });

            wrapper.on("click", "#commentArticleBtn", function () {
                ui.loadPostCommentForm("#mist");
            });

            wrapper.on("click", "#publishCommentBtn", function () {

                var currentdate = new Date();
                var datetime = +currentdate.getDate() + "/"
                                + (currentdate.getMonth() + 1) + "/"
                                + currentdate.getFullYear() + " "
                                + currentdate.getHours() + ":"
                                + currentdate.getMinutes() + ":"
                                + currentdate.getSeconds();

                var comment =
                    {
                        ArticleID: currentArticleId,
                        Content: $("#contentInput").val(),
                        Author: self.persister.nickname(),
                        Date: currentdate.toLocaleString()
                    };

                self.persister.comment.postComment(comment, function (response) {
                  
                    
                    self.persister.article.loadArticle(currentArticleId, function (data) {
                        
                        $("#mistDiv").remove();
                        
                        self.loadFullArticleWithUser(selector, data);
                    },
                 function (data) {
                     alert("Error! " + JSON.stringify(data));
                 });

                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
              
            });

            wrapper.on("click", ".SubcomentFormBtn", function () {

                var commentId = $(this).data("comment-id");
                ui.loadPostSubCommentForm("#wrapper", commentId);

            });

            wrapper.on("click", "#publishSubCommentBtn", function () {

                var currentdate = new Date();
                
                var commentId = $(this).parent().data("comment-id");

                var comment =
                    {
                        ParentCommentID: commentId,
                        Content: $("#contentInput").val(),
                        Author: self.persister.nickname(),
                        Date: currentdate.toLocaleString()
                    };

                self.persister.subComment.postSubComment(comment, function () {
                    self.persister.article.loadArticle(currentArticleId, function (date) {
                        
                            $("#mistDiv").remove();
                            self.loadFullArticleWithUser(selector, date);
                                                    
                    },
                 function (data) {
                     alert("Error! " + JSON.stringify(data));
                 });
                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });


            });


            wrapper.on("click", ".delCommentBtn", function () {
                var confirm = window.confirm("Do you really want to delete this comment?");

                if (confirm) {
                   var commentId = $(this).parent().attr("id");
                   self.persister.comment.deleteComment(commentId, function (response) {
                    
                       self.persister.article.loadArticle(currentArticleId, function (data) {

                           self.loadFullArticleWithUser(selector, data);

                       },
                function (data) {
                    alert("Error! " + JSON.stringify(data));
                });

                   }, function (data) {
                       alert("Error! " + JSON.stringify(data));
                   });
                }
                else {
                }

            });

            wrapper.on("click", ".delSubCommentBtn", function () {
                var confirm = window.confirm("Do you really want to delete this subComment?");

                if (confirm) {
                    var commentId = $(this).parent().attr("id");
                    self.persister.subComment.deleteSubComment(commentId, function () {
                       
                        self.persister.article.loadArticle(currentArticleId, function (data) {

                            self.loadFullArticleWithUser(selector, data);

                        },
                 function (data) {
                     alert("Error! " + JSON.stringify(data));
                 });

                    }, function (data) {
                        alert("Error! " + JSON.stringify(data));
                    });
                }
                else {
                }

            });

            wrapper.on("click", ".delArticleBtn", function () {
                var confirm = window.confirm("Do you really want to delete this article?");

                if (confirm) {
                    
                    self.persister.article.deleteArticle(currentArticleId, function () {
                        currentArticleId = 0;
                       
                            var username = self.persister.nickname();
                            self.loadBlogWithUser(selector, username);


                    }, function (data) {
                        alert("Error! " + JSON.stringify(data));
                    });
                }
                else {
                }

            });

            wrapper.on("click", "#voteYesLink", function () {
                
                var autorId = localStorage.getItem("userId");
                var vote = {
                    Value: true,
                    AuthorId: autorId,
                    ArticleId: currentArticleId
                }

                self.persister.vote.postVote(vote, function () {
                    
                    self.persister.article.loadArticle(currentArticleId, function (data) {

                        self.loadFullArticleWithUser(selector, data);
                    },
                 function (data) {
                     alert("Error! " + JSON.stringify(data));
                 });

                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
            });

            wrapper.on("click", "#voteNoLink", function () {

                var autorId = localStorage.getItem("userId");
                var vote = {
                    Value: false,
                    AuthorId: autorId,
                    ArticleId: currentArticleId
                }

                self.persister.vote.postVote(vote, function () {

                    self.persister.article.loadArticle(currentArticleId, function (data) {

                        self.loadFullArticleWithUser(selector, data);
                    },
                 function (data) {
                     alert("Error! " + JSON.stringify(data));
                 });

                }, function (data) {
                    alert("Error! " + JSON.stringify(data));
                });
            });
            
      }
    });
    return {
        get: function () {
            return new Controller();
        }
    }
}());

$(function () {
    var controller = controllers.get();
    controller.loadUI("#content");
});