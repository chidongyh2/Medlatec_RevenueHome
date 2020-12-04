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


    $('#Item_ItemPayView').maskNumber({ integer: true });
    //$('#Item_ItemAmountView').maskNumber({ integer: true });
    $('#Item_ItemTotalView').maskNumber({ integer: true });

    //$('#Material_AmountView').maskNumber({ integer: true });
    $('#Material_TotalPriceView').maskNumber({ integer: true });

    $('#Order_Bill_BillTotalView').maskNumber({ integer: true });


    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveListOrderAdd") {
            check = true;
        }
        if ($(this).prop("id") == "SaveListOrderItem") {
            check = true;
        }
        if ($(this).prop("id") == "SaveListOrderMaterial") {
            check = true;
        }
        if ($(this).prop("id") == "SaveListOrderBillAdd") {
            check = true;
        }

    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });




    $("#Order_CustomerName").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#Order_CustomerMobile").focus();
        }
    });


    $("#Order_CustomerMobile").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#Order_CustomerEmail").focus();
        }
    });


    $("#Order_CustomerEmail").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#Order_CustomerDesc").focus();
        }
    });

    $("#Order_CustomerSurrogate").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#Order_CustomerSurrogateMobile").focus();
        }
    });
    $("#Order_CustomerSurrogateMobile").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#date").focus();
        }
    });

    $("#date").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#dateDenngay").focus();
        }
    });

    $("#dateDenngay").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveListOrderAdd").focus();
        }
    });


    $("#Item_ItemPayView").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#Item_ItemAmountView").focus();
        }
    });

    $("#Item_ItemAmountView").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            var total = intVal($("#Item_ItemAmountView").val()) * intVal($("#Item_ItemPayView").val());
            $("#Item_ItemTotalView").val(total);

            $("#Item_ItemTotalView").focus();
        }
    });

    $("#Item_ItemTotalView").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveListOrderItem").focus();
        }
    });

    $("#Material_AmountView").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            var total = intVal($("#Material_AmountView").val()) * intVal($("#MaterialPrice").val());
            $("#Material_TotalPriceView").val(total);
            $("#Material_TotalPriceView").focus();
        }
    });

    $("#Order_Bill_BillCode").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
          
            $("#Order_Bill_BillTotalView").focus();
        }
    });

    $("#Order_Bill_BillTotalView").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;

            $("#Order_Bill_BillNote").focus();
        }
    });


});





function ConfirmItemDelete() {



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
        $.confirm({
            title: 'Xác nhận!',
            content: 'Bạn có chắc thực hiện không?',
            buttons: {
                specialKey: {
                    text: 'Đồng ý',

                    action: function () {

                        $.ajax({
                            type: "POST",
                            url: "/Manage/ListOrderItemDelete",
                            data: JSON.stringify(selectedIDs),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            headers: {
                                'VerificationToken': forgeryId
                            }
                        }).done(function (msg) {
                            toastr.success(msg, 'Thông báo');
                            window.setTimeout(function () { location.reload() }, 3000);
                        }).fail(function (data) {
                            $.alert({
                                title: 'Thông báo!',
                                content: 'Có lỗi trong quá trình xóa bản ghi!',
                            });
                        });
                    }
                },
                alphabet: {
                    text: 'Bỏ qua',
                    action: function () {

                    }
                }
            }
        });
        return true;
    }


}




function ConfirmMaterialDelete() {



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
        $.confirm({
            title: 'Xác nhận!',
            content: 'Bạn có chắc thực hiện không?',
            buttons: {
                specialKey: {
                    text: 'Đồng ý',

                    action: function () {

                        $.ajax({
                            type: "POST",
                            url: "/Manage/ListOrderMaterialDelete",
                            data: JSON.stringify(selectedIDs),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            headers: {
                                'VerificationToken': forgeryId
                            }
                        }).done(function (msg) {
                            toastr.success(msg, 'Thông báo');
                            window.setTimeout(function () { location.reload() }, 3000);
                        }).fail(function (data) {
                            $.alert({
                                title: 'Thông báo!',
                                content: 'Có lỗi trong quá trình xóa bản ghi!',
                            });
                        });
                    }
                },
                alphabet: {
                    text: 'Bỏ qua',
                    action: function () {

                    }
                }
            }
        });
        return true;
    }


}



