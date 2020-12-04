var keyCodeOld; 

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0; 
        document.getElementById('SaveReceiptStoreAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0; 
        var url = document.getElementById("BackReceiptStore").href;
        window.location.href = url;
    }

});


(function ($) {
    'use strict';
    var datatableInit = function () {
        $('#sorting-table').dataTable(
            {
                //"columnDefs": [{
                //    "targets": 'no-sort',
                //    "orderable": false,
                //}],
                "iDisplayLength": 100
            }
        );
    };
    $(function () {
        datatableInit();
    });

}).apply(this, [jQuery]);


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

    //Date picker
    $('#date').datepicker({
        dateFormat: "dd/mm/yyyy"
    })

    $('#AMOUNT').maskNumber({ integer: true });
    $('#IMPORTPRICE').maskNumber({ integer: true });
    $('#EXPORTPRICE').maskNumber({ integer: true });



    $('#nsx').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $('#hsd').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    //$("#AMOUNT").inputmask("99-9999999");


    $("#SaveReceiptStoreDelete").click(function () {
        var selectedIDs = new Array();
        var forgeryId = $("#forgeryToken").val();

        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });

        if (selectedIDs == '') {
            $.alert({
                title: 'Thông báo!',
                content: 'Mời chọn bản ghi để xóa!',
            });
            return false;

        } else {


            $.ajax({
                type: "POST",
                url: "/pharmacyStore/ReceiptStoreDeleteRECEIPT_DETAILS",
                data: JSON.stringify(selectedIDs),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                headers: {
                    'VerificationToken': forgeryId
                }
            }).done(function (msg) {
                alert(msg);

            }).fail(function (data) {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Có lỗi trong quá trình xóa bản ghi!',
                });
                return false;


            });



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

    //$("#IMPORTPRICE").keydown(function () {
    //    $('#IMPORTPRICE').inputmask({
    //        alias: 'numeric',
    //        allowMinus: false,
    //        digits: 3,
    //        max: 999.99
    //    });
    //});


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




function ReceiptStoreDelete() {

    $.confirm({
        title: 'Xác nhận!',
        content: 'Bạn có chắc thực hiện không?',
        buttons: {
            specialKey: {
                text: 'Đồng ý',

                action: function () {
                    var forgeryId = $("#forgeryToken").val();
                    var selectedIDs = new Array();
                    $('input:checkBox.checkBox').each(function () {
                        if ($(this).prop('checked')) {
                            selectedIDs.push($(this).val());
                        }
                    });
                    if (selectedIDs == '') {
                        $.alert({
                            title: 'Thông báo!',
                            content: 'Mời chọn bản ghi để xóa!',
                        });
                    } else {
                        $.ajax({
                            type: "POST",
                            url: "/pharmacyStore/ReceiptStoreDeleteRECEIPT_DETAILS",
                            data: JSON.stringify(selectedIDs),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            headers: {
                                'VerificationToken': forgeryId
                            }
                        }).done(function (msg) {

                            $.alert({
                                title: 'Thông báo!',
                                content: msg,
                            });
                            location.reload();
                        }).fail(function (data) {
                            $.alert({
                                title: 'Thông báo!',
                                content: 'Có lỗi trong quá trình xóa bản ghi',
                            });
                        });
                    }
                    return true;

                }
            },
            alphabet: {
                text: 'Bỏ qua',
                action: function () {

                }
            }
        }
    });

    //var forgeryId = $("#forgeryToken").val();
    //var x = confirm("Bạn có chắc không?");
    //if (x) {
    //    var selectedIDs = new Array();
    //    $('input:checkBox.checkBox').each(function () {
    //        if ($(this).prop('checked')) {
    //            selectedIDs.push($(this).val());
    //        }
    //    });
    //    if (selectedIDs == '') {
    //        alert("Mời chọn bản ghi để duyệt");
    //    } else {

    //        $.ajax({
    //            type: "POST",
    //            url: "/pharmacyStore/ReceiptStoreDeleteRECEIPT_DETAILS",
    //            data: JSON.stringify(selectedIDs),
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            headers: {
    //                'VerificationToken': forgeryId
    //            }
    //        }).done(function (msg) {
    //            alert(msg);

    //        }).fail(function (data) {
    //            alert("Có lỗi trong quá trình xóa bản ghi");
    //        });


    //    }
    //    return true;
    //}

    //else
    //    return false;
}




function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    if (selectedValue != 0) {

        $.ajax({
            type: "POST",
            url: "/pharmacyStore/GetInfoMedicine?ID=" + selectedValue,
            data: JSON.stringify(selectedValue),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            $.each(msg, function (index, item) {
                $("#MEDICINE_CODE1").val(item.ID);
                $("#MEDICINE_CODE").val(item.ID);
                $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
                $("#MEDICINE_UNIT_NAME").val(item.MEDICINE_UNIT_NAME);
                $("#MEDICINE_UNIT").val(item.MEDICINE_UNIT);

            });
        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình lấy mã dự trù',
            });

        });
    } else {
        $("#MEDICINE_CODE").val("");
    }

}



//Update event handler.
$("body").on("click", "#sorting-table .Update", function () {
    var row = $(this).closest("tr");

    // $("#MEDICINE_NAME").val(row.find(".MEDICINE_NAME1").text());
    $("#AMOUNT").val(row.find(".AMOUNT1").text().replace(",", ""));
    $("#DETAIL_ID").val(row.find(".ID1").text().replace(",", ""));

    var MEDICINE_CODE = row.find(".MEDICINE_CODE1").text();

    $("#MEDICINE_ID").select2("val", MEDICINE_CODE);

    $("#LOTMUMBER").val(row.find(".LOTMUMBER1").text());
    $("#REGISTRATIONNUMBER").val(row.find(".REGISTRATIONNUMBER1").text());
    $("#REGISTRATIONNUMBER").val(row.find(".REGISTRATIONNUMBER1").text());
    $("#IMPORTPRICE").val(row.find(".IMPORTPRICE1").text().replace(/,/g, ""));
    $("#EXPORTPRICE").val(row.find(".EXPORTPRICE1").text().replace(/,/g, ""));
    $("#nsx").val(row.find(".DATEOFMANUFACTURE1").text().replace(/,/g, ""));
    $("#hsd").val(row.find(".EXPIRYDATE1").text().replace(/,/g, ""));
    $("#NOTEDETAIL").val(row.find(".NOTE1").text());

    var VAT = row.find(".VAT1").text();

    $("#VAT").select2("val", VAT);

    var PROVIDEDID = row.find(".PROVIDEDID1").text();

    $("#PROVIDEDID").select2("val", PROVIDEDID);
    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/pharmacyStore/GetInfoMedicine?ID=" + MEDICINE_CODE,
        data: JSON.stringify(MEDICINE_CODE),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $.each(msg, function (index, item) {
            $("#MEDICINE_CODE1").val(item.ID);
            $("#MEDICINE_CODE").val(item.ID);
            $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
            $("#MEDICINE_UNIT_NAME").val(item.MEDICINE_UNIT_NAME);

        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình lấy mã dự trù',
        });
    });
});


