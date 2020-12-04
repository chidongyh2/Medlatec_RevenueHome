$(document).ready(function () {


    var check = false;

    $(":button").click(function (event) {

        if ($(this).prop("id") == "SaveListPatientsCreateOrder") {
            check = true;
        }


    });


    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });


    $("#PATIENTNAME").keydown(function () {
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
            $("#PATIENTINFO.IDENTIFICATION_ISSUED").focus();
        }
    });

    $("#PATIENTINFO.IDENTIFICATION_ISSUED").keydown(function () {
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



//To get selected value an text of dropdownlist
function SelectedValueKhoaKham(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    var options = {};
    options.url = "/Clinic/ListPatientsByKhoaKham?KhoaKhamID=" + selectedValue;
    options.type = "POST";
    options.data = JSON.stringify(selectedValue);
    options.contentType = "application/json";
    options.dataType = "json";
    options.success = function (msg) {
        $("#phong").html('');
        $("#phong").get(0).options.length = 0;
        $("#phong").get(0).options[0] = new Option("Chọn phòng khám", "0");
        $.each(msg, function (index, item) {
            $("#phong").get(0).options[$("#phong").get(0).options.length] = new Option(item.namefield, item.idfield);
        });

        // $("#AccountType").focus();
    };
    options.error = function () {
        alert("Có lỗi trong quá trình chọn phòng khám");
    };
    $.ajax(options);



}


//To get selected value an text of dropdownlist
function SelectedValueChoGoi(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    var options = {};
    options.url = "/Clinic/ListPatientsByGroupService?GroupID=" + selectedValue;
    options.type = "POST";
    options.data = JSON.stringify(selectedValue);
    options.contentType = "application/json";
    options.dataType = "json";
    options.success = function (msg) {
        $("#sorting-table-body").html('');
        var dataview = '';
        var total = 0;
        $.each(msg, function (index, item) {
            dataview += "<tr><td>" + item.SERVICE_NAME + "</td>";
            dataview += "<td>" + returnblank(item.SERVICE_NAME_ENG) + "</td>";
            dataview += "<td>" + item.SERVICE_CODE + "</td>";
            dataview += "<td>" + item.UnitName + "</td>";
            dataview += "<td>" + formatNumber(item.SERVICE_PRICE) + "</td>";
            dataview += "<td>" + formatNumber(item.SERVICE_PRICE_INSURANCE) + "</td>";
            dataview += "<td>" + returnblank(item.SERVICE_RETURN_DATE) + "</td>";
            dataview += '</tr>';

            ////  Total over all pages
            total = total + intVal(item.SERVICE_PRICE);

        });


        $("#sorting-table-body").append(dataview);
        $("#TotalPrice").val(total);
        $("#ddlUudai").val("0").change();



    };
    options.error = function () {
        alert("Có lỗi trong quá trình chọn gói dịch vụ");
    };
    $.ajax(options);
}


function returnblank(item) {
    if (item == null) {
        return "";
    } else {
        return item;
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


function showPopupService(SID) {
    var PatientName = $('#PATIENTNAME').val();
    window.open("/Clinic/ListPatientsByService?SID=" + SID + "&PatientName=" + PatientName, "DialogName", "height=750,width=1000,modal=yes,alwaysRaised=yes");
}




//To get selected value an text of dropdownlist
function SelectedValueUudai(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var Total = $('#TotalPrice').val();

    var TotalDiscount = intVal(selectedValue) * intVal(Total) / 100;
    $("#TotalDiscount").val(TotalDiscount);
    $('#TotalDiscount').maskNumber();
    $("#TotalPay").val(Total - TotalDiscount);
    $("#SPOTCASH").val(Total - TotalDiscount);

}


$(document).ready(function () {

    //$("#MONEYGIVE").keypress(function () {
    //    var SPOTCASH = $('#SPOTCASH').val();
    //    var MONEYGIVE = $('#MONEYGIVE').val();

    //    $("#MONEYREFUNDS").val(MONEYGIVE - SPOTCASH);
    //});


    $("#MONEYGIVE").click(function () {
        var SPOTCASH = $('#SPOTCASH').val();
        var MONEYGIVE = $('#MONEYGIVE').val();

        $("#MONEYREFUNDS").val(MONEYGIVE - SPOTCASH);
    });
});