/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var TableView = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a TableView must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (template,numberOfRows) {
		    var table = document.createElement("table");
		   
		    var cellsOnALine = this.itemsSource.length / numberOfRows ? this.itemsSource.length / numberOfRows : 1;
		    var currentRow = 0;
		    var currentCell = 0;
		    while (numberOfRows != currentRow) {
		        var newRow = document.createElement("tr");
		        for (var i = 0; i < cellsOnALine; i++) {
		            
		            var item = this.itemsSource[currentCell];
		            newRow.innerHTML += template(item);
		            
		            currentCell++;
		        }
		        table.appendChild(newRow);
		        currentRow++;
		    }
		   
			//table.appendChild(tBody);
			return table.outerHTML;
		}
	});

	c.getTableView = function (itemsSource) {
	    return new TableView(itemsSource);
	}
}(controls || {}));