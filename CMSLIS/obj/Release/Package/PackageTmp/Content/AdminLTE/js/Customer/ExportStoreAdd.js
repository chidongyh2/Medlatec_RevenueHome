var keyCodeOld; 

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        document.getElementById('SaveExportStoreAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        var url = document.getElementById("BackListPatients").href;
        window.location.href = url;
    }

});



//(function ($) {
//    'use strict';
//    var datatableInit = function () {
//        $('#sorting-table').dataTable(
//            {
//                //"columnDefs": [{
//                //    "targets": 'no-sort',
//                //    "orderable": false,
//                //}],
//                "iDisplayLength": 100
//            }
//        );
//    };
//    $(function () {
//        datatableInit();
//    });

//}).apply(this, [jQuery]);


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

    $('#MEDICINE_AMOUNT').maskNumber({ integer: true });
    //$('#MEDICINE_PRICE').maskNumber({ integer: true });
    //$('#MEDICINE_TOTAL').maskNumber({ integer: true });

    $("#SaveExportStoreDelete").click(function () {
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
            return false;
        } else {

            $.ajax({
                type: "POST",
                url: "/pharmacyStore/ExportStorDeleteEXPORT_DETAIL",
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


        if ($(this).prop("id") == "SaveExportStoreAdd") {
            check = true;
        }
        if ($(this).prop("id") == "SaveExportStoreChoi") {
            check = true;
        }
        if ($(this).prop("id") == "SaveExportStoreDelete") {
            check = true;
        }

    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });


    $("#EMPLOYEECODE").keydown(function () {
        var forgeryId = $("#forgeryToken").val();
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;

            if ($("#EMPLOYEECODE").val() != '') {

                $.ajax({
                    type: "POST",
                    url: "/Clinic/ListPatientsByPID?pid=" + $("#EMPLOYEECODE").val(),
                    data: JSON.stringify($("#EMPLOYEECODE").val()),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    headers: {
                        'VerificationToken': forgeryId
                    }
                }).done(function (msg) {
                    $.each(msg, function (index, item) {
                        $("#CUSTOMER_NAME").val(item.PATIENTNAME);
                        $("#CUSTOMER_ADDRESS").val(item.ADDRESS);
                        $("#CUSTOMER_MOBILE").val(item.PHONE);
                        $("#CUSTOMER_EMAIL").val(item.EMAILADDRESS);
                        $("#CUSTOMER_GENDER").val(item.SEX);
                        $("#MEDICINE_TOTAL").val(item.TOTAL_AMOUNT);
                    });

                }).fail(function (data) {
                    $.alert({
                        title: 'Thông báo!',
                        content: 'Có lỗi trong quá trình lấy thông tin bệnh nhân!',
                    });

                });



            }



        }
    });

    $("#CUSTOMER_NAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CUSTOMER_GENDER").focus();
        }
    });

    $("#CUSTOMER_ADDRESS").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CUSTOMER_MOBILE").focus();
        }
    });

    $("#CUSTOMER_MOBILE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CUSTOMER_EMAIL").focus();
        }
    });

    $("#CUSTOMER_EMAIL").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#NOTE").focus();
        }
    });

    $("#NOTE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#MEDICINE_ID").focus();
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
    //            url: "pharmacyStore/ReceiptStoreDeleteRECEIPT_DETAILS",
    //            data: JSON.stringify(selectedIDs),
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            headers: {
    //                'VerificationToken': forgeryId
    //            }
    //        }).done(function (msg) {
    //            alert(msg);
    //            location.reload();

    //        }).fail(function (data) {
    //            alert("Có lỗi trong quá trình xóa bản ghi");
    //        });

}
//return true;
//    }

//    else
//return false;
//}


