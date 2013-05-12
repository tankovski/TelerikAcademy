/// <reference path="Vehicle.js" />
/// <reference path="InheritFunction.js" />
/// <reference path="Propeller.js" />

function WaterVehicle(speed, propulsionUnits) {
    Vehicle.apply(this, arguments);
    this.propulsionUnits = propulsionUnits; 
}

WaterVehicle.inherit(Vehicle);

WaterVehicle.prototype.changeSpinDirection = function (spinDirection) {
    var num = this.propulsionUnits.length;

    for (var i = 0; i < num; i++) {
        if (this.propulsionUnits[i] instanceof Propeller) {
            this.propulsionUnits[i].spinDirection = spinDirection;
        }
    }
};