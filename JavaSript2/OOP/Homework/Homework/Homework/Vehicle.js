/// <reference path="PropulsionUnit.js" />

function Vehicle(speed, propulsionUnits) {
    this.speed = speed;
    this.propulsionUnits = propulsionUnits;
    this.defaultSpeed = speed;
};

Vehicle.prototype.accelerate = function () {
    var num = this.propulsionUnits.length;
    var changedSpeed = this.defaultSpeed;

    for (var i = 0; i < num; i++) {
        changedSpeed += this.propulsionUnits[i].getAcceleration();
    }
    this.speed = changedSpeed;
};


var LandVehicle = function LandVehicle(speed, wheels) {
    Vehicle.apply(this, arguments);
}

LandVehicle.inherit(Vehicle);