function formatJSONDate(jsonDate) {
    var value = new Date
        (
        parseInt(jsonDate.replace(/(^.*\()|([+-].*$)/g, ''))
        );
    var dat = value.getMonth() +
        1 +
        "/" +
        value.getDate() +
        "/" +
        value.getFullYear();

    return dat;
}




//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {

    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    if (selectedValue != 0) {

        $.ajax({
            type: "POST",
            url: "/pharmacyStore/GetInfoMedicineExport?code=" + selectedValue,
            data: JSON.stringify(selectedValue),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            $("#MEDICINE_AMOUNT").focus();
            $.each(msg, function (index, item) {

                if (msg != '') {
                    $("#MEDICINE_CODE").val(item.ID);
                    $("#MEDICINE_CODE1").val(item.ID);
                    $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
                    $("#LOTMUMBER").val(item.LOTMUMBER);
                    $("#LOTMUMBER1").val(item.LOTMUMBER);
                    $("#MEDICINE_PRICE").val(item.EXPORTPRICE);
                    $("#MEDICINE_PRICE1").val(item.EXPORTPRICE);
                    $("#MEDICINE_CREATE").val(item.DATEOFMANUFACTURE_View);
                    $("#MEDICINE_CREATE1").val(item.DATEOFMANUFACTURE_View);
                    $("#MEDICINE_EXPIRED").val(item.EXPIRYDATE_View);
                    $("#MEDICINE_EXPIRED1").val(item.EXPIRYDATE_View);
                    $("#MEDICINE_TOTAL").val(item.TOTAL_AMOUNT);
                    $("#MEDICINE_TOTAL1").val(item.TOTAL_AMOUNT);
                    $("#MEDICINE_UNIT").val(item.MEDICINE_UNIT);
                } else {
                    $("#MEDICINE_CODE").val(0);
                    $("#MEDICINE_CODE1").val();
                    $("#MEDICINE_NAME").val();
                    $("#LOTMUMBER").val();
                    $("#LOTMUMBER1").val();
                    $("#MEDICINE_PRICE").val();
                    $("#MEDICINE_PRICE1").val();
                    $("#MEDICINE_CREATE").val();
                    $("#MEDICINE_CREATE1").val();
                    $("#MEDICINE_EXPIRED").val();
                    $("#MEDICINE_EXPIRED1").val();
                    $("#MEDICINE_TOTAL").val();
                    $("#MEDICINE_TOTAL1").val();
                    $("#MEDICINE_UNIT").val(0);
                }



            });

        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình lấy mã dự trù!',
            });

        });


        //var options = {};
        //options.url = "/pharmacyStore/GetInfoMedicineExport?code=" + selectedValue;
        //options.type = "POST";
        //options.data = JSON.stringify(selectedValue);
        //options.contentType = "application/json";
        //options.dataType = "json";
        //options.success = function (msg) {

        //    $("#MEDICINE_AMOUNT").focus();
        //    $.each(msg, function (index, item) {



        //        if (msg!= '') {
        //            $("#MEDICINE_CODE").val(item.ID);
        //            $("#MEDICINE_CODE1").val(item.ID);
        //            $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
        //            $("#LOTMUMBER").val(item.LOTMUMBER);
        //            $("#LOTMUMBER1").val(item.LOTMUMBER);
        //            $("#MEDICINE_PRICE").val(item.EXPORTPRICE);
        //            $("#MEDICINE_PRICE1").val(item.EXPORTPRICE);
        //            $("#MEDICINE_CREATE").val(item.DATEOFMANUFACTURE_View);
        //            $("#MEDICINE_CREATE1").val(item.DATEOFMANUFACTURE_View);
        //            $("#MEDICINE_EXPIRED").val(item.EXPIRYDATE_View);
        //            $("#MEDICINE_EXPIRED1").val(item.EXPIRYDATE_View);
        //            $("#MEDICINE_TOTAL").val(item.TOTAL_AMOUNT);
        //            $("#MEDICINE_TOTAL1").val(item.TOTAL_AMOUNT);
        //        } else {
        //            $("#MEDICINE_CODE").val(0);
        //            $("#MEDICINE_CODE1").val();
        //            $("#MEDICINE_NAME").val();
        //            $("#LOTMUMBER").val();
        //            $("#LOTMUMBER1").val();
        //            $("#MEDICINE_PRICE").val();
        //            $("#MEDICINE_PRICE1").val();
        //            $("#MEDICINE_CREATE").val();
        //            $("#MEDICINE_CREATE1").val();
        //            $("#MEDICINE_EXPIRED").val();
        //            $("#MEDICINE_EXPIRED1").val();
        //            $("#MEDICINE_TOTAL").val();
        //            $("#MEDICINE_TOTAL1").val();
        //        }



        //    });
        //};
        //options.error = function () {
        //    alert("Có lỗi trong quá trình lấy mã dự trù");
        //};
        //$.ajax(options);
    } else {
        $("#MEDICINE_CODE").val("");
    }

}



