/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            },
        };
        return kendo.observable(viewModel);
    };

    function getRegisterViewModel(successCallback) {
        var viewModel = {
            register: function () {
                data.users.register(
                    this.get("username"),
                    this.get("password"),
                    this.get("nickname"),
                    this.get("gender"),
                    this.get("rankId"),
                    this.get("email")
                    )
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            }
        };

        return kendo.observable(viewModel);
    };

    return {
        getLoginVM: getLoginViewModel,
        getRegisterVM: getRegisterViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());