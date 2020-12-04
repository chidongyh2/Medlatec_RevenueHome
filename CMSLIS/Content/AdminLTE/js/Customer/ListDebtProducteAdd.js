var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SavListDebtProducteAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("BackListDebtProducte").href;
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();




    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SavListDebtProducteAdd") {
            check = true;
        }



    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });




    $("#BillTotal").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#BillNote").focus();
        }
    });


    $("#date").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SavListDebtProducteAdd").focus();
        }
    });
     



});