function ConfirmBillDelete() {



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
        $.confirm({
            title: 'Xác nhận!',
            content: 'Bạn có chắc thực hiện không?',
            buttons: {
                specialKey: {
                    text: 'Đồng ý',

                    action: function () {

                        $.ajax({
                            type: "POST",
                            url: "/Manage/ListOrderBillDelete",
                            data: JSON.stringify(selectedIDs),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            headers: {
                                'VerificationToken': forgeryId
                            }
                        }).done(function (msg) {
                            toastr.success(msg, 'Thông báo');
                            window.setTimeout(function () { location.reload() }, 3000);
                        }).fail(function (data) {
                            $.alert({
                                title: 'Thông báo!',
                                content: 'Có lỗi trong quá trình xóa bản ghi!',
                            });
                        });
                    }
                },
                alphabet: {
                    text: 'Bỏ qua',
                    action: function () {

                    }
                }
            }
        });
        return true;
    }


}


function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}





var intVal = function (i) {

    return typeof i === 'string' ?
        i.replace(/[\$,]/g, '') * 1 :
        typeof i === 'number' ?
            i : 0;
};

function isNullOrEmpty(value) {
    return value == null || value == "";
}



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
function SelectedValueItem(ddlObject) {

    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    if (selectedValue != 0) {

        $.ajax({
            type: "POST",
            url: "/Manage/GetInfoItem?itemid=" + selectedValue,
            data: JSON.stringify(selectedValue),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            $("#Item_ItemPay").focus();
            $.each(msg, function (index, item) {

                if (msg != '') {
                    $("#DETAIL_ID").val(item.id);
                    $("#Item_ItemDesc").val(item.ItemDesc);

                    $("#Item_ItemUnitName").val(item.ItemUnitName);
                    $("#Item_ItemUnit").val(item.ItemUnit);
                    $("#Item_ItemName").val(item.ItemName);
                    $("#Item_ItemNote").val(item.ItemNote);
                    $("#Item_ItemSurvive").val(item.ItemSurvive);
                    $("#Item_ItemPayView").val(item.ItemSurvive);
                    

                } else {
                    $("#DETAIL_ID").val(0);
                    $("#Item_ItemDesc").val();

                    $("#Item_ItemUnitName").val();
                    $("#Item_ItemUnit").val(0);
                    $("#Item_ItemName").val();
                    $("#Item_ItemNote").val();

                    $("#Item_ItemSurvive").val(0);
                    $("#Item_ItemPayView").val(0);
                }



            });

        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình lấy mã dự trù!',
            });

        });

    } else {
        $("#DETAIL_ID").val("0");
    }

}




//To get selected value an text of dropdownlist
function SelectedValueMaterial(ddlObject) {

    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    if (selectedValue != 0) {

        $.ajax({
            type: "POST",
            url: "/Manage/GetInfoMaterial?MaterialID=" + selectedValue,
            data: JSON.stringify(selectedValue),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            $("#Material_Amount").focus();
            $.each(msg, function (index, item) {

                if (msg != '') {
                    $("#Material_ID_New").val(item.id);
                    $("#Material_MaterialDesc").val(item.MaterialDesc);

                    $("#Material_MaterialUnitName").val(item.MaterialUnitName);
                    $("#Material_MaterialUnit").val(item.MaterialUnit);
                    $("#Material_MaterialName").val(item.MaterialName);
                    $("#Material_MaterialCateName").val(item.MaterialCateName);
                    $("#Material_MaterialColorName").val(item.MaterialColorName);
                    $("#MaterialPrice").val(item.MaterialPrice);
                    $("#Material_MaterialPrice").val(item.MaterialPrice);
                    $("#Material_ProducerID").val(item.ProducerID);


                } else {
                    $("#Material_ID_New").val(0);
                    $("#Material_MaterialDesc").val();

                    $("#Material_MaterialUnitName").val();
                    $("#Material_MaterialUnit").val(0);
                    $("#Material_MaterialName").val();
                    $("#Material_MaterialCateName").val();
                    $("#Material_MaterialColorName").val();
                    $("#MaterialPrice").val(0);
                    $("#Material_MaterialPrice").val(0);
                    $("#Material_ProducerID").val(0);

                }



            });

        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình lấy mã dự trù!',
            });

        });

    } else {
        $("#Material_ID_New").val("0");
    }

}


