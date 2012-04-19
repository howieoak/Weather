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
    $("input#Lat").val(latitude);
    $("input#Lon").val(longitude);
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



//function set_location(position) {
//    latitude = position.coords.latitude;
//    longitude = position.coords.longitude;
//};

//function handle_error(err) {
//    // error.code can be:
//    //   0: unknown error
//    //   1: permission denied
//    //   2: position unavailable (error response from locaton provider)
//    //   3: timed out
//    switch (err.code) {
//        case 0:
//            geolocation_error = 'Ukjent geolokasjonsfeil!';
//        break;
//        
//        case 1:
//            geolocation_error = 'Du valgte å ikke dele din lokasjon. Det er helt OK!';
//        break;

//        case 2:
//            geolocation_error = 'Ikke mulig å finne din lokasjon!';
//        break;

//        case 3:
//            geolocation_error = 'Ikke mulig å finne din lokasjon!';
//        break;

//        default:
//            alert('Udefinert geolokasjonsfeil!');
//        break;
//    }
//};

//var get_location = function() {
//    if (!!navigator.geolocation) {
//        navigator.geolocation.getCurrentPosition(set_location, handle_error);
//    } else {
//        geolocation_error = 'Din nettleser støtter ikke geolokasjonssporing!';
//    }
//};

$(function() {
    getLocation();
    $("span#temperature").css("color", "Red").css("font-size", "2.8em");
    
})
