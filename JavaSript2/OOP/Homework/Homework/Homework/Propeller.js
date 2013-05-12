/// <reference path="InheritFunction.js" />
/// <reference path="PropulsionUnit.js" />

function Propeller(numberOfFins, spinDirection) {
    this.numberOfFins = numberOfFins;
    this.spinDirection = spinDirection;
}

Propeller.inherit(PropulsionUnit);

Propeller.prototype.getAcceleration = function () {
    if (this.spinDirection === "counter-clockwise") {
        return this.numberOfFins * (-1);
    }
    else {
        return this.numberOfFins;
    }
};