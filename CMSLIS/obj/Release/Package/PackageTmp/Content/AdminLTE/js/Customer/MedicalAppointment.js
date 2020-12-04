//(function ($) {
//    'use strict';
//    var datatableInit = function () {
//        $('#sorting-table').dataTable(
//            {
//                "columnDefs": [{
//                    "targets": 'no-sort',
//                    "orderable": false,
//                }]
//            }
//        );
//    };
//    $(function () {
//        datatableInit();
//    });

//}).apply(this, [jQuery]);


$(document).ready(function () {
   
    $('.select2').select2();
 

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
            var selectedID = selectedIDs[0];
            var res = selectedID.substring(selectedID.indexOf(",") + 1, selectedID.length);
            if (res.length > 0) {
                window.location = "/Clinic/ListPatientsCreateOrder?pid=" + res;
            } else {
                window.location = "/Clinic/ListPatientsCreateOrder?mid=" + selectedID.substring(0, selectedID.length-1);
            }
            
        }
    });
 


});

