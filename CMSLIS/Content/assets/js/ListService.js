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

       
        if ($(this).prop("id") == "SaveListService") {
            check = true;
        }
        

    });

    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });

    $("#SERVICE_CODE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_NAME").focus();
        }
    });

    $("#SERVICE_NAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_NAME_ENG").focus();
        }
    });

    $("#SERVICE_NAME_ENG").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_UNIT").focus();
        }
    });

    $("#SERVICE_PRICE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_PRICE_INSURANCE").focus();
        }
    });

    $("#SERVICE_PRICE_INSURANCE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_RETURN_DATE").focus();
        }
    });

    $("#SERVICE_RETURN_DATE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_NOTE").focus();
        }
    });

    $("#SERVICE_NOTE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveListService").focus();
        }
    });

    //$("#ListServiceDelete").click(function () {
    //    var selectedIDs = new Array();
    //    $('input:checkBox.checkBox').each(function () {
    //        if ($(this).prop('checked')) {
    //            selectedIDs.push($(this).val());
    //        }
    //    });
    //    if (selectedIDs == '') {
    //        alert("Mời chọn bản ghi để xóa");
    //    } else {
    //        var options = {};
    //        options.url = "/CatalogSystem/ListServiceDelete";
    //        options.type = "POST";
    //        options.data = JSON.stringify(selectedIDs);
    //        options.contentType = "application/json";
    //        options.dataType = "json";
    //        options.success = function (msg) {
    //            alert(msg);
    //            window.location = "/CatalogSystem/ListService" ;                
    //        };
    //        options.error = function () {
    //            alert("Có lỗi trong quá trình xóa bản ghi");
    //        };
    //        $.ajax(options);
    //    }
    //});

    //$("#ListServicePublic").click(function () {
    //    var selectedIDs = new Array();
    //    $('input:checkBox.checkBox').each(function () {
    //        if ($(this).prop('checked')) {
    //            selectedIDs.push($(this).val());
    //        }
    //    });
    //    if (selectedIDs == '') {
    //        alert("Mời chọn bản ghi để xóa");
    //    } else {
    //        var options = {};
    //        options.url = "/CatalogSystem/ListServicePublic";
    //        options.type = "POST";
    //        options.data = JSON.stringify(selectedIDs);
    //        options.contentType = "application/json";
    //        options.dataType = "json";
    //        options.success = function (msg) {
    //            alert(msg);
    //            window.location = "/CatalogSystem/ListService";   
    //        };
    //        options.error = function () {
    //            alert("Có lỗi trong quá trình xóa bản ghi");
    //        };
    //        $.ajax(options);
    //    }
    //});

});



function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    $("#SERVICE_PRICE").focus();
}

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
            options.url = "/CatalogSystem/ListServiceDelete";
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
            options.url = "/CatalogSystem/ListServicePublic";
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

