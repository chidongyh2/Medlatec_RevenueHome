$(document).ready(function () {
    //$('#checkBoxAll').click(function () {
    //    if ($(this).is(":checked")) {
    //        $(".chkCheckBoxId").prop("checked", true)
    //    }
    //    else {
    //        $(".chkCheckBoxId").prop("checked", false)
    //    }
    //});

    $("#ListPatientsPrint").click(function () {
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
         
        if (selectedIDs == '') {
            alert("Mời chọn bệnh nhân để in");
        } else if (selectedIDs.length > 1) {
            alert("Bạn chọn hơn một bệnh nhân");
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
            alert("Bạn chọn hơn một bệnh nhân");
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
            alert("Mời chọn bệnh nhân để xem lịch sử");
        } else if (selectedIDs.length > 1) {
            alert("Bạn chọn hơn một bệnh nhân");
        } else {
            window.location = "/Clinic/ListPatientsHistory?pid=" + selectedIDs;
        }
    });


});


