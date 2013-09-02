/// <reference path="../libs/sha1.js" />
/// <reference path="../libs/underscore.js" />

var sessionKey = localStorage.getItem("adminSessionKey");
var username = localStorage.getItem("adminNickname");

function UsersController($scope, $http) {

    var logedUser = localStorage.getItem("adminNickname");
    if (logedUser) {
    $scope.users = "";

	$http({
	    url: 'api/users/all/' + sessionKey,
	    dataType: "application/json",
	    method: 'GET',
	    data: '',
	    headers: {
	        "Content-Type": "application/json"
	    }

	}).success(function (users) {
	    $scope.users = users;
	}).error(function (error) {
	    alert(JSON.stringify(error));
	});
}
    else {
        document.location.replace("#/");
    }

}

function SingleUserController($scope, $http, $routeParams) {
    var logedUser = localStorage.getItem("adminNickname");
    if (logedUser) {

	var id = $routeParams.id;
        $http.get("api/users/" + id + "/info/" + sessionKey)
	.success(function (user) {
	    $scope.user = user;
	    $scope.ban = function () {
	        $http.delete("api/users/" + id + "/delete/" + sessionKey)
                .success(function () {
                    document.location.replace("#/users");
                }).error(function (error) {
                    alert(JSON.stringify(error));
                });
	    };
	    $scope.promote = function () {
                if (user.Rank == "admin") {
	            alert("User is already admin");
	        }
	        else {
                    $http.put("api/users/" + id + "/promote/" + sessionKey)
                 .success(function () {
                         document.location.replace("#/user/" + id);
                 }).error(function (error) {
                     alert(JSON.stringify(error));
                 });
	        }
	        
	    }
	})
}
    else {
        document.location.replace("#/");
    }
}

function LoginControlelr($scope, $http) {

    var logedUser = localStorage.getItem("adminNickname");
    if (logedUser) {
        document.location.replace("#/users");
    }
    else {


        $scope.username = "";
        $scope.password = "";
        $scope.login = function () {
            var user =
                {
                    username: $scope.username,
                    authKey: CryptoJS.SHA1($scope.password).toString()
                }
            $http.post("api/users/login", user)
                .success(function (response) {
                    if (response.Rank == "admin") {
                        localStorage.setItem("adminSessionKey", response.SessionKey)
                        localStorage.setItem("adminNickname", response.Nickname);
                        window.location.reload();

                        setTimeout(function () {
                            window.location.replace("#/users");
                        }, 10);
                    }
                    else {
                        alert("This user is not admin");
                    }
                }).error(function (error) {
                    alert(JSON.stringify(error));
                });
        }
    }
}

function PostsController($scope, $http, $routeParams) {
    $scope.posts = "";
    $scope.disapprove = function (postId) {
        $http({
            url: 'api/posts/disapprove/' + postId + '/' + sessionKey,
            dataType: "application/json",
            method: 'PUT',
            data: {
                approved: false
            },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (data) {
            console.log(data);
        });
    };

        $http({
            url: 'api/posts/getall/' + sessionKey,
            dataType: "application/json",
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (posts) {
            console.log(posts);
            $scope.posts = posts;
        }).error(function (error) {
            alert(JSON.stringify(error));
        });
}