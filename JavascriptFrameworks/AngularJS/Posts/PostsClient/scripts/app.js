/// <reference path="libs/angular.js" />
/// <reference path="app/controllers.js" />

angular.module("posts", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
			.when("/", { templateUrl: "scripts/partials/allPosts.html", controller: PostsController })
			.when("/post/:id", { templateUrl: "scripts/partials/singlePost.html", controller: SinglePostController })
			.when("/category/:id/posts", { templateUrl: "scripts/partials/allPosts.html", controller: CategoriesPostsController })
			.when("/posts/create", { templateUrl: "scripts/partials/createPost.html", controller: CreatePostsController })
			.otherwise({ redirectTo: "/" });
	}]);