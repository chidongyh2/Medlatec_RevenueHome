document.addEventListener("keydown", function (event) {
    if (event.keyCode == 112) {
        var url = document.getElementById("partnerNew").href;
        window.location.href = url;
    }
});



(function ($) {
    'use strict';
    var datatableInit = function () {
        $('#sorting-table').dataTable(
            {
                "columnDefs": [{
                    "targets": 'no-sort',
                    "orderable": false,
                }]
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

});

function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    document.getElementById('cmdSearch').click();
}
 


function ConfirmDelete() {    

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
                            url: "/CatalogSystem/partnerDelete",
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
}



function ConfirmPublic() {

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
                            content: 'Mời chọn bản ghi để duyệt!',
                        });                      
                    } else {
                        $.ajax({
                            type: "POST",
                            url: "/CatalogSystem/partnerPublic",
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
                                    content: 'Có lỗi trong quá trình duyệt bản ghi',
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

}
