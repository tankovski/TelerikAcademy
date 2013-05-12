/// <reference path="PropulsionUnit.js" />
/// <reference path="InheritFunction.js" />

function PropellingNozzle(power, afterburnerState) {
    this.power = power;   
    this.afterburnerState = afterburnerState;
}

PropellingNozzle.inherit(PropulsionUnit);

PropellingNozzle.prototype.getAcceleration = function () {
    if (this.afterburnerState === "on") {
        return 2 * this.power;
    }
    else {
        return this.power;
    }
};