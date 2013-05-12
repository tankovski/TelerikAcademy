/// <reference path="ExtendFunction.js" />
/// <reference path="InheritFunction.js" />
/// <reference path="Propeller.js" />
/// <reference path="Wheel.js" />
/// <reference path="WaterVehicle.js" />
/// <reference path="LandVehicle.js" />



function Amphibious(speed, propulsionUnits, movingMode) {
    LandVehicle.apply(this, arguments);
    this.mode = movingMode;
}

Amphibious.inherit(LandVehicle);
Amphibious.extend(WaterVehicle, 'changeSpinDirection');

Amphibious.prototype.switchMode = function (mode) {
    this.mode = mode;
};

Amphibious.prototype.accelerate = function () {

    var num = this.propulsionUnits.length;
    var changedSpeed = this.defaultSpeed;

    if (this.mode==="land") {

        for (var i = 0; i < num; i++) {

            if (this.propulsionUnits[i] instanceof Wheel) {
                changedSpeed += this.propulsionUnits[i].getAcceleration();
            }
        }
    }
    else if (this.mode === "water") {
        for (var j = 0; j < num; j++) {
            if (this.propulsionUnits[j] instanceof Propeller) {
                changedSpeed += this.propulsionUnits[j].getAcceleration();
            }
        }
    }

    this.speed = changedSpeed;
};

