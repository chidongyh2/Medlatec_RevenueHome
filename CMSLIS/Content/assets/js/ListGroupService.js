$(document).ready(function () {
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });



    var check = false;

    $(":button").click(function (event) {


        if ($(this).prop("id") == "SaveListGroupService") {
            check = true;
        }


    });

    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });

    $("#SERVICE_GROUP_CODE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_GROUP_NAME").focus();
        }
    });

    $("#SERVICE_GROUP_NAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_GROUP_DESC").focus();
        }
    });

    $("#SERVICE_GROUP_DESC").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveListGroupService").focus();
        }
    });
      
});


function ConfirmDelete() {
    var x = confirm("Bạn có chắc không?");
    if (x) {
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
            options.url = "/CatalogSystem/ListGroupServiceDelete";
            options.type = "POST";
            options.data = JSON.stringify(selectedIDs);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {
                alert(msg);
                location.reload();
            };
            options.error = function () {
                alert("Có lỗi trong quá trình xóa bản ghi");
            };
            $.ajax(options);
        }
        return true;
    }

    else
        return false;
}



function ConfirmPublic() {
    var x = confirm("Bạn có chắc không?");
    if (x) {
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
            options.url = "/CatalogSystem/ListGroupServicePublic";
            options.type = "POST";
            options.data = JSON.stringify(selectedIDs);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {
                alert(msg);
                location.reload();
            };
            options.error = function () {
                alert("Có lỗi trong quá trình xóa bản ghi");
            };
            $.ajax(options);
        }
        return true;
    }

    else
        return false;
}
