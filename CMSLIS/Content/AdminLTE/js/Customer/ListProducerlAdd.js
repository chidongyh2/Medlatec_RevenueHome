var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SaveListOrderAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("BackListOrder").href;
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();




    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveListProducerlAdd") {
            check = true;
        }



    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });




    $("#TENNSX").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SODT").focus();
        }
    });


    $("#SODT").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#EMAIL").focus();
        }
    });


    $("#EMAIL").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#WEBSITE").focus();
        }
    });

    $("#WEBSITE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#DIACHI").focus();
        }
    });
    



});
