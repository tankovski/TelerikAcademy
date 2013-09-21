/// <reference path="jquery-2.0.3.js" />
(function () {
    $("#form1").on("click", ".Image", function (ev) {
        var attr = $("#img1").attr("src");

        window.open(attr, 'Popup', 'width=1600,height=1200');

    });
})();