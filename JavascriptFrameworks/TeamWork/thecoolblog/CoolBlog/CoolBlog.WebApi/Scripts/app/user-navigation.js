/// <reference path="../lib/_references.js" />
window.userNavigation = (function () {
    var render = function (data) {
        if (data.users.currentUser()) {
            $("#logged-user").html(data.users.currentUser());
            $("#logout-link").show();
            $("#register-link").hide();
            $("#login-link").hide();
        }
        else {
            $("#logged-user").html("");
            $("#logout-link").hide();
            $("#register-link").show();
            $("#login-link").show();
        }
    }

    return {
        render: render
    };
}());