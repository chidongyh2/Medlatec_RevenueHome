var keyCodeOld; 

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        document.getElementById('SaveListPatientsAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        var url = document.getElementById("BackListPatients").href;
        window.location.href = url;
    }

});


$(document).ready(function () {


    var check = false;

    $(":button").click(function (event) {

        if ($(this).prop("id") == "SaveListPatientsAdd") {
            check = true;
        }
    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });

    $('.select2').select2();

    $("#PATIENTINFO_PATIENTNAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_SEX").focus();
        }
    });


    $('#date').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $('#dateCMT').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $('#datePassport').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $('#INSURANCE_CARD_START').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $('#INSURANCE_CARD_END').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })


   



    $("#date").keydown(function () {      
        //$("#date").mousemove(function (event) {
        //    alert('sdfsfd');
        //});
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_AGE").focus();
        }
    });

    $("#PATIENTINFO_AGE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_ADDRESS").focus();
        }
    });

    $("#weight").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#date").focus();
        }
    });



    $("#PATIENTINFO_ADDRESS").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#city").focus();
        }
    });

    $("#PATIENTINFO_PARENTS_INFO").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_PHONE").focus();
        }
    });

    $("#PATIENTINFO_PHONE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_EMAILADDRESS").focus();
        }
    });

    $("#PATIENTINFO_EMAILADDRESS").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_IDENTIFICATION").focus();
        }
    });

    $("#PATIENTINFO_IDENTIFICATION").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#dateCMT").focus();
        }
    });

    $("#dateCMT").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_IDENTIFICATION_ISSUED").focus();
        }
    });

    $("#PATIENTINFO_IDENTIFICATION_ISSUED").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_REASON").focus();
        }
    });


    $("#SICKYEAR").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#HISTORIENOTE").focus();
        }
    });

    $("#HISTORIENOTE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveHISTORIEID").focus();
        }
    });





    $("#ALLERGY_NAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#ALLERGY_TYPE").focus();
        }
    });

    $("#ALLERGY_NOTE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveALLERGGYID").focus();
        }
    });


    $("#INSURANCE_CARD").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#INSURANCE_CARD_PLACE").focus();
        }
    });

    $("#INSURANCE_CARD_PLACE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#INSURANCE_CARD_START").focus();
        }
    });

    $("#INSURANCE_CARD_START").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#INSURANCE_CARD_END").focus();
        }
    });

    $("#INSURANCE_CARD_END").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SaveListPatientsAdd").focus();
        }
    });

});


function SelectedValueSEX(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#weight").focus();
}


function SelectedValueRELATIONSHIP(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#date").focus();
}



function SelectedValuehuyen(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#PATIENTINFO_PARENTS_INFO").focus();
}

function SelectedValueSICKNAME(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#SICKYEAR").focus();
}

function SelectedValueALLERGY_TYPE(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#ALLERGY_NOTE").focus();
}




//To get selected value an text of dropdownlist
function SelectedValueTinh(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();


    $.ajax({
        type: "POST",
        url: "/Clinic/ListPatientsByTinh?IDTinh=" + selectedValue,
        data: JSON.stringify(selectedValue),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#huyen").html('');
        $("#huyen").get(0).options.length = 0;
        $("#huyen").get(0).options[0] = new Option("Chọn tỉnh", "0");
        $.each(msg, function (index, item) {
            $("#huyen").get(0).options[$("#huyen").get(0).options.length] = new Option(item.namefield, item.idfield);
        });

        $("#huyen").focus();

    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình chọn tỉnh!',
        });


    });


}


function SaveALLERGGY() {

    var forgeryId = $("#forgeryToken").val();
    var CMS_PATIENT_ALLERGY = {};
    CMS_PATIENT_ALLERGY.ALLERGY_NAME = $('input[id="ALLERGY_NAME"]').val();
    CMS_PATIENT_ALLERGY.ALLERGY_TYPE = $("#ALLERGY_TYPE option:selected").val();
    CMS_PATIENT_ALLERGY.ALLERGY_NOTE = $('input[id="ALLERGY_NOTE"]').val();
    CMS_PATIENT_ALLERGY.PID = $('input[id="PATIENTINFO_PID"]').val();
    CMS_PATIENT_ALLERGY.ID = $('input[id="ALLERGGY_ID"]').val();


    if ($('input[id="ALLERGY_NAME"]').val().length < 1) {
        $.alert({
            title: 'Thông báo!',
            content: 'Bạn chưa chọn loại dị ứng!',
        });


    } else {
        $.ajax({
            type: "POST",
            url: "/Clinic/SaveALLERGGY",
            data: '{ALLERGY_NAME:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NAME) + ',ALLERGY_TYPE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_TYPE) + ',ALLERGY_NOTE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NOTE) + ',id:' + JSON.stringify(CMS_PATIENT_ALLERGY.ID) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            if (msg == '0') {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Cập nhật không thành công!',
                });
            }
            else if (msg == '2') {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Đã tồn tại dị ứng rồi! Mời bạn kiểm tra lại!',
                });

            } else {
                var dataview = '';
                dataview += "<tr><td class='ALLERGY_NAME' >" + $('input[id="ALLERGY_NAME"]').val() + "</td>";
                dataview += "<td class='ALLERGY_TYPE_NAME' >" + $("#ALLERGY_TYPE option:selected").text() + "</td>";
                dataview += "<td  style='display: none; ' class='ALLERGY_TYPE' >" + $("#ALLERGY_TYPE option:selected").val() + "</td>";
                dataview += "<td class='ALLERGY_NOTE' >" + $('input[id="ALLERGY_NOTE"]').val() + "</td>";
                dataview += "<td  style='display: none; ' class='ALLERGGY_ID' >" + CMS_PATIENT_ALLERGY.ID + "</td>";
                dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
                dataview += '</tr>';
                $("#sorting-table-sick").append(dataview);

                $("#ALLERGY_NAME").val('');
                $("#ALLERGY_NOTE").val('');
                $("#ALLERGY_TYPE").select2("val", "0");
            }
        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Cập nhật không thành công!',
            });

        });
    }

}



