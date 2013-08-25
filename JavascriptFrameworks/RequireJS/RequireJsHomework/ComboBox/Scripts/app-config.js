/// <reference path="libs/require.js" />
require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        mustache: "libs/mustache",
        ui: "jquery-ui-1.10.3"
    }
});

require(["jquery", "mustache", "app/controls", "ui"], function ($, mustache, controls, ui) {
    var people = [
   { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "imgs/icon1.png" },
   { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "imgs/icon2.png" },
   { id: 3, name: "Ivan Ivanov", age: 22, avatarUrl: "imgs/icon3.png" },
   { id: 4, name: "Peter Petrov", age: 33, avatarUrl: "imgs/icon4.png" },
   { id: 5, name: "Radoslav Radoslavov", age: 16, avatarUrl: "imgs/icon5.png" },
   { id: 6, name: "Slavi Slavov", age: 44, avatarUrl: "imgs/icon6.png" },
   { id: 7, name: "Stefan Stefanov", age: 25, avatarUrl: "imgs/icon7.png" },
   { id: 8, name: "Stoqn Stoqnov", age: 29, avatarUrl: "imgs/icon8.png" },
   { id: 9, name: "Kalin Kalinov", age: 27, avatarUrl: "imgs/icon9.png" }, ];

    var container = document.getElementById("content");

    var comboBox = controls.ComboBox(people);
    var template = $("#items-template").html();
    var comboBoxHtml = comboBox.render(template);
    container.innerHTML = comboBoxHtml;

    (function () {


        $("body").on('click', '#selectWindow', function () {
            if ($("#content").css("display") == "none") {
                $(this).css("border-bottom", "none");
                $("#content").show("blind", {}, 300);
            }
            else {

                $("#content").hide("blind", {}, 300);
                setTimeout(function () {
                    $("#selectWindow").css("border-bottom", "1px solid black");
                }, 300);
            }
        });

        $("body").on('click', '.person-item', function () {
            
            $("#selectWindow").html($(this).html());

            $("#content").hide("blind", {}, 300);
            setTimeout(function () {
                $("#selectWindow").css("border-bottom", "1px solid black");
            }, 300);
            
        });

        }());
    });