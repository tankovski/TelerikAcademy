/// <reference path="ClassCreate.js" />
var map;
var City = Class.create({
    init: function (name, x, y, description, link) {
        this.name = name;
        this.x = x;
        this.y = y;
        this.description = description;
        this.link = link;
    }

});

var currentCity = 0;

var sofia = new City("Sofia", 42.6544, 23.3649, "This is the capitol citie of Bulgaria", 'https://en.wikipedia.org/wiki/Sofia');
var rome = new City("Rome", 41.9000, 12.5000, "This is the capitol citie of Italy", 'http://en.wikipedia.org/wiki/Rome');
var paris = new City("Paris", 48.8742, 2.3470, "This is the capitol citie of France", 'https://en.wikipedia.org/wiki/Paris');
var berlin = new City("Berlin", 52.5233, 13.4127, "This is the capitol citie of Germany", 'http://en.wikipedia.org/wiki/Berlin');
var vienna = new City("Vienna", 48.2088, 16.3726, "This is the capitol citie of Austria", 'https://en.wikipedia.org/wiki/Vienna');
var madrid = new City("Madrid", 40.4000, 356.3000, "This is the capitol citie of Spain", 'http://en.wikipedia.org/wiki/Madrid');
var belgrade = new City("Belgrade", 44.8206, 20.4622, "This is the capitol citie of Serbia", 'http://en.wikipedia.org/wiki/Belgrade');
var bucharest = new City("Bucharest", 44.4167, 26.1000, "This is the capitol citie of Romenia", 'https://en.wikipedia.org/wiki/Bucharest');
var budapest = new City("Budapest", 47.5000, 19.0500, "This is the capitol citie of Hungary", 'http://en.wikipedia.org/wiki/Budapest');
var prague = new City("Prague", 50.0833, 14.4167, "This is the capitol citie of Czech Republic", 'http://en.wikipedia.org/wiki/Prague');

var cities = [sofia, rome,paris,berlin,vienna,madrid,belgrade,bucharest,budapest,prague];

(function visualiseCities() {
    var container = document.getElementById("citiesContainer");
    
    container.onclick = function (ev) {
        
        if (ev.target instanceof HTMLAnchorElement) {
            currentCity = parseInt(ev.target.id);
            initialize();
        }
    };

    for (var i = 0; i < cities.length; i++) {
        container.innerHTML += "<li><a href='#' class='cityLinc' id="+i+">" + cities[i].name + "</a></li>";

    }

}());

function nextCity() {
    currentCity += 1;
    if (currentCity >= cities.length) {
        currentCity = 0;
    }
    initialize();
};

function prevCity() {
    currentCity -= 1;
    if (currentCity < 0) {
        currentCity = cities.length-1;
    }
    initialize();
};

function initialize() {
    var x = cities[currentCity].x;
    var y = cities[currentCity].y;
    var z = 7;

    var mapOptions = {
        zoom: z,
        center: new google.maps.LatLng(x, y),
        mapTypeId: google.maps.MapTypeId.ROADMAP //SATELLITE
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    var contentString = '<div id="content">' +
     cities[currentCity].description +
     ' for more info: ' +
     '<br/>' +
     '<a href="' +
     cities[currentCity].link +
     '">Click Here</a>' +
      '</div>';

    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });

    var marker = new google.maps.Marker({
        position: map.getCenter(),
        map: map,
        title: cities[currentCity].name
    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.open(map, marker);
    });
}


google.maps.event.addDomListener(window, 'load', initialize());

console.log(map);