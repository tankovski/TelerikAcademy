(function ($) {
    $.fn.treeView = function () {
        var elements = $(this.selector);
        elements.on("mouseover", function () {
            var oldWidth = parseInt($(this).css("width"));
            var oldHeight = parseInt($(this).css("height"));
            $(this).css("width", (oldWidth * 2) + "px");
            $(this).css("height", (oldHeight * 2) + "px");
        });

        elements.on("mouseout", function () {
            var oldWidth = parseInt($(this).css("width"));
            var oldHeight = parseInt($(this).css("height"));
            $(this).css("width", (oldWidth / 2) + "px");
            $(this).css("height", (oldHeight / 2) + "px");
        });
        return this;
    }
}(jQuery))