function SaveHISTORIE() {

    var forgeryId = $("#forgeryToken").val();

    var CMS_PATIENT_HISTORY = {};
    CMS_PATIENT_HISTORY.SICKNAME = $("#SICKNAME option:selected").text();
    CMS_PATIENT_HISTORY.SICKYEAR = $('input[id="SICKYEAR"]').val();
    CMS_PATIENT_HISTORY.NOTE = $('input[id="HISTORIENOTE"]').val();
    CMS_PATIENT_HISTORY.PID = $('input[id="PATIENTINFO_PID"]').val();
    CMS_PATIENT_HISTORY.ID = $('input[id="HISTORIE_ID"]').val();

    var year = new Date().getFullYear()

    if ($("#SICKNAME option:selected").text().length < 1) {
        $.alert({
            title: 'Thông báo!',
            content: 'Bạn chưa chọn tên bệnh!',
        });

    } else if (!$.isNumeric($('input[id="SICKYEAR"]').val())) {
        $.alert({
            title: 'Thông báo!',
            content: 'Năm bị bệnh nhập sai kiểu!',
        });
    } else if ($('input[id="SICKYEAR"]').val() > year) {
        $.alert({
            title: 'Thông báo!',
            content: 'Năm bị bệnh lớn hơn năm hiện tại!',
        });
    } else if ($('input[id="SICKYEAR"]').val() < 1800) {
        $.alert({
            title: 'Thông báo!',
            content: 'Năm bị bệnh nhỏ hơn năm 1800!',
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Clinic/SaveHISTORIE",
            data: '{SICKNAME:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKNAME) + ',SICKYEAR:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKYEAR) + ',NOTE:' + JSON.stringify(CMS_PATIENT_HISTORY.NOTE) + ',id:' + JSON.stringify(CMS_PATIENT_HISTORY.ID) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            if (msg == '1') {
                var dataview = '';
                dataview += "<tr><td class='SICKNAME'>" + $("#SICKNAME option:selected").text() + "</td>";
                dataview += "<td class='SICKYEAR'>" + $('input[id="SICKYEAR"]').val() + "</td>";
                dataview += "<td class='HISTORIES_NOTE'>" + $('input[id="HISTORIENOTE"]').val() + "</td>";
                dataview += "<td style='display: none; ' class='HISTORIES_ID'>" + CMS_PATIENT_HISTORY.ID + "</td>";
                dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
                dataview += '</tr>';
                $("#sorting-table-history").append(dataview);
                $("#SICKYEAR").val('');
                $("#HISTORIENOTE").val('');
                $("#SICKNAME").select2("val", "0");
            }
            else if (msg == '2') {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Đã tồn tại bệnh rồi! Mời bạn kiểm tra lại!',
                });
            } else {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Cập nhật không thành công!',
                });
            }
        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Cập nhật không thành công!',
            });
        });




    }



}



//Update event handler.
$("body").on("click", "#table-sick .Update", function () {
    var row = $(this).closest("tr");
    $("#ALLERGY_NAME").val(row.find(".ALLERGY_NAME").text());

    $("#ALLERGY_NOTE").val(row.find(".ALLERGY_NOTE").text());

    var ALLERGY_TYPE = row.find(".ALLERGY_TYPE").text();

    $("#ALLERGY_TYPE").select2("val", ALLERGY_TYPE);
    $("#ALLERGGY_ID").val(row.find(".ALLERGY_ID").text());

    row.remove();
});


//Update event handler.
$("body").on("click", "#table_history .Update", function () {
    var row = $(this).closest("tr");
    $("#HISTORIENOTE").val(row.find(".HISTORIES_NOTE").text());
    $("#SICKYEAR").val(row.find(".SICKYEAR").text());
    var SICKNAME = row.find(".SICKNAME").text();

    $("#SICKNAME").select2("val", SICKNAME);
    $("#HISTORIE_ID").val(row.find(".HISTORIES_ID").text());

    row.remove();
});
