

var t_cel, tc_ln;
if (document.addEventListener) { //code for Moz
    document.addEventListener("keydown", keyCapt, false);
    document.addEventListener("keyup", keyCapt, false);
    document.addEventListener("keypress", keyCapt, false);
} else {
    document.attachEvent("onkeydown", keyCapt); //code for IE
    document.attachEvent("onkeyup", keyCapt);
    document.attachEvent("onkeypress", keyCapt);
}

function keyCapt(e) {
    if (typeof window.event != "undefined") {
        e = window.event; //code for IE
    }
    if (e.type == "keydown") {
        t_cel[0].innerHTML = e.keyCode;
        t_cel[3].innerHTML = e.charCode;
    } else if (e.type == "keyup") {
        t_cel[1].innerHTML = e.keyCode;
        t_cel[4].innerHTML = e.charCode;
    } else if (e.type == "keypress") {

        alert(e.keyCode);
        t_cel[2].innerHTML = e.keyCode;
        t_cel[5].innerHTML = e.charCode;
    }
}





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


    $("#PATIENTINFO_PATIENTNAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_SEX").focus();
        }
    });


    $("#date").keydown(function () {
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

    

    

});


function SelectedValueSEX(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#PATIENTINFO_RELATIONSHIP").focus();
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

    var options = {};
    options.url = "/Clinic/ListPatientsByTinh?IDTinh=" + selectedValue;
    options.type = "POST";
    options.data = JSON.stringify(selectedValue);
    options.contentType = "application/json";
    options.dataType = "json";
    options.success = function (msg) {
        $("#huyen").html('');
        $("#huyen").get(0).options.length = 0;
        $("#huyen").get(0).options[0] = new Option("Chọn tỉnh", "0");
        $.each(msg, function (index, item) {
            $("#huyen").get(0).options[$("#huyen").get(0).options.length] = new Option(item.namefield, item.idfield);
        });

        $("#huyen").focus();
    };
    options.error = function () {
        alert("Có lỗi trong quá trình chọn tỉnh");
    };
    $.ajax(options);
}


function SaveALLERGGY() {


    var CMS_PATIENT_ALLERGY = {};
    CMS_PATIENT_ALLERGY.ALLERGY_NAME = $('input[id="ALLERGY_NAME"]').val();
    CMS_PATIENT_ALLERGY.ALLERGY_TYPE = $("#ALLERGY_TYPE option:selected").val();
    CMS_PATIENT_ALLERGY.ALLERGY_NOTE = $('input[id="ALLERGY_NOTE"]').val();

    if ($('input[id="ALLERGY_NAME"]').val().length < 1) {
        alert("Bạn chưa chọn loại dị ứng");
    } else {
        var dataview = '';
        dataview += "<tr><td>" + $('input[id="ALLERGY_NAME"]').val() + "</td>";
        dataview += "<td>" + $("#ALLERGY_TYPE option:selected").text() + "</td>";
        dataview += "<td>" + $('input[id="ALLERGY_NOTE"]').val() + "</td>";
        dataview += "<td class='td-actions'><a href='javascript:;' id='Edit'><i class='la la-edit edit'></i></a> </td>";
        dataview += '</tr>';


        $.ajax({
            type: "POST",
            url: "/Clinic/SaveALLERGGY",
            data: '{ALLERGY_NAME:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NAME) + ',ALLERGY_TYPE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_TYPE) + ',ALLERGY_NOTE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NOTE) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (msg) {
            if (msg == '1') {
                $("#sorting-table-sick").append(dataview);
            }
            else if (msg == '2') {
                alert('Đã tồn tại dị ứng rồi! Mời bạn kiểm tra lại');
            } else {
                alert('Cập nhật không thành công');
            }
        });




    }





}



function SaveHISTORIE() {


    //var cms_ControlName = {};
    //cms_ControlName.menID = row.find(".menID").val();
    //cms_ControlName.id = row.find('input[name="id"]').val();
    //cms_ControlName.ControlID = row.find('input[name="ControlID"]').val();
    //cms_ControlName.ControlName = row.find('input[name="ControlName"]').val();
    //cms_ControlName.ControlDes = row.find('input[name="ControlDes"]').val();
    //cms_ControlName.ControlStatus = row.find('select[id="ControlStatus"]').val();
    //cms_ControlName.LangID = row.find('select[id="LangID"]').val();


    var CMS_PATIENT_HISTORY = {};
    CMS_PATIENT_HISTORY.SICKNAME = $("#SICKNAME option:selected").text();
    CMS_PATIENT_HISTORY.SICKYEAR = $('input[id="SICKYEAR"]').val();
    CMS_PATIENT_HISTORY.NOTE = $('input[id="HISTORIENOTE"]').val();


    var year = new Date().getFullYear()

    if ($("#SICKNAME option:selected").text().length < 1) {
        alert("Bạn chưa chọn tên bệnh");
    } else if (!$.isNumeric($('input[id="SICKYEAR"]').val())) {
        alert("Năm bị bệnh nhập sai kiểu");
    } else if ($('input[id="SICKYEAR"]').val() > year) {
        alert("Năm bị bệnh lớn hơn năm hiện tại");
    }
    else {
        var dataview = '';
        dataview += "<tr><td name='SICKNAMEValue'>" + $("#SICKNAME option:selected").text() + "</td>";
        dataview += "<td name='SICKYEARValue'>" + $('input[id="SICKYEAR"]').val() + "</td>";
        dataview += "<td name='HISTORIENOTEValue'>" + $('input[id="HISTORIENOTE"]').val() + "</td>";
        dataview += "<td class='td-actions'><a class='Update' href='javascript:;' id='Update'><i class='la la-edit edit'></i></a> </td>";
        dataview += '</tr>';

        $.ajax({
            type: "POST",
            url: "/Clinic/SaveHISTORIE",
            data: '{SICKNAME:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKNAME) + ',SICKYEAR:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKYEAR) + ',NOTE:' + JSON.stringify(CMS_PATIENT_HISTORY.NOTE) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (msg) {
            if (msg == '1') {
                $("#sorting-table-history").append(dataview);
            }
            else if (msg == '2') {
                alert('Đã tồn tại bệnh rồi! Mời bạn kiểm tra lại');
            } else {
                alert('Cập nhật không thành công');
            }
        });




    }



}




//Update event handler.
$("body").on("click", "#table_history .Update", function () {
    var row = $(this).closest("tr");
    alert(row.find('input[name="SICKNAMEValue"]').val());
    //cms_ControlName.menID = row.find(".menID").val();
    //cms_ControlName.id = row.find('input[name="id"]').val();
    //cms_ControlName.ControlID = row.find('input[name="ControlID"]').val();
    //cms_ControlName.ControlName = row.find('input[name="ControlName"]').val();
    //cms_ControlName.ControlDes = row.find('input[name="ControlDes"]').val();
    //cms_ControlName.ControlStatus = row.find('select[id="ControlStatus"]').val();
    //cms_ControlName.LangID = row.find('select[id="LangID"]').val();


    //location.reload();


});