//Update event handler.
$("body").on("click", "#sorting-table .Update", function () {
    var row = $(this).closest("tr");

    // $("#MEDICINE_NAME").val(row.find(".MEDICINE_NAME1").text());
    $("#MEDICINE_AMOUNT").val(row.find(".MEDICINE_AMOUNT1").text());
    $("#DETAIL_ID").val(row.find(".ID1").text());

    var MEDICINE_CODE = row.find(".MEDICINE_CODE1").text();

    $("#MEDICINE_ID").select2("val", MEDICINE_CODE);
    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/pharmacyStore/GetInfoMedicineExport?code=" + MEDICINE_CODE,
        data: JSON.stringify(MEDICINE_CODE),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#MEDICINE_AMOUNT").focus();
        $.each(msg, function (index, item) {



            if (msg != '') {
                $("#MEDICINE_CODE").val(item.ID);
                $("#MEDICINE_CODE1").val(item.ID);
                $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
                $("#LOTMUMBER").val(item.LOTMUMBER);
                $("#LOTMUMBER1").val(item.LOTMUMBER);
                $("#MEDICINE_PRICE").val(item.EXPORTPRICE);
                $("#MEDICINE_PRICE1").val(item.EXPORTPRICE);
                $("#MEDICINE_CREATE").val(item.DATEOFMANUFACTURE_View);
                $("#MEDICINE_CREATE1").val(item.DATEOFMANUFACTURE_View);
                $("#MEDICINE_EXPIRED").val(item.EXPIRYDATE_View);
                $("#MEDICINE_EXPIRED1").val(item.EXPIRYDATE_View);
                $("#MEDICINE_TOTAL").val(item.TOTAL_AMOUNT);
                $("#MEDICINE_TOTAL1").val(item.TOTAL_AMOUNT);
            } else {
                $("#MEDICINE_CODE").val(0);
                $("#MEDICINE_CODE1").val();
                $("#MEDICINE_NAME").val();
                $("#LOTMUMBER").val();
                $("#LOTMUMBER1").val();
                $("#MEDICINE_PRICE").val();
                $("#MEDICINE_PRICE1").val();
                $("#MEDICINE_CREATE").val();
                $("#MEDICINE_CREATE1").val();
                $("#MEDICINE_EXPIRED").val();
                $("#MEDICINE_EXPIRED1").val();
                $("#MEDICINE_TOTAL").val();
                $("#MEDICINE_TOTAL1").val();
            }



        });

    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình lấy mã dự trù!',
        });
    });


    //var options = {};
    //options.url = "/pharmacyStore/GetInfoMedicineExport?code=" + MEDICINE_CODE;
    //options.type = "POST";
    //options.data = JSON.stringify(MEDICINE_CODE);
    //options.contentType = "application/json";
    //options.dataType = "json";
    //options.success = function (msg) {
    //    $("#MEDICINE_AMOUNT").focus();
    //    $.each(msg, function (index, item) {
    //        if (msg != '') {

    //            $("#MEDICINE_CODE").val(item.MEDICINE_CODE);
    //            $("#MEDICINE_CODE1").val(item.MEDICINE_CODE);
    //            $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
    //            $("#LOTMUMBER").val(item.LOTMUMBER);
    //            $("#LOTMUMBER1").val(item.LOTMUMBER);
    //            $("#MEDICINE_PRICE").val(item.EXPORTPRICE);
    //            $("#MEDICINE_PRICE1").val(item.EXPORTPRICE);
    //            $("#MEDICINE_CREATE").val(item.DATEOFMANUFACTURE_View);
    //            $("#MEDICINE_CREATE1").val(item.DATEOFMANUFACTURE_View);
    //            $("#MEDICINE_EXPIRED").val(item.EXPIRYDATE_View);
    //            $("#MEDICINE_EXPIRED1").val(item.EXPIRYDATE_View);
    //            $("#MEDICINE_TOTAL").val(item.TOTAL_AMOUNT);
    //            $("#MEDICINE_TOTAL1").val(item.TOTAL_AMOUNT);
    //        } else {

    //            $("#MEDICINE_CODE").val();
    //            $("#MEDICINE_CODE1").val();
    //            $("#MEDICINE_NAME").val();
    //            $("#LOTMUMBER").val();
    //            $("#LOTMUMBER1").val();
    //            $("#MEDICINE_PRICE").val();
    //            $("#MEDICINE_PRICE1").val();
    //            $("#MEDICINE_CREATE").val();
    //            $("#MEDICINE_CREATE1").val();
    //            $("#MEDICINE_EXPIRED").val();
    //            $("#MEDICINE_EXPIRED1").val();
    //            $("#MEDICINE_TOTAL").val();
    //            $("#MEDICINE_TOTAL1").val();
    //        }
    //    });
    //};
    //options.error = function () {
    //    alert("Có lỗi trong quá trình lấy mã dự trù");
    //};
    //$.ajax(options);


});


