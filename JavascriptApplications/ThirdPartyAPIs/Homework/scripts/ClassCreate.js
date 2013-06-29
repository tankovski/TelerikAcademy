var Class = (function () {
    function createClass(properties) {
        var f = function () {
            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        if (!f.prototype.init) {
            f.prototype.init = function () { }
        }
        return f;
    }

    return {
        create: createClass,
    };
}());