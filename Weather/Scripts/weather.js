/// <reference path="jquery-1.6.2-vsdoc.js" />

var latitude = 000000;
var longitude = 000000;
var geolocation_error;
var message = 'Udefinert';

function showPosition(position) {
    latitude = position.coords.latitude;
    longitude = position.coords.longitude
    message = 'Din lokasjon (lat, lon): ' + latitude + ', ' + longitude;
    $("div#message").text(message);
    $("input#latitude").val(latitude);
    $("input#longitude").val(longitude);
}

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    }
    else {
        geolocation_error = 'Din nettleser støtter ikke geolokasjonssporing!';
        message = 'Din nettleser støtter ikke geolokasjonssporing!';
        $("div#message").text(message);
    }
}

$(function() {
    getLocation();
    $("span#temperature").css("color", "Red").css("font-size", "2.8em");
    
})
