$(document).ready(function () {
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });


    $("#SaveReceiptStoreDelete").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });

        if (selectedIDs == '') {
            alert("Mời chọn bản ghi để xóa");
        } else {
            var options = {};
            options.url = "/pharmacyStore/ReceiptStoreDeleteRECEIPT_DETAILS";
            options.type = "POST";
            options.data = JSON.stringify(selectedIDs);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {
                alert(msg);
            };
            options.error = function () {
                alert("Có lỗi trong quá trình xóa bản ghi");
            };
            $.ajax(options);
        }
    });




    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveReceiptStoreAdd") {
            check = true;
        }
        if ($(this).prop("id") == "SaveReceiptStoreChoi") {
            check = true;
        }
        if ($(this).prop("id") == "SaveReceiptStoreDelete") {
            check = true;
        }

    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });


    $("#CONTRACT").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#date").focus();
        }
    });



    $("#NOTE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#MEDICINE_RECEIPT_DETAIL_MEDICINE_ID").focus();
        }
    });

    $("#LOTMUMBER").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#REGISTRATIONNUMBER").focus();
        }
    });

    $("#REGISTRATIONNUMBER").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#AMOUNT").focus();
        }
    });

    $("#AMOUNT").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#IMPORTPRICE").focus();
        }
    });

    $("#IMPORTPRICE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#EXPORTPRICE").focus();
        }
    });

    $("#EXPORTPRICE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#MEDICINE_RECEIPT_DETAIL_VAT").focus();
        }
    });

    $("#MEDICINE_RECEIPT_DETAIL_NOTE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveReceiptStoreChoi").focus();
        }
    });


});



//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    if (selectedValue != 0) {
        var options = {};
        options.url = "/pharmacyStore/GetInfoMedicine?ID=" + selectedValue;
        options.type = "POST";
        options.data = JSON.stringify(selectedValue);
        options.contentType = "application/json";
        options.dataType = "json";
        options.success = function (msg) {
            $.each(msg, function (index, item) {
                $("#MEDICINE_CODE").val(item.ID);
                $("#MEDICINE_NAME").val(item.MEDICINE_NAME);

            });
        };
        options.error = function () {
            alert("Có lỗi trong quá trình lấy mã dự trù");
        };
        $.ajax(options);
    } else {
        $("#MEDICINE_CODE").val("");
    }

}
