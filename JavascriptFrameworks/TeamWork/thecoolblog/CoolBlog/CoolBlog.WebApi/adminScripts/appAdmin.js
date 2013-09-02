/// <reference path="libs/angular.js" />
/// <reference path="app/controllers.js" />
/// <reference path="data/dataPersister.js" />

angular.module("forum", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
            .when("/", { templateUrl: "adminScripts/partials/login.html", controller: LoginControlelr })
			.when("/users", { templateUrl: "adminScripts/partials/allUsers.html", controller: UsersController })
			.when("/user/:id", { templateUrl: "adminScripts/partials/singleUser.html", controller: SingleUserController })
            .when("/posts", { templateUrl: "adminScripts/partials/allPosts.html", controller: PostsController })
			//.when("/category/:name", { templateUrl: "scripts/partials/category.html", controller: CategoryController })
			//.otherwise({ redirectTo: "/" });
	}]);


$(function () {
    $("#wrapper").on('click', '#button', function () {
        localStorage.removeItem("adminNickname");
        localStorage.removeItem("adminSessionKey");
    })
});