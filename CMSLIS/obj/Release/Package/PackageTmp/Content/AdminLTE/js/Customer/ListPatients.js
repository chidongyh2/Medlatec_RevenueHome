document.addEventListener("keydown", function (event) {
    if (event.keyCode == 112) {
        var url = document.getElementById("ListPatientsAdd").href;
        window.location.href =url;
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
   
    $('.select2').select2();
    $("#ListPatientsPrint").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
         
        if (selectedIDs == '') {
            $.alert({
                title: 'Thông báo!',
                content: 'Mời chọn bệnh nhân để in!',
            });   

            
        } else if (selectedIDs.length > 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chọn hơn một bệnh nhân!',
            });   
             
        } else {
            window.open("/Clinic/ListPatientsPrint?pid=" + selectedIDs, '_blank');
           
        }
    });

    $("#ListPatientsCreateOrder").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
        if (selectedIDs.length > 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chọn hơn một bệnh nhân!',
            });   
            
        } else {
            window.location = "/Clinic/ListPatientsCreateOrder?pid=" + selectedIDs;
        }
    });

    $("#ListPatientsView").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
        if (selectedIDs == '') {
            $.alert({
                title: 'Thông báo!',
                content: 'Mời chọn bệnh nhân để xem lịch sử!',
            }); 
            
        } else if (selectedIDs.length > 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chọn hơn một bệnh nhân!',
            }); 

            
        } else {
            window.location = "/Clinic/ListPatientsHistory?pid=" + selectedIDs;
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
                            url: "/Clinic/ListPatientDelete",
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
