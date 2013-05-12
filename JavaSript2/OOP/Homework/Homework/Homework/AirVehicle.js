/// <reference path="Vehicle.js" />
/// <reference path="PropellingNozzle.js" />
/// <reference path="InheritFunction.js" />

function AirVehicle(speed, propellingNozzles) {
    Vehicle.apply(this, arguments);
}

AirVehicle.inherit(Vehicle);

AirVehicle.prototype.switchAfterburners = function (afterburnerState) {
    var num = this.propulsionUnits.length;

    for (var i = 0; i < num; i++) {
        if (this.propulsionUnits[i] instanceof PropellingNozzle) {
            this.propulsionUnits[i].afterburnerState = afterburnerState;
        }
    }
}