//Update event handler.
$("body").on("click", "#sorting-table-Material .Update", function () {
    var row = $(this).closest("tr");


    $("#Material_ID").val(row.find(".ID1").text().replace(/,/g, ""));
    $("#customer_MaterialID").val(row.find(".ID").text().replace(/,/g, ""));
    var ItemID = row.find(".ID1").text();

    $("#Material_id").select2("val", ItemID);
   
    

    $("#Material_AmountView").val(row.find(".Amount").text().replace(/,/g, ""));
   // $("#Material_AmountView").val(row.find(".TotalPrice").text().replace(/,/g, ""));

    $("#Material_note").val(row.find(".note").text());

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/Manage/GetInfoMaterial?MaterialID=" + ItemID,
        data: JSON.stringify(ItemID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#Material_Amount").focus();
        $.each(msg, function (index, item) {

            if (msg != '') {
                $("#DETAIL_ID").val(item.id);
                $("#Material_MaterialDesc").val(item.MaterialDesc);
                $("#Material_ID_New").val(item.id);
                $("#Material_MaterialUnitName").val(item.MaterialUnitName);
                $("#Material_MaterialUnit").val(item.MaterialUnit);
                $("#Material_MaterialName").val(item.MaterialName);
                $("#Material_MaterialCateName").val(item.MaterialCateName);
                $("#Material_MaterialColorName").val(item.MaterialColorName);
                $("#MaterialPrice").val(item.MaterialPrice);
                $("#Material_MaterialPrice").val(item.MaterialPrice);
                $("#Material_ProducerID").val(item.ProducerID);
               
                

            } else {
                $("#DETAIL_ID").val(0);
                $("#Material_MaterialDesc").val();
                $("#Material_ID_New").val(0);
                $("#Material_MaterialUnitName").val();
                $("#Material_MaterialUnit").val(0);
                $("#Material_MaterialName").val();
                $("#Material_MaterialCateName").val();
                $("#Material_MaterialColorName").val();
                $("#MaterialPrice").val(0);
                $("#Material_MaterialPrice").val(0);
                $("#Material_ProducerID").val(0);
               
            }



        });

    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình lấy mã dự trù!',
        });

    });





});



//Update event handler.
$("body").on("click", "#sorting-table-Item .Update", function () {
    var row = $(this).closest("tr");
   

   // $("#DETAIL_ID").val(row.find(".ID12").text());
    
    var ItemID = row.find(".ID12").text().trim();
    $("#Item_id").select2("val", ItemID);
   


    $("#Item_ItemPayView").val(row.find(".Price").text().replace(/,/g, ""));
    $("#Item_ItemAmountView").val(row.find(".Amount").text().replace(/,/g, ""));
    $("#Item_ItemTotalView").val(row.find(".TotalPrice").text().replace(/,/g, ""));
    $("#Customer_Detailid").val(row.find(".Customerid12").text());
    $("#Item_Note").val(row.find(".Note").text());

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/Manage/GetInfoItem?itemid=" + ItemID,
        data: JSON.stringify(ItemID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#Item_ItemPay").focus();
        $.each(msg, function (index, item) {

            if (msg != '') {
                $("#DETAIL_ID").val(item.id);
                $("#Item_ItemDesc").val(item.ItemDesc);

                $("#Item_ItemUnitName").val(item.ItemUnitName);
                $("#Item_ItemUnit").val(item.ItemUnit);
                $("#Item_ItemName").val(item.ItemName);
                $("#Item_ItemNote").val(item.ItemNote);
                $("#Item_ItemSurvive").val(item.ItemSurvive);

            } else {
                $("#DETAIL_ID").val(0);
                $("#Item_ItemDesc").val();

                $("#Item_ItemUnitName").val();
                $("#Item_ItemUnit").val(0);
                $("#Item_ItemName").val();
                $("#Item_ItemNote").val();

                $("#Item_ItemSurvive").val(0);
            }



        });

    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình lấy mã dự trù!',
        });

    });





});




//Update event handler.
$("body").on("click", "#sorting-table-Bill .Update", function () {
    var row = $(this).closest("tr");


    $("#Billid_id").val(row.find(".Billid").text());

    var ItemID = row.find(".Billid").text();

  

    $("#Order_Bill_BillTotalView").val(row.find(".BillTotal").text().replace(/,/g, ""));
   
    $("#Order_Bill_BillCode").val(row.find(".BillCode").text());

    $("#Order_Bill_BillNote").val(row.find(".BillNote").text());

});


