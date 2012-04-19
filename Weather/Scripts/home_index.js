/// <reference path="jquery-1.6.2-vsdoc.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(function () {
    $(":input[data-autocomplete]").each(function () {
        $(this).autocomplete({
            source: $(this).attr("data-autocomplete"),
            minLength: 1,
            open: function (event) {
                var $ul = $(this).autocomplete("widget");
                $ul.css("width", "500px")//.hide().slideDown(600);
            }
        });
    });
})

