/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {
	var rootUrl = "Scripts/partials/";

	var templates = {};

	function getTemplate(name) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			if (templates[name]) {
				resolve(templates[name])
			}
			else {
				$.ajax({
					url: rootUrl + name + ".html",
					type: "GET",
					success: function (templateHtml) {
						templates[name] = templateHtml;
						resolve(templateHtml);
					},
					error: function (err) {
						reject(err)
					}
				});
			}
		});
		return promise;
	}

	function getLoginView() {
		return getTemplate("login-register");
	}

	function getAboutView() {
		return getTemplate("chooseOperation");
	}

	function getMoneyTransferView() {
	    return getTemplate("moneyOperations");
	}

	function getGridView() {
	    return getTemplate("grid");
	}

	return {
		getLoginView: getLoginView,
		getAboutView: getAboutView,
		getMoneyTransferView: getMoneyTransferView,
		getGridView: getGridView
	};
}());