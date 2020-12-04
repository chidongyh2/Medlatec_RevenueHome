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
    $("#ListPatientWaitingForMedicalPrint").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });

        if (selectedIDs == '') {
            $.alert({
                title: 'Thông báo!',
                content: 'Mời chọn phiếu khám để in!',
            });

            
        } else if (selectedIDs.length > 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chọn hơn một phiếm khám!',
            });

            
        } else {
            window.open("/Clinic/ListPatientPrint?sid=" + selectedIDs, '_blank');

        }
    });

    $("#medicalExamination").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });

        if (selectedIDs == '') {
            $.alert({
                title: 'Thông báo!',
                content: 'Mời chọn phiếu khám để in!',
            });

             
        } else if (selectedIDs.length > 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chọn hơn một phiếm khám!',
            });

            
        } else {
            window.open("/Clinic/medicalExamination?sid=" + selectedIDs );

        }
    });



    
 

    $("#ListPatientWaitingForMedicalView").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
        if (selectedIDs == '') {
            $.alert({
                title: 'Thông báo!',
                content: 'Mời chọn bệnh nhân để xem kết quả khám!',
            });

            
        } else if (selectedIDs.length > 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chọn hơn một phiếm khám!',
            });            
        } else {
            window.location = "/Clinic/ListPatientResult?sid=" + selectedIDs;
        }
    });


});





function SelectedValueDEPARTMENTSID(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#cmdSearch").click();
}
 