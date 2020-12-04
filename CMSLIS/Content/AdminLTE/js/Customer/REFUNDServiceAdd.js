var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SaveREFUNDStore').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("BackListPatients").href;
        window.location.href = url;
    }

});




$(document).ready(function () {

    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });
    $('.select2').select2();


    var check = false;


    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveREFUNDService1") {
            check = true;
        }

    });


    $("#SID").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;

            window.location.href = "/Clinic/REFUNDServiceAdd?sid=" + $("#SID").val();
        }
    });

    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });

});



////Update event handler.
//$("body").on("click", "#sorting-table .Refund", function () {
//    var row = $(this).closest("tr");


//    alert(row.find(".MEDICINE_NAME1").text().replace(",", ""));


//});


//Update event handler.
$("body").on("keydown", "#sorting-table .Refund", function () {

    var key_enter = 13; // 13 = Enter
    if (key_enter == event.keyCode) {
        event.keyCode = 0;
        var row = $(this).closest("tr");


        var MEDICINE_AMOUNT1 = parseInt(row.find(".MEDICINE_AMOUNT1").text().replace(",", ""));
        var MEDICINE_PRICE1 = parseInt(row.find(".MEDICINE_PRICE1").text().replace(",", ""));
        var Refund = parseInt(row.find(".Refund").val());

        if (Refund > MEDICINE_AMOUNT1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Số lượng hoàn thuốc lớn hơn số lượng bán!',
            });
        } else {
            row.find(".Refund_PRICE").val(MEDICINE_PRICE1 * Refund);
        }


    }



});


