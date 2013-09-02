/// <reference path="libs/_references.js" />


(function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/register", function () {
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
				});
        }
    });

    router.route("/login", function () {
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
				});
        }
    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());