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

	function getDescriptionView() {
	    return getTemplate("gameDescription");
	}

	function getPicturesView() {
	    return getTemplate("gamePictures");
	}

	function getGameView() {
	    return getTemplate("gamePage");
	}

	function getHomePage() {
	    return getTemplate("homePage");
	}

	function getResponsiveDesignPage() {
	    return getTemplate("responsiveDesign");
	}

	return {
	    getDescriptionView: getDescriptionView,
	    getPicturesView: getPicturesView,
	    getGameView: getGameView,
	    getHomePage: getHomePage,
	    getResponsiveDesignPage: getResponsiveDesignPage
	};
}());