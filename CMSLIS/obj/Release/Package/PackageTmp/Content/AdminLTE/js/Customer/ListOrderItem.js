

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

   
    $('#Item_ItemPayView').maskNumber({ integer: true });
    //$('#Item_ItemAmountView').maskNumber({ integer: true });
    $('#Item_ItemTotalView').maskNumber({ integer: true });


    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveListOrderItem") {
            check = true;
        }



    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
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

    $("#Item_ItemTotal").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveListOrderItem").focus();
        }
    });


});





function ConfirmDelete() {



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
function SelectedValue(ddlObject) {

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

    } else {
        $("#DETAIL_ID").val("0");
    }

}



//Update event handler.
$("body").on("click", "#sorting-table .Update", function () {
    var row = $(this).closest("tr");


    $("#DETAIL_ID").val(row.find(".ID1").text());

    var ItemID = row.find(".ID1").text();

    $("#Item_id").select2("val", ItemID);


    $("#Item_ItemPayView").val(row.find(".Price").text().replace(/,/g, ""));
    $("#Item_ItemAmountView").val(row.find(".Amount").text().replace(/,/g, ""));
    $("#Item_ItemTotalView").val(row.find(".TotalPrice").text().replace(/,/g, ""));
  


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


