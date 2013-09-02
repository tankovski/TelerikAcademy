/// <reference path="lib/_references.js" />

(function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var appSideLayout =
       new kendo.Layout('<div id="side-content"></div>');

    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        loadRecentPosts();
        router.navigate("/posts");
    });

    router.route("/register", function () {
        userNavigation.render(data);
        if (data.users.currentUser()) {
            router.navigate("/");
        }
        else {
            viewsFactory.getRegisterView()
				.then(function (registerViewHtml) {
				    var registerVm = vmFactory.getRegisterVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(registerViewHtml,
						{ model: registerVm });
				    appLayout.showIn("#main-content", view);

				    var validator = $('#register-form').kendoValidator().data('kendoValidator');

				    $('#submit').click(function () {
				        if (validator.validate()) {
				            $('#status').text('Proceed!');
				        }
				        else {
				            $('#status').text('Invalid data!');
				        }
				    });
				});
        }
    });

    router.route("/login", function () {
        userNavigation.render(data);
        if (data.users.currentUser()) {
            router.navigate("/");
        }
        else {
            viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);

				    var validator = $('#login-form').kendoValidator().data('kendoValidator');

				    $('#submit').click(function () {
				        if (validator.validate()) {
				            $('#status').text('Proceed!');
				        }
				        else {
				            $('#status').text('Invalid data!');
				        }
				    });
				});
        }
    });

    router.route("/logout", function () {
        data.users.logout();
        router.navigate("/login");
    });

    router.route("/users", function () {
        userNavigation.render(data);

        //var nickname = localStorage.getItem("nickname");
        //var sessionKey = localStorage.getItem("sessionKey");
        //var isUserLoged = nickname != null && sessionKey != null;
        //if (isUserLoged) {
        //    ACTION
        //}
        //else {
        //    router.navigate("/");
        //}
        

        viewsFactory.getAllUsersView()
            .then(function (allUsersViewHtml) {
                  vmFactory.getUsersVM()
                    .then(
                    function (data) {
                        var allUsersVm = data;
                        var view = new kendo.View(allUsersViewHtml,
                   { model: allUsersVm });
                        appLayout.showIn("#main-content", view);

                    });
               
            });
        loadRecentPosts();
    });
    router.route("/user/:id", function (id) {
        userNavigation.render(data);
        //var nickname = localStorage.getItem("nickname");
        //var sessionKey = localStorage.getItem("sessionKey");
        //var isUserLoged = nickname != null && sessionKey != null;
        //if (isUserLoged) {
        //    ACTION
        //}
        //else {
        //    router.navigate("/");
        //}

        viewsFactory.getSingleUserView()
            .then(function (singleUserViewHtml) {
                vmFactory.getSingleUserVM(id)
                   .then(
                   function (data) {
                       var singleUserVm = data;
                       var view = new kendo.View(singleUserViewHtml,
                  { model: singleUserVm });
                       appLayout.showIn("#main-content", view);

                   });

            });
        loadRecentPosts();
    });

    router.route("/posts/create", function () {
        userNavigation.render(data);

        //var nickname = localStorage.getItem("nickname");
        //var sessionKey = localStorage.getItem("sessionKey");
        //var isUserLoged = nickname != null && sessionKey != null;
        //if (isUserLoged) {
        //    ACTION
        //}
        //else {
        //    router.navigate("/");
        //}
        viewsFactory.getCreatePostView()
            .then(function (createPostHtml) {
                var createPostVM = vmFactory.getCreatePostVM(
                    function (data) {
                        router.navigate("/posts/" + data.Id);
                    });

                var view = new kendo.View(createPostHtml,
                 { model: createPostVM });
                appLayout.showIn("#main-content", view);
            })
        loadRecentPosts();
    });

    router.route("/posts", function () {
        userNavigation.render(data);
        viewsFactory.getPostsView().then(function (postsHTML) {
            vmFactory.getPostsVM().then(function (postsVM) {
                var view =
						new kendo.View(postsHTML,
						{ model: postsVM });
                
                appLayout.showIn("#main-content", view);
            }, function (err) { console.log(err); });
        });
        loadRecentPosts();
    });

    function loadRecentPosts() {
        viewsFactory.getRecentPostsView().then(function (postsHTML) {
            vmFactory.getRecentPostsVM().then(function (postsVM) {
                var view =
						new kendo.View(postsHTML,
						{ model: postsVM });

                appSideLayout.showIn("#side-content", view);
            }, function (err) { console.log(err); });
        });
    }
    router.route("/posts/:id", function (id) {
        userNavigation.render(data);
        viewsFactory.getSinglePostView().then(function (postHTMLtemplate) {
            vmFactory.getSinglePostVM(id).then(function (postVM) {

                var template = kendo.template(postHTMLtemplate);
                var postHtml = template(postVM);

                var view =
						new kendo.View(postHtml,
						{ model: postVM });

                appLayout.showIn("#main-content", view);
            }, function (err) { console.log(err); });
        });
    });

    router.route("/posts/bytag/:tag", function (tag) {
        userNavigation.render(data);
        viewsFactory.getPostsView().then(function (postsHTML) {
            vmFactory.getPostsByTagVM(tag).then(function (postsVM) {
                
                console.log(postsVM);
                var view =
						new kendo.View(postsHTML,
						{ model: postsVM });

                appLayout.showIn("#main-content", view);
            }, function (err) { console.log(err); });
        }, function (err) { alert(err) });

        loadRecentPosts();
    });

    $(function () {
        appLayout.render("#app");
        appSideLayout.render("#app-side");
        router.start('/');

    });
}());