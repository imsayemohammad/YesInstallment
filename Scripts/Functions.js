/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-ui-1.8.24.js" />
/// <reference path="modernizr-2.6.2.js" />
$('a').click(function () {
    var aval = $(this).attr("href");
    $.session.set("URLLINK", aval);
    alert(aval);
});