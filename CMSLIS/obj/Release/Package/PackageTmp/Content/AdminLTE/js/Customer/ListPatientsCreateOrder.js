
var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 120) {
        var url = document.getElementById("PATIENT_PRESCRIPTIONS").href;
        window.open(url);
    }
  
    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        document.getElementById('BackListPatients').click();
        return false;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        document.getElementById('SaveListPatientsCreateOrder').click();
        return false;
    }

});




$(document).ready(function () {


    var check = false;

    $(":button").click(function (event) {

        if ($(this).prop("id") == "SaveListPatientsCreateOrder") {
            check = true;
        }


    });

    $('.select2').select2();

    $('#SPOTCASH').maskNumber({ integer: true });
    $('#PATIENT_MONEYPOS').maskNumber({ integer: true });
    $('#MONEYGIVE').maskNumber({ integer: true });
    $('#TotalPrice').maskNumber({ integer: true });
    $('#TotalPay').maskNumber({ integer: true });
    $('#MONEYREFUNDS').maskNumber({ integer: true });



    $('form').submit(function (e) {
        if (!check) {
            e.preventDefault();
            return false;
        }
    });

    $('#date').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    $('#dateCMT').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })


    $("#PATIENTNAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PATIENTINFO_SEX").focus();
        }
    });


    $("#weight").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#date").focus();
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
            $("#OBJECTID").focus();
        }
    });

    $("#REASON").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#GHICHU").focus();
        }
    });

    $("#GHICHU").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SERVICE_GROUPID").focus();
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



    $("#PATIENTINFO_PID").keydown(function () {
        var forgeryId = $("#forgeryToken").val();
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;

            $.ajax({
                type: "POST",
                url: "/Clinic/ListPatientsByPID?pid=" + $("#PATIENTINFO_PID").val(),
                data: JSON.stringify($("#PATIENTINFO_PID").val()),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                headers: {
                    'VerificationToken': forgeryId
                }
            }).done(function (msg) {
                $.each(msg, function (index, item) {
                    $("#PATIENTNAME").val(item.PATIENTNAME);
                    $("#SEX").select2("val", item.SEX);
                    $("#PATIENTNAME").val(item.PATIENTNAME);
                    $("#RELATIONSHIP").val(item.RELATIONSHIP);
                    $("#date").val(item.BIRTHDAYVIEW);
                    $("#PATIENTINFO_AGE").val(item.AGE);
                    $("#PATIENTINFO_ADDRESS").val(item.ADDRESS);
                    $("#PATIENTINFO_CITY").select2("val", item.CITY);
                    SelectedValueTinh_1(item.CITY, item.DISTRICT);
                   // $("#huyen").select2("val", item.DISTRICT);
                    $("#PATIENTINFO_PARENTS_INFO").val(item.PARENTS_INFO);
                    $("#PATIENTINFO_PHONE").val(item.PHONE);
                    $("#PHONE1").val(item.PHONE1);
                    $("#PATIENTINFO_EMAILADDRESS").val(item.EMAILADDRESS);
                    $("#PATIENTINFO_IDENTIFICATION").val(item.IDENTIFICATION);
                    $("#dateCMT").val(item.IDENTIFICATION_DATEVIEW);
                    $("#PATIENTINFO_IDENTIFICATION_ISSUED").val(item.IDENTIFICATION_ISSUED);
                    //$("#PASSPORT").val(item.PASSPORT);
                    //$("#PASSPORT_ISSUED").val(item.PASSPORT_ISSUED);
                    //$("#datePassport").val(item.PASSPORT_DATEVIEW);
                    //$("#dateCMT").val(item.IDENTIFICATION_DATEVIEW);
                    //$("#INSURANCE_CARD").val(item.INSURANCE_CARD);
                    //$("#INSURANCE_CARD_PLACE").val(item.INSURANCE_CARD_PLACE);
                    //$("#INSURANCE_CARD_START").val(item.INSURANCE_CARD_STARTVIEW);
                    //$("#INSURANCE_CARD_END").val(item.INSURANCE_CARD_ENDVIEW);
                    $("#weight").val(item.weight);

                });

                $("#OBJECTID").focus();

                }).fail(function (data) {

                    $.alert({
                        title: 'Thông báo!',
                        content: 'Có lỗi trong quá trình chọn thông tin bệnh nhân!',
                    });
                 
            });
             
        }
    });





    $("#MONEYGIVE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            var TotalPay1 = $('#TotalPay1').val();
            var MONEYGIVE = $('#MONEYGIVE').val();
            MONEYGIVE = MONEYGIVE.replace(/,/g, '');
            $("#MONEYREFUNDS").val(MONEYGIVE - TotalPay1);
            if (MONEYGIVE - TotalPay1 < 0) {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Số tiền khách đưa nhỏ hơn số tiền phải thanh toán!',
                });
            }
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


