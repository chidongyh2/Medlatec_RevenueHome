var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SaveListCustomerAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("BackListCustomer").href;
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();




    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveListCustomerAdd") {
            check = true;
        }



    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });




    $("#CustomerName").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CustomerMobile").focus();
        }
    });


    $("#CustomerMobile").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CustomerEmail").focus();
        }
    });


    $("#CustomerEmail").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CustomerDesc").focus();
        }
    });

    $("#CustomerSurrogate").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CustomerSurrogateMobile").focus();
        }
    });
    $("#CustomerSurrogateMobile").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#date").focus();
        }
    });

   




});
