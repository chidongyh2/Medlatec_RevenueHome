var keyCodeOld; 


document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0; 
        document.getElementById('SaveMedicalAppointmentAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0; 
        var url = document.getElementById("BackMedicalAppointment").href;
        window.location.href = url;
    }

});


$(document).ready(function () {


    var check = false;

    $(":button").click(function (event) {

        if ($(this).prop("id") == "SaveMedicalAppointmentAdd") {
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



    $("#PATIENTINFO_ID").keydown(function () {
        var forgeryId = $("#forgeryToken").val();
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;

            $.ajax({
                type: "POST",
                url: "/Clinic/ListPatientsByPID?pid=" + $("#PATIENTINFO_ID").val(),
                data: JSON.stringify($("#PATIENTINFO_ID").val()),
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
                    $("#AGE").val(item.AGE);
                    $("#ADDRESS").val(item.ADDRESS);
                    $("#city").select2("val", item.CITY);
                    SelectedValueTinh_1(item.CITY, item.DISTRICT);

                   // $("#huyen").select2("val", item.DISTRICT);
                    $("#PARENTS_INFO").val(item.PARENTS_INFO);
                    $("#PHONE").val(item.PHONE);
                    $("#PHONE1").val(item.PHONE1);
                    $("#EMAILADDRESS").val(item.EMAILADDRESS);
                    $("#IDENTIFICATION").val(item.IDENTIFICATION);
                    $("#dateCMT").val(item.IDENTIFICATION_DATEVIEW);
                    $("#IDENTIFICATION_ISSUED").val(item.IDENTIFICATION_ISSUED);
                    $("#PASSPORT").val(item.PASSPORT);
                    $("#PASSPORT_ISSUED").val(item.PASSPORT_ISSUED);
                    $("#datePassport").val(item.PASSPORT_DATEVIEW);
                    $("#dateCMT").val(item.IDENTIFICATION_DATEVIEW);
                    $("#INSURANCE_CARD").val(item.INSURANCE_CARD);
                    $("#INSURANCE_CARD_PLACE").val(item.INSURANCE_CARD_PLACE);
                    $("#INSURANCE_CARD_START").val(item.INSURANCE_CARD_STARTVIEW);
                    $("#INSURANCE_CARD_END").val(item.INSURANCE_CARD_ENDVIEW);
                    $("#weight").val(item.weight);

                });

                $("#datetimepicker1").focus();

            }).fail(function (data) {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Có lỗi trong quá trình chọn thông tin bệnh nhân!',
                });


            });;


            //var options = {};
            //options.url = "/Clinic/ListPatientsByPID?pid=" + $("#PATIENT_CODE").val();
            //options.type = "POST";
            //options.data = JSON.stringify($("#PATIENT_CODE").val());
            //options.contentType = "application/json";
            //options.dataType = "json";
            //options.success = function (msg) {

            //    $.each(msg, function (index, item) {
            //        $("#PATIENTNAME").val(item.PATIENTNAME);
            //        $("#SEX").select2("val", item.SEX);
            //        $("#PATIENTNAME").val(item.PATIENTNAME);
            //        $("#RELATIONSHIP").val(item.RELATIONSHIP);
            //        $("#date").val(item.BIRTHDAYVIEW);
            //        $("#AGE").val(item.AGE);
            //        $("#ADDRESS").val(item.ADDRESS);
            //        $("#city").select2("val", item.CITY);
            //        $("#huyen").select2("val", item.DISTRICT);
            //        $("#PARENTS_INFO").val(item.PARENTS_INFO);
            //        $("#PHONE").val(item.PHONE);
            //        $("#PHONE1").val(item.PHONE1);
            //        $("#EMAILADDRESS").val(item.EMAILADDRESS);
            //        $("#IDENTIFICATION").val(item.IDENTIFICATION);
            //        $("#dateCMT").val(item.IDENTIFICATION_DATEVIEW);
            //        $("#IDENTIFICATION_ISSUED").val(item.IDENTIFICATION_ISSUED);
            //        $("#PASSPORT").val(item.PASSPORT);
            //        $("#PASSPORT_ISSUED").val(item.PASSPORT_ISSUED);
            //        $("#datePassport").val(item.PASSPORT_DATEVIEW);
            //        $("#dateCMT").val(item.IDENTIFICATION_DATEVIEW);
            //        $("#sothe").val(item.INSURANCE_CARD);
            //        $("#INSURANCE_CARD_PLACE").val(item.INSURANCE_CARD_PLACE);
            //        $("#INSURANCE_CARD_START").val(item.INSURANCE_CARD_STARTVIEW);
            //        $("#INSURANCE_CARD_END").val(item.INSURANCE_CARD_ENDVIEW);                    
            //    });

            //    $("#datetimepicker1").focus();
            //};
            //options.error = function () {
            //    alert("Có lỗi trong quá trình chọn thông tin bệnh nhân ");
            //};
            //$.ajax(options);
        }
    });





    $("#PATIENTNAME").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#SEX").focus();
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
            $("#AGE").focus();
        }
    });

    $("#AGE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#ADDRESS").focus();
        }
    });

    $("#ADDRESS").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#city").focus();
        }
    });

    $("#PARENTS_INFO").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PHONE").focus();
        }
    });

    $("#PHONE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PHONE1").focus();
        }
    });

    $("#PHONE1").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#EMAILADDRESS").focus();
        }
    });

    $("#EMAILADDRESS").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#IDENTIFICATION").focus();
        }
    });



    $("#IDENTIFICATION").keydown(function () {
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
            $("#IDENTIFICATION_ISSUED").focus();
        }
    });

    $("#IDENTIFICATION_ISSUED").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PASSPORT").focus();
        }
    });

    $("#PASSPORT").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#datePassport").focus();
        }
    });

    $("#datePassport").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#PASSPORT_ISSUED").focus();
        }
    });

    $("#PASSPORT_ISSUED").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#sothe").focus();
        }
    });

    $("#sothe").keydown(function () {
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

    $("#PARENTS_INFO").focus();
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
        url: "/Clinic/ListPatientsByPID?pid=" + $("#PATIENT_CODE").val(),
        data: JSON.stringify($("#PATIENT_CODE").val()),
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


    });;




    //var options = {};
    //options.url = "/Clinic/ListPatientsByTinh?IDTinh=" + selectedValue;
    //options.type = "POST";
    //options.data = JSON.stringify(selectedValue);
    //options.contentType = "application/json";
    //options.dataType = "json";
    //options.success = function (msg) {
    //    $("#huyen").html('');
    //    $("#huyen").get(0).options.length = 0;
    //    $("#huyen").get(0).options[0] = new Option("Chọn tỉnh", "0");
    //    $.each(msg, function (index, item) {
    //        $("#huyen").get(0).options[$("#huyen").get(0).options.length] = new Option(item.namefield, item.idfield);
    //    });

    //    $("#huyen").focus();
    //};
    //options.error = function () {
    //    $.alert({
    //        title: 'Thông báo!',
    //        content: 'Có lỗi trong quá trình chọn tỉnh!',
    //    });   

    //};
    //$.ajax(options);
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




