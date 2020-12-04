

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

    //$('#Material_AmountView').maskNumber({ integer: true });
    $('#Material_TotalPrice').maskNumber({ integer: true });
   

    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveListOrderMaterial") {
            check = true;
        }
        


    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });

    //$("#Material_AmountView").keydown(function () {
    //    var key_enter = 13; // 13 = Enter
    //    if (key_enter == event.keyCode) {
    //        event.keyCode = 0;
    //        $("#SaveListOrderMaterial").focus();
    //    }
    //});

    $("#Material_AmountView").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            alert('dsfsdfd')
            var total = intVal($("#Material_AmountView").val()) * intVal($("#MaterialPrice").val());
            $("#Material_TotalPrice").val(total);
            $("#Material_TotalPrice").focus();
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
                    $("#DETAIL_ID").val(item.id);
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
                    $("#DETAIL_ID").val(0);
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
        $("#DETAIL_ID").val("0");
    }

}



//Update event handler.
$("body").on("click", "#sorting-table .Update", function () {
    var row = $(this).closest("tr");


    $("#DETAIL_ID").val(row.find(".ID1").text());

    var ItemID = row.find(".ID1").text();

    $("#Material_id").select2("val", ItemID);
    
    $("#Material_Amount").val(row.find(".Amount").text().replace(/,/g, ""));
    $("#Material_AmountView").val(row.find(".Amount").text().replace(/,/g, ""));
    $("#Material_TotalPrice").val(row.find(".TotalPrice").text().replace(/,/g, ""));

    

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


