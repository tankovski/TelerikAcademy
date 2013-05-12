/// <reference path="Vehicle.js" />
/// <reference path="Wheel.js" />
/// <reference path="InheritFunction.js" />

var LandVehicle = function LandVehicle(speed, wheels) {
    Vehicle.apply(this, arguments);
}

LandVehicle.inherit(Vehicle);