function SelectedValueOBJECTID(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#TYPECUSTOMERID").focus();
}

function SelectedValueTYPECUSTOMERID(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#DEPARTMENTSID").focus();
}

function SelectedValueDEPARTMENTSID(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#REASON").focus();
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



//To get selected value an text of dropdownlist
function SelectedValueTinh_1(selectedValue, DISTRICT) {
    //Selected value of dropdownlist    
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

        $("#huyen").select2("val", DISTRICT);


    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình chọn tỉnh!',
        });

    });


}




//To get selected value an text of dropdownlist
function SelectedValueKhoaKham(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    $.ajax({
        type: "POST",
        url: "/Clinic/ListPatientsByKhoaKham?KhoaKhamID=" + selectedValue,
        data: JSON.stringify(selectedValue),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#phong").html('');
        $("#phong").get(0).options.length = 0;
        $("#phong").get(0).options[0] = new Option("Chọn phòng khám", "0");
        $.each(msg, function (index, item) {
            $("#phong").get(0).options[$("#phong").get(0).options.length] = new Option(item.namefield, item.idfield);
        });

      

        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình chọn phòng khám!',
            });
        
    });

     


}


//To get selected value an text of dropdownlist
function SelectedValueChoGoi(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();


    $.ajax({
        type: "POST",
        url: "/Clinic/ListPatientsByGroupService?GroupID=" + selectedValue,
        data: JSON.stringify(selectedValue),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#sorting-table-body").html('');
        var dataview = '';
        var total = 0;
        $.each(msg, function (index, item) {
            dataview += "<tr><td>" + item.SERVICE_NAME + "</td>";
            
            dataview += "<td>" + item.SERVICE_CODE + "</td>";
            dataview += "<td>" + item.UnitName + "</td>";
            dataview += "<td class='text-right'>" + formatNumber(item.SERVICE_PRICE) + "</td>";
            //dataview += "<td class='text-right'>" + formatNumber(item.SERVICE_PRICE_INSURANCE) + "</td>";
            dataview += "<td>" + returnblank(item.VISIT_PATIENT_NAME) + "</td>";
            if (item.is_pay == 0) {
                dataview += "<td>Chưa thanh toán</td>";
                ////  Total over all pages
                total = intVal(item.SERVICE_GROUP_PRICE);
            } else {
                dataview += "<td>Đã thanh toán</td>";
            }
             
            dataview += '</tr>';

            ////  Total over all pages
           // total = total + intVal(item.SERVICE_PRICE);

        });


        $("#sorting-table-body").append(dataview);    
      
        $("#TotalPrice").val(formatNumber(total));
        $("#TotalPrice1").val(total);

        $("#TotalPay").val(formatNumber(total));
       // $("#TotalPay").val(total);
        $("#TotalPay1").val(total);

        $("#SPOTCASH").val(formatNumber(total));        
        $("#SPOTCASH1").val(total);

        $("#ddlUudai").select2("val", 0);
        // $("#SERVICEID").select2("val", );
        $(".SERVICEID").val();
               
        $("#SERVICEID").select2("val", '');

        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình chọn gói dịch vụ!',
            });
        
    });
     
}


function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}


//To get selected value an text of dropdownlist
function SelectedValueChoService(ddlObject) {

    var forgeryId = $("#forgeryToken").val();
    var PATIENT_SID = $("#PATIENT_SID").val();
    
    var selectedValues = $(ddlObject).val();
    if (selectedValues != null) {
        $("#SERVICE_GROUPID").select2("val", 0);
    }

    

    $.ajax({
        type: "POST",
        url: "/Clinic/ListPatientsByListServiceID?ListServiceID=" + selectedValues + "&sid=" + PATIENT_SID,
        data: '{ListServiceID:' + JSON.stringify(selectedValues) + ',sid:' + JSON.stringify(PATIENT_SID) + '}',
       // data: JSON.stringify(selectedValues),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        $("#sorting-table-body").html('');
        var dataview = '';
        var total = 0;
        $.each(msg, function (index, item) {
            dataview += "<tr><td>" + item.SERVICE_NAME + "</td>";
           
            dataview += "<td>" + item.SERVICE_CODE + "</td>";
            dataview += "<td>" + item.UnitName + "</td>";
            dataview += "<td class='text-right'>" + formatNumber(item.SERVICE_PRICE) + "</td>";
            
            dataview += "<td>" + returnblank(item.VISIT_PATIENT_NAME) + "</td>";
            if (item.is_pay == 0) {
                dataview += "<td>Chưa thanh toán</td>";
                ////  Total over all pages
                total = total + intVal(item.SERVICE_PRICE);
            } else {
                dataview += "<td>Đã thanh toán</td>";
            }
            
            dataview += '</tr>';

           

        });


        $("#sorting-table-body").append(dataview);

        $("#TotalPrice").val(formatNumber(total));
        //$("#TotalPrice").val(total);
        $("#TotalPrice1").val(total);
        $("#TotalPay").val(formatNumber(total));
        //$("#TotalPay").val(total);
        $("#TotalPay1").val(total);
        $("#SPOTCASH").val(formatNumber(total));  
        $("#SPOTCASH1").val(total);

        $("#ddlUudai").val("0").change();

        }).fail(function (data) {
            $.alert({
                title: 'Thông báo!',
                content: 'Có lỗi trong quá trình chọn gói dịch vụ!',
            });
        
    });
     
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
    var Total = $('#TotalPrice1').val();

    var TotalDiscount = intVal(selectedValue) * intVal(Total) / 100;
    $("#TotalDiscount").val(formatNumber(TotalDiscount));

   // $("#TotalDiscount").val(TotalDiscount);
    $("#TotalPay").val(formatNumber(Total - TotalDiscount));

    $("#TotalPay1").val(Total - TotalDiscount);
    $("#SPOTCASH").val(formatNumber(Total - TotalDiscount));      
    $("#SPOTCASH1").val(Total - TotalDiscount);   
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

   
    if ($("#SICKNAME option:selected").text().length <= 1) {
        $.alert({
            title: 'Thông báo!',
            content: 'Bạn chưa chọn tên bệnh!',
        });

        
    } else if ($("#SICKNAME option:selected").text() =='Tất cả') {
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
            url: "/Clinic/SaveHISTORIEExamination",
            data: '{SICKNAME:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKNAME) + ',SICKYEAR:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKYEAR) + ',NOTE:' + JSON.stringify(CMS_PATIENT_HISTORY.NOTE) + ',pid:' + JSON.stringify(CMS_PATIENT_HISTORY.PID) + ',id:' + JSON.stringify(CMS_PATIENT_HISTORY.ID) + '}',
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
                    content: 'Đã tồn tại bệnh rồi! Mời bạn kiểm tra lại!',
                });                     
            } else {
                var dataview = '';
                dataview += "<tr><td class='SICKNAME'>" + $("#SICKNAME option:selected").text() + "</td>";
                dataview += "<td class='SICKYEAR'>" + $('input[id="SICKYEAR"]').val() + "</td>";
                dataview += "<td class='HISTORIES_NOTE'>" + $('input[id="HISTORIENOTE"]').val() + "</td>";
                dataview += "<td style='display: none; ' class='HISTORIES_ID'>" + msg + "</td>";
                dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
                dataview += '</tr>';
                $("#sorting-table-history").append(dataview);

              console.log('sfsfd'); //Tất cả


                $("#SICKYEAR").val('');
                $("#HISTORIENOTE").val('');
                $("#SICKNAME").select2("val", "0");
            }
        });
    }
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
            url: "/Clinic/SaveALLERGGYExamination",
            data: '{ALLERGY_NAME:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NAME) + ',ALLERGY_TYPE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_TYPE) + ',ALLERGY_NOTE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NOTE) + ',pid:' + JSON.stringify(CMS_PATIENT_ALLERGY.PID) + ',id:' + JSON.stringify(CMS_PATIENT_ALLERGY.ID) + '}',
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
                dataview += "<td  style='display: none; ' class='ALLERGY_ID' >" + msg + "</td>";
                dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
                dataview += '</tr>';
                $("#sorting-table-sick").append(dataview);

                $("#ALLERGY_NAME").val('');
                $("#ALLERGY_NOTE").val('');
                $("#ALLERGY_TYPE").select2("val", "0");

                
            }
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
    $("#SICKYEAR").val(row.find(".SICKYEAR").text());

    $("#HISTORIENOTE").val(row.find(".HISTORIES_NOTE").text());

    var SICKNAME = row.find(".SICKNAME").text();

    $("#SICKNAME").select2("val", SICKNAME);
    $("#HISTORIE_ID").val(row.find(".HISTORIES_ID").text());

    row.remove();
});




//function SaveALLERGGY() {


//    var CMS_PATIENT_ALLERGY = {};
//    CMS_PATIENT_ALLERGY.ALLERGY_NAME = $('input[id="ALLERGY_NAME"]').val();
//    CMS_PATIENT_ALLERGY.ALLERGY_TYPE = $("#ALLERGY_TYPE option:selected").val();
//    CMS_PATIENT_ALLERGY.ALLERGY_NOTE = $('input[id="ALLERGY_NOTE"]').val();

//    if ($('input[id="ALLERGY_NAME"]').val().length < 1) {
//        alert("Bạn chưa chọn loại dị ứng");
//    } else {
//        var dataview = '';
//        dataview += "<tr><td>" + $('input[id="ALLERGY_NAME"]').val() + "</td>";
//        dataview += "<td>" + $("#ALLERGY_TYPE option:selected").text() + "</td>";
//        dataview += "<td>" + $('input[id="ALLERGY_NOTE"]').val() + "</td>";
//        dataview += "<td class='td-actions'><a href='javascript:;' id='Edit'><i class='la la-edit edit'></i></a> </td>";
//        dataview += '</tr>';


//        $.ajax({
//            type: "POST",
//            url: "/Clinic/SaveALLERGGY",
//            data: '{ALLERGY_NAME:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NAME) + ',ALLERGY_TYPE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_TYPE) + ',ALLERGY_NOTE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NOTE) + '}',
//            contentType: "application/json; charset=utf-8",
//            dataType: "json"
//        }).done(function (msg) {
//            if (msg == '1') {
//                $("#sorting-table-sick").append(dataview);
//            }
//            else if (msg == '2') {
//                alert('Đã tồn tại dị ứng rồi! Mời bạn kiểm tra lại');
//            } else {
//                alert('Cập nhật không thành công');
//            }
//        });




//    }





//}



//function SaveHISTORIE() {




//    var CMS_PATIENT_HISTORY = {};
//    CMS_PATIENT_HISTORY.SICKNAME = $("#SICKNAME option:selected").text();
//    CMS_PATIENT_HISTORY.SICKYEAR = $('input[id="SICKYEAR"]').val();
//    CMS_PATIENT_HISTORY.NOTE = $('input[id="HISTORIENOTE"]').val();


//    var year = new Date().getFullYear()

//    if ($("#SICKNAME option:selected").text().length < 1) {
//        alert("Bạn chưa chọn tên bệnh");
//    } else if (!$.isNumeric($('input[id="SICKYEAR"]').val())) {
//        alert("Năm bị bệnh nhập sai kiểu");
//    } else if ($('input[id="SICKYEAR"]').val() > year) {
//        alert("Năm bị bệnh lớn hơn năm hiện tại");
//    }
//    else {
//        var dataview = '';
//        dataview += "<tr><td name='SICKNAMEValue'>" + $("#SICKNAME option:selected").text() + "</td>";
//        dataview += "<td name='SICKYEARValue'>" + $('input[id="SICKYEAR"]').val() + "</td>";
//        dataview += "<td name='HISTORIENOTEValue'>" + $('input[id="HISTORIENOTE"]').val() + "</td>";
//        dataview += "<td class='td-actions'><a class='Update' href='javascript:;' id='Update'><i class='la la-edit edit'></i></a> </td>";
//        dataview += '</tr>';

//        $.ajax({
//            type: "POST",
//            url: "/Clinic/SaveHISTORIE",
//            data: '{SICKNAME:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKNAME) + ',SICKYEAR:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKYEAR) + ',NOTE:' + JSON.stringify(CMS_PATIENT_HISTORY.NOTE) + '}',
//            contentType: "application/json; charset=utf-8",
//            dataType: "json"
//        }).done(function (msg) {
//            if (msg == '1') {
//                $("#sorting-table-history").append(dataview);
//            }
//            else if (msg == '2') {
//                alert('Đã tồn tại bệnh rồi! Mời bạn kiểm tra lại');
//            } else {
//                alert('Cập nhật không thành công');
//            }
//        });




//    }



//}


