﻿var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SaveReportDebtProducteAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("BackReportDebtProducte").href;
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();
   // $('#Total').maskNumber({ integer: true });
});

