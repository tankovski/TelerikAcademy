(function () {
	if (!Array.prototype.indexOf) {
		function arrayIndexOf (searchElement, fromIndex) {
			for (var i = fromIndex || 0, len = this.length; i < len; i++) {
				if (this[i] === searchElement) {
					return i;
				}
			}
			return -1;
		}

		Array.prototype.indexOf = arrayIndexOf;
	}
}).call(this);