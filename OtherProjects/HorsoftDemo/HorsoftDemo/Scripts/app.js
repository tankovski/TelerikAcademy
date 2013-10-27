/// <reference path="lib/_references.js" />

(function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');

    var router = new kendo.Router();

    router.route("/", function () {

        viewsFactory.getHomePage()
             .then(function (loginViewHtml) {
                 var view = new kendo.View(loginViewHtml);
                 appLayout.showIn("#main-content", view);
             });
        $("#appBody").html("");
        appLayout.render("#appBody");

    });

    router.route("/Description", function () {
        viewsFactory.getDescriptionView()
            .then(function (loginViewHtml) {
                var view = new kendo.View(loginViewHtml);
                appLayout.showIn("#main-content", view);
            });
        $("#appBody").html("");
        appLayout.render("#appBody");
    });

    router.route("/Pictures", function () {
        viewsFactory.getPicturesView()
            .then(function (loginViewHtml) {
                var view = new kendo.View(loginViewHtml);
                appLayout.showIn("#main-content", view);
            });
        $("#appBody").html("");
        appLayout.render("#appBody");
    });

    router.route("/Game", function () {
        viewsFactory.getGameView()
            .then(function (loginViewHtml) {
                var view = new kendo.View(loginViewHtml);
                appLayout.showIn("#main-content", view);
            });
        $("#appBody").html("");
        appLayout.render("#appBody");
    });

    router.route("/Responsive", function () {
        viewsFactory.getResponsiveDesignPage()
            .then(function (loginViewHtml) {
                var view = new kendo.View(loginViewHtml);
                appLayout.showIn("#main-content", view);
            });
        $("#appBody").html("");
        appLayout.render("#appBody");
    });

    $(function () {
        appLayout.render("#appBody");
        router.start();
    });
}());