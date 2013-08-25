/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
define(["libs/class", "mustache"], function (Class, mustache) {
	var controls = controls || {};
	var ComboBox = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ComboBox must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (templateHtml) {
		    var template = mustache.compile(templateHtml);
		    var div = document.createElement("div");
			for (var i = 0; i < this.itemsSource.length; i++) {

				var item = this.itemsSource[i];
				div.innerHTML += template(item);

			}
			return div.outerHTML;
		}
	});
	controls.ComboBox = function (itemsSource) {
		return new ComboBox(itemsSource);
	}

	return controls;
});