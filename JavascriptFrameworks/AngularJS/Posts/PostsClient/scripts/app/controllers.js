/// <reference path="../libs/underscore.js" />
/// <reference path="../libs/angular.js" />

function PostsController($scope, $http) {
    $scope.posts = "";

	$http({
	    url: 'http://localhost:4790/api/posts/getAll',
	    dataType: "application/json",
	    method: 'GET',
	    data: '',
	    headers: {
	        "Content-Type": "application/json"
	    }

	}).success(function (posts) {
	    $scope.posts = posts;
	}).error(function (error) {
	    alert(JSON.stringify(error));
	});
}

function SinglePostController($scope, $http, $routeParams) {
	var id = $routeParams.id;
    $http.get("http://localhost:4790/api/posts/single?id="+id)
	.success(function (post) {
	    $scope.post = post; 
	})
}

function CategoriesPostsController($scope, $http, $routeParams) {
    var id = $routeParams.id;
    $http.get("http://localhost:4790/api/posts/" + id + "/byCat")
	.success(function (posts) {
	    $scope.posts = posts;
	})
}

function CreatePostsController($scope, $http) {
    $scope.title = "";
    $scope.postContent = "";
    $scope.postDate = new Date().toLocaleString();
    $scope.categories = "";
    $scope.post = function () {
        var post =
            {
                title: $scope.title,
                postContent: $scope.postContent,
                postDate: $scope.postDate,
                categories:$scope.categories.split(",")

            }
        $http.post('http://localhost:4790/api/posts/create',post)
            .success(function () {
                document.location.replace("#/");
            })
    }

}
