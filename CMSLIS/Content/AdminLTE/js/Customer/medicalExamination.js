var keyCodeOld; 
document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 120 && keyCodeOld == 18) {      
        keyCodeOld = 0;  
        var url = document.getElementById("PATIENT_PRESCRIPTIONS").href;      
        window.open(url);

    }

    if (event.keyCode == 117 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        var url = document.getElementById("PATIENT_RESULT").href;
        window.open(url);

    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        document.getElementById('SavemedicalExamination').click();
        return false;
    }

});



function CheckBoxIdImage(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    if (!ddlObject.checked) {
        if ($("#ListImageDelete").val().length > 0) {
            $("#ListImageDelete").val($("#ListImageDelete").val() + "," + selectedValue);
        } else {
            $("#ListImageDelete").val(selectedValue);
        }
        
    } else {
        $("#ListImageDelete").val($("#ListImageDelete").val().replace("," + selectedValue, ''));
        $("#ListImageDelete").val($("#ListImageDelete").val().replace(selectedValue, ''));
    }
   
    
  
}

 

$(document).ready(function () {

    //$('#checkBoxAll').click(function () {
    //    if ($(this).is(":checked")) {
    //        $(".chkCheckBoxId").prop("checked", true)
    //    }
    //    else {
    //        $(".chkCheckBoxId").prop("checked", false)
    //    }
    //});

  
    var check = false;

    $(":button").click(function (event) {

        if ($(this).prop("id") == "SaveMedicalAppointmentAdd") {
            check = true;
            
        }
        if ($(this).prop("id") == "SavemedicalExamination") {
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





    $("#PATIENT_CODE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            var options = {};
            options.url = "/Clinic/ListPatientsByPID?pid=" + $("#PATIENT_CODE").val();
            options.type = "POST";
            options.data = JSON.stringify($("#PATIENT_CODE").val());
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {

                $.each(msg, function (index, item) {
                    $("#PATIENTNAME").val(item.PATIENTNAME);
                    $("#SEX").select2("val", item.SEX);
                    $("#PATIENTNAME").val(item.PATIENTNAME);
                    $("#RELATIONSHIP").val(item.RELATIONSHIP);
                    $("#date").val(item.BIRTHDAYVIEW);
                    $("#AGE").val(item.AGE);
                    $("#ADDRESS").val(item.ADDRESS);
                    $("#city").select2("val", item.CITY);
                    $("#huyen").select2("val", item.DISTRICT);
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
                    $("#sothe").val(item.INSURANCE_CARD);
                    $("#INSURANCE_CARD_PLACE").val(item.INSURANCE_CARD_PLACE);
                    $("#INSURANCE_CARD_START").val(item.INSURANCE_CARD_STARTVIEW);
                    $("#INSURANCE_CARD_END").val(item.INSURANCE_CARD_ENDVIEW);
                });

                $("#datetimepicker1").focus();
            };
            options.error = function () {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Có lỗi trong quá trình chọn thông tin bệnh nhân!',
                });

                 
            };
            $.ajax(options);
        }
    });



    $("#SICKYEAR").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#HISTORIENOTE").focus();
        }
    });

    $("#MEDICINE_AMOUNT").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#MEDICINE_USAGE").focus();
        }
    });

    $("#MEDICINE_USAGE").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#CHUANDOAN").focus();
        }
    });
     
    $("#CHUANDOAN").keydown(function () {
        var key_enter = 13; // 13 = Enter
        if (key_enter == event.keyCode) {
            event.keyCode = 0;
            $("#GHICHU").focus();
        }
    });

    //$("#GHICHU").keydown(function () {
    //    var key_enter = 13; // 13 = Enter
    //    if (key_enter == event.keyCode) {
    //        event.keyCode = 0;
    //        $("#TAIKHAM_VIEW").focus();
    //    }
    //});
    imagePreview();
});






function SelectedValueSICKNAME(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    $("#SICKYEAR").focus();
}



//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    if (selectedValue != 0) {

        $.ajax({
            type: "POST",
            url: "/pharmacyStore/GetInfoMedicine?ID=" + selectedValue,
            data: JSON.stringify(selectedValue),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            $("#MEDICINE_AMOUNT").focus();
            $.each(msg, function (index, item) {

                if (msg != '') {
                    $("#MEDICINE_ID1").val(item.ID);
                    $("#MEDICINE_CODE").val(item.ID);
                    $("#MEDICINE_CODE1").val(item.ID);
                    $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
                    $("#MEDICINE_UNIT").val(item.MEDICINE_UNIT);
                    $("#MEDICINE_UNIT_NAME").val(item.MEDICINE_UNIT_NAME);
                    $("#MEDICINE_USAGE").val(item.MEDICINE_USAGE);
                    $("#MEDICINE_USAGE").val(item.MEDICINE_USAGE);
                } else {
                    $("#MEDICINE_ID1").val(0);
                    $("#MEDICINE_CODE").val();
                    $("#MEDICINE_CODE1").val();
                    $("#MEDICINE_NAME").val();
                    $("#MEDICINE_UNIT").val(0);
                    $("#MEDICINE_UNIT_NAME").val();
                    $("#MEDICINE_USAGE").val();
                }
            });

        });
    } else {
        $("#MEDICINE_CODE").val("");
    }

}

//To get selected value an text of dropdownlist
function SelectedValueTemplate(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    var forgeryId = $("#forgeryToken").val();
    if (selectedValue != 0) {

        $.ajax({
            type: "POST",
            url: "/Clinic/GetInfoTemplate?idTemplate=" + selectedValue,
            data: JSON.stringify(selectedValue),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
           
            $.each(msg, function (index, item) {

                if (msg != '') {
                    CKEDITOR.instances.CMS_PATIENT_SERVICE_RESULTS_INPUT_EXAMINATION_CONTENT.setData(item.TEMPLATE);
                    CKEDITOR.instances.CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_RESULT.setData(item.RESULT);
                    
                } 
            });

        });
    }  

}





function SavePATIENT_PRESCRIPTION() {

    var forgeryId = $("#forgeryToken").val();
    var CMS_PATIENT_PRESCRIPTION = {};
    CMS_PATIENT_PRESCRIPTION.MEDICINE_NAME = $('input[id="MEDICINE_NAME"]').val();
    CMS_PATIENT_PRESCRIPTION.MEDICINE_ID = $("#MEDICINE_ID option:selected").val();
    CMS_PATIENT_PRESCRIPTION.MEDICINE_UNIT = $('input[id="MEDICINE_UNIT"]').val();  
    CMS_PATIENT_PRESCRIPTION.COUNT = $('input[id="MEDICINE_AMOUNT"]').val();
    CMS_PATIENT_PRESCRIPTION.SID = $('input[id="SID"]').val();
    CMS_PATIENT_PRESCRIPTION.PID = $('input[id="PID"]').val();
    CMS_PATIENT_PRESCRIPTION.ID = $('input[id="PATIENT_PRESCRIPTION_ID"]').val();
    CMS_PATIENT_PRESCRIPTION.MEDICINE_USAGE = $('input[id="MEDICINE_USAGE"]').val();  
    CMS_PATIENT_PRESCRIPTION.CHUANDOAN = $('input[id="CHUANDOAN"]').val();  
    CMS_PATIENT_PRESCRIPTION.TAIKHAM_VIEW = $('input[id="TAIKHAM_VIEW"]').val();  
    CMS_PATIENT_PRESCRIPTION.GHICHU = $('#GHICHU').val();;// $('input[id="GHICHU"]').val();  

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;

    if ($("#MEDICINE_ID option:selected").val() == 0) {
        $.alert({
            title: 'Thông báo!',
            content: 'Mời bạn nhập thuốc!',
        });

         
    } else if ($('input[id="MEDICINE_AMOUNT"]').val().length < 1) {
        $.alert({
            title: 'Thông báo!',
            content: 'Mời bạn số lượng thuốc!',
        });
        
    } else {     
        $.ajax({
            type: "POST",
            url: "/Clinic/SavePATIENT_PRESCRIPTION",
            data: '{MEDICINE_NAME:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.MEDICINE_NAME) + ',MEDICINE_ID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.MEDICINE_ID) + ',MEDICINE_AMOUNT:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.COUNT) + ',MEDICINE_USAGE:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.MEDICINE_USAGE) + ',CHUANDOAN:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.CHUANDOAN) + ',TAIKHAM_VIEW:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.TAIKHAM_VIEW) + ',GHICHU:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.GHICHU)  + ',SID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.SID) + ',PID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.PID) + ',id:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.ID) + '}',
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
                    content: 'Đã tồn tại thuốc rồi! Mời bạn kiểm tra lại!',
                });

                
            } else if (msg == '1') {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Ngày tái khám phải lớn hơn 1 ngày so với hiện tại!',
                });


            }else {
                var dataview = '';
                dataview += "<tr>  <td><input type='checkbox' name='ID' value='" + $("#MEDICINE_ID option:selected").val() + "' class='checkBox custom - checkbox chkCheckBoxId' /></td> <td>" + today + "</td>";
                dataview += "<td>" + $('input[id="UserName"]').val() + "</td>";
                dataview += "<td class='MEDICINE_NAME' >" + $('input[id="MEDICINE_NAME"]').val() + "</td>";
                dataview += "<td class='MEDICINE_UNIT_NAME'>" + $('input[id="MEDICINE_UNIT_NAME"]').val() + "</td>";
                dataview += "<td class='COUNT'>" + $('input[id="MEDICINE_AMOUNT"]').val() + "</td>";
                dataview += "<td class='MEDICINE_USAGE'>" + $('input[id="MEDICINE_USAGE"]').val() + "</td>";
                dataview += "<td class='MEDICINE_ID' style='display: none;' >" + $("#MEDICINE_ID option:selected").val() + "</td>";
                dataview += "<td class='CMS_PATIENT_PRESCRIPTIONS_ID' style='display: none;' >" + msg + "</td>";
                dataview += "<td class='MEDICINE_UNIT' style='display: none;' >" + $('input[id="MEDICINE_UNIT"]').val() + "</td>";
                
                dataview += "<td><a class='Update' href='javascript: ; '><i class='fa fa-edit edit'></i></a></td>";
                dataview += '</tr>';

                $("#sorting-table-PATIENT_PRESCRIPTION").append(dataview);


                $("#MEDICINE_CODE").val('');
                $("#MEDICINE_CODE1").val(0);
                $("#MEDICINE_AMOUNT").val('');
                $("#MEDICINE_ID1").select2("val", "0");
                $("#MEDICINE_UNIT_NAME").val('');
                $("#MEDICINE_UNIT").val(0);

            }
        });




    }
}


function remR() {
    var allRows = document.getElementById('table_history_PATIENT_PRESCRIPTION').getElementsByTagName('tr');
    var root = allRows[0].parentNode;
    var allInp = root.getElementsByTagName('input');
    for (var i = allInp.length - 1; i >= 0; i--) {
        if ((allInp[i].getAttribute('type') == 'checkbox') && (allInp[i].checked)) {
            alert('sdfsfd');
            root.removeChild(allInp[i].parentNode.parentNode)
        }
    }
}


function deleteRows() {

    isTable = document.getElementById('table_history_PATIENT_PRESCRIPTION');
    nBoxes = document.getElementsByName('ID');
    for (i = nBoxes.length - 1; i >= 0; i--) {
        if (nBoxes[i].checked == true) {          
            isTable.deleteRow(i + 1)
        }
    }
}	



function DeletePATIENT_PRESCRIPTION() {

    var forgeryId = $("#forgeryToken").val();
    var CMS_PATIENT_PRESCRIPTION = {};
    CMS_PATIENT_PRESCRIPTION.MEDICINE_NAME = $('input[id="MEDICINE_NAME"]').val();
    CMS_PATIENT_PRESCRIPTION.MEDICINE_ID = $("#MEDICINE_ID option:selected").val();
    CMS_PATIENT_PRESCRIPTION.COUNT = $('input[id="MEDICINE_AMOUNT"]').val();
    CMS_PATIENT_PRESCRIPTION.SID = $('input[id="SID"]').val();
    CMS_PATIENT_PRESCRIPTION.PID = $('input[id="PID"]').val();
    CMS_PATIENT_PRESCRIPTION.ID = $('input[id="ID"]').val();

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
                            url: "/Clinic/DeletePATIENT_PRESCRIPTION",
                            data: '{customerIDs:' + JSON.stringify(selectedIDs) + ',SID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.SID) + ',PID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.PID) +  '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            headers: {
                                'VerificationToken': forgeryId
                            }
                        }).done(function (msg) {
                            if (msg == '1') {
                                $.alert({
                                    title: 'Thông báo!',
                                    content: 'Xóa thành công bản ghi!',
                                });

                                deleteRows();
                            }
                             else {
                                $.alert({
                                    title: 'Thông báo!',
                                    content: 'Xóa không thành công!',
                                });

                                
                            }
                            }).fail(function (data) {
                                $.alert({
                                    title: 'Thông báo!',
                                    content: 'Có lỗi trong quá trình xóa bản ghi!',
                                });
                            });

                        //$.ajax({
                        //    type: "POST",
                        //    url: "/CatalogSystem/ListSickDelete",
                        //    data: JSON.stringify(selectedIDs),
                        //    contentType: "application/json; charset=utf-8",
                        //    dataType: "json",
                        //    headers: {
                        //        'VerificationToken': forgeryId
                        //    }
                        //}).done(function (msg) {

                        //    //$.alert({
                        //    //    title: 'Thông báo!',
                        //    //    content: msg,
                        //    //});
                        //    location.reload();
                        //}).fail(function (data) {
                        //    $.alert({
                        //        title: 'Thông báo!',
                        //        content: 'Có lỗi trong quá trình xóa bản ghi!',
                        //    });
                        //});
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


    //var forgeryId = $("#forgeryToken").val();
    //var CMS_PATIENT_PRESCRIPTION = {};
    //CMS_PATIENT_PRESCRIPTION.MEDICINE_NAME = $('input[id="MEDICINE_NAME"]').val();
    //CMS_PATIENT_PRESCRIPTION.MEDICINE_ID = $("#MEDICINE_ID option:selected").val();
    //CMS_PATIENT_PRESCRIPTION.COUNT = $('input[id="MEDICINE_AMOUNT"]').val();
    //CMS_PATIENT_PRESCRIPTION.SID = $('input[id="SID"]').val();
    //CMS_PATIENT_PRESCRIPTION.PID = $('input[id="PID"]').val();
    //CMS_PATIENT_PRESCRIPTION.ID = $('input[id="ID"]').val();

    //var x = confirm("Bạn có chắc không?");
    //if (x) {
    //    var selectedIDs = new Array();
    //    $('input:checkBox.checkBox').each(function () {
    //        if ($(this).prop('checked')) {
    //            selectedIDs.push($(this).val());
    //        }
    //    });
    //    if (selectedIDs == '') {
    //        alert("Mời chọn bản ghi để duyệt");
    //    } else {


    //        $.ajax({
    //            type: "POST",
    //            url: "/Clinic/DeletePATIENT_PRESCRIPTION",
    //            data: '{customerIDs:' + JSON.stringify(selectedIDs)    + ',SID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.SID) + ',PID:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.PID) + ',id:' + JSON.stringify(CMS_PATIENT_PRESCRIPTION.ID) + '}',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            headers: {
    //                'VerificationToken': forgeryId
    //            }
    //        }).done(function (msg) {
    //            if (msg == '1') {
    //                location.reload();
    //            }
    //            else if (msg == '2') {
    //                alert('Đã tồn tại dị ứng rồi! Mời bạn kiểm tra lại');
    //            } else {
    //                alert('Cập nhật không thành công');
    //            }
    //        });


 
    //    }
    //    return true;
    //}

    //else
    //    return false;

}




function SavemedicalExamination() {

    var forgeryId = $("#forgeryToken").val();
    var PATIENT_SERVICE_RESULT = {};
    PATIENT_SERVICE_RESULT.HISTORY_SICK = $('input[id="PATIENT_SERVICE_RESULT_HISTORY_SICK"]').val();
    PATIENT_SERVICE_RESULT.EXAMINATION_CONTENT = $('input[id="PATIENT_SERVICE_RESULT_EXAMINATION_CONTENT"]').val();
    PATIENT_SERVICE_RESULT.SERVICE_RESULT = $('input[id="PATIENT_SERVICE_RESULT_SERVICE_RESULT"]').val();
    PATIENT_SERVICE_RESULT.MAINSICK = $("#PATIENT_SERVICE_RESULT_MAINSICK option:selected").val();
    PATIENT_SERVICE_RESULT.SERVICE_ADVICE = $('input[id="PATIENT_SERVICE_RESULT_SERVICE_ADVICE"]').val();
    PATIENT_SERVICE_RESULT.SERVICE_NOTE = $('input[id="PATIENT_SERVICE_RESULT_SERVICE_NOTE"]').val();
    PATIENT_SERVICE_RESULT.PID = $('input[id="PATIENTINFO_PID"]').val();
    PATIENT_SERVICE_RESULT.PATIENT_ID = $('input[id="SID"]').val();
    PATIENT_SERVICE_RESULT.CPS_ID = $('input[id="PATIENT_SERVICE_RESULT_CPS_ID"]').val();
    PATIENT_SERVICE_RESULT.SERVICE_NAME = $('input[id="PATIENT_SERVICE_RESULT_SERVICE_NAME"]').val();
    PATIENT_SERVICE_RESULT.SERVICE_PRICE = $('input[id="PATIENT_SERVICE_RESULT_SERVICE_PRICE"]').val();

    if ($('input[id="PATIENT_SERVICE_RESULT_SERVICE_RESULT"]').val().length < 1) {
        $.alert({
            title: 'Thông báo!',
            content: 'Mời bạn nhập tóm tắt kế quả!',
        });

       
    } else if ($('input[id="PATIENT_SERVICE_RESULT_EXAMINATION_CONTENT"]').val().length < 1) {
        $.alert({
            title: 'Thông báo!',
            content: 'Mời bạn nhập nội dung khám!',
        });
        
    } else {

        $.ajax({
            type: "POST",
            url: "/Clinic/SavemedicalExamination",
            data: '{PATIENT_SERVICE_RESULT:' + JSON.stringify(PATIENT_SERVICE_RESULT) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'VerificationToken': forgeryId
            }
        }).done(function (msg) {
            if (msg == '1') {
                $("#sorting-table-PATIENT_PRESCRIPTION").append(dataview);
            }
            else if (msg == '2') {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Đã tồn tại dị ứng rồi! Mời bạn kiểm tra lại!',
                });

                
            } else {
                $.alert({
                    title: 'Thông báo!',
                    content: 'Cập nhật không thành công!',
                });

                 
            }
        });




    }
}




function SaveHISTORIE() {


    var forgeryId = $("#forgeryToken").val();

    var CMS_PATIENT_HISTORY = {};
    CMS_PATIENT_HISTORY.SICKNAME = $("#SICKNAME option:selected").text();
    CMS_PATIENT_HISTORY.SICKYEAR = $('input[id="SICKYEAR"]').val();
    CMS_PATIENT_HISTORY.NOTE = $('input[id="HISTORIENOTE"]').val();
    CMS_PATIENT_HISTORY.PID = $('input[id="PID"]').val();
    CMS_PATIENT_HISTORY.ID = $('input[id="HISTORIEID"]').val();
 
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

                $("#SICKYEAR").val('');
                $("#HISTORIENOTE").val('');
                $("#SICKNAME").select2("val", "0");

            }
        });
    }

    //var forgeryId = $("#forgeryToken").val();

    //var CMS_PATIENT_HISTORY = {};
    //CMS_PATIENT_HISTORY.SICKNAME = $("#SICKNAME option:selected").text();
    //CMS_PATIENT_HISTORY.SICKYEAR = $('input[id="SICKYEAR"]').val();
    //CMS_PATIENT_HISTORY.NOTE = $('input[id="HISTORIENOTE"]').val();
    //CMS_PATIENT_HISTORY.PID = $('input[id="PID"]').val();
    //CMS_PATIENT_HISTORY.ID = $('input[id="HISTORIEID"]').val();

    //var year = new Date().getFullYear()

    //if ($("#SICKNAME option:selected").text().length < 1) {
    //    alert("Bạn chưa chọn tên bệnh");
    //} else if (!$.isNumeric($('input[id="SICKYEAR"]').val())) {
    //    alert("Năm bị bệnh nhập sai kiểu");
    //} else if ($('input[id="SICKYEAR"]').val() > year) {
    //    alert("Năm bị bệnh lớn hơn năm hiện tại");
    //} else if ($('input[id="SICKYEAR"]').val() < 1800) {
    //    alert("Năm bị bệnh nhỏ hơn năm 1800");
    //}
    //else {

      

     

    //    $.ajax({
    //        type: "POST",
    //        url: "/Clinic/SaveHISTORIEExamination",
    //        data: '{SICKNAME:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKNAME) + ',SICKYEAR:' + JSON.stringify(CMS_PATIENT_HISTORY.SICKYEAR) + ',NOTE:' + JSON.stringify(CMS_PATIENT_HISTORY.NOTE) + ',pid:' + JSON.stringify(CMS_PATIENT_HISTORY.PID) + ',id:' + JSON.stringify(CMS_PATIENT_HISTORY.ID) + '}',
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        headers: {
    //            'VerificationToken': forgeryId
    //        }
    //    }).done(function (msg) {            
    //        if (msg == '0') {
    //            alert('Cập nhật không thành công');               
    //        }
    //        else if (msg == '2') {
    //            alert('Đã tồn tại bệnh rồi! Mời bạn kiểm tra lại');
    //        } else {
    //            var dataview = '';
    //            dataview += "<tr><td class='SICKNAME'>" + $("#SICKNAME option:selected").text() + "</td>";
    //            dataview += "<td class='SICKYEAR'>" + $('input[id="SICKYEAR"]').val() + "</td>";
    //            dataview += "<td class='HISTORIES_NOTE'>" + $('input[id="HISTORIENOTE"]').val() + "</td>";
    //            dataview += "<td style='display: none; ' class='HISTORIES_ID'>" + msg + "</td>";              
    //            dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
    //            dataview += '</tr>';
    //            $("#sorting-table-history").append(dataview);
    //        }
    //    });
    //}
}




function SaveALLERGGY() {


    var forgeryId = $("#forgeryToken").val();
    var CMS_PATIENT_ALLERGY = {};
    CMS_PATIENT_ALLERGY.ALLERGY_NAME = $('input[id="ALLERGY_NAME"]').val();
    CMS_PATIENT_ALLERGY.ALLERGY_TYPE = $("#ALLERGY_TYPE option:selected").val();
    CMS_PATIENT_ALLERGY.ALLERGY_NOTE = $('input[id="ALLERGY_NOTE"]').val();
    CMS_PATIENT_ALLERGY.PID = $('input[id="PID"]').val();
    CMS_PATIENT_ALLERGY.ID = $('input[id="ALLERGGYID"]').val();

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
                dataview += "<td  style='display: none; ' class='ALLERGY_TID' >" + msg + "</td>";
                dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
                dataview += '</tr>';
                $("#sorting-table-sick").append(dataview);

                $("#ALLERGY_NAME").val('');
                $("#ALLERGY_NOTE").val('');
                $("#ALLERGY_TYPE").select2("val", "0");


            }
        });
    }


    //var forgeryId = $("#forgeryToken").val();
    //var CMS_PATIENT_ALLERGY = {};
    //CMS_PATIENT_ALLERGY.ALLERGY_NAME = $('input[id="ALLERGY_NAME"]').val();
    //CMS_PATIENT_ALLERGY.ALLERGY_TYPE = $("#ALLERGY_TYPE option:selected").val();
    //CMS_PATIENT_ALLERGY.ALLERGY_NOTE = $('input[id="ALLERGY_NOTE"]').val();
    //CMS_PATIENT_ALLERGY.PID = $('input[id="PID"]').val();
    //CMS_PATIENT_ALLERGY.ID = $('input[id="ALLERGGYID"]').val();

    //if ($('input[id="ALLERGY_NAME"]').val().length < 1) {
    //    alert("Bạn chưa chọn loại dị ứng");
    //} else {
       


    //    $.ajax({
    //        type: "POST",
    //        url: "/Clinic/SaveALLERGGYExamination",
    //        data: '{ALLERGY_NAME:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NAME) + ',ALLERGY_TYPE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_TYPE) + ',ALLERGY_NOTE:' + JSON.stringify(CMS_PATIENT_ALLERGY.ALLERGY_NOTE) + ',pid:' + JSON.stringify(CMS_PATIENT_ALLERGY.PID) + ',id:' + JSON.stringify(CMS_PATIENT_ALLERGY.ID) + '}',
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        headers: {
    //            'VerificationToken': forgeryId
    //        }
    //    }).done(function (msg) {
    //        if (msg == '0') {
    //            alert('Cập nhật không thành công');              
    //        }
    //        else if (msg == '2') {
    //            alert('Đã tồn tại dị ứng rồi! Mời bạn kiểm tra lại');
    //        } else {
    //            var dataview = '';
    //            dataview += "<tr><td class='ALLERGY_NAME' >" + $('input[id="ALLERGY_NAME"]').val() + "</td>";
    //            dataview += "<td class='ALLERGY_TYPE_NAME' >" + $("#ALLERGY_TYPE option:selected").text() + "</td>";               
    //            dataview += "<td  style='display: none; ' class='ALLERGY_TYPE' >" + $("#ALLERGY_TYPE option:selected").val() + "</td>";
    //            dataview += "<td class='ALLERGY_NOTE' >" + $('input[id="ALLERGY_NOTE"]').val() + "</td>";
    //            dataview += "<td  style='display: none; ' class='ALLERGY_TID' >" + msg + "</td>";              
    //            dataview += "<td class='td-actions'><a class='Update' href='javascript:;' ><i class='fa fa-edit edit'></i></a> </td>";
    //            dataview += '</tr>';
    //            $("#sorting-table-sick").append(dataview);

    //            $("#ALLERGY_NAME").val();
    //            $("#ALLERGY_NOTE").val(); 
    //            $("#ALLERGY_TYPE option:selected").val(0);
    //        }
    //    });
    //}

}



function SaveSERVICE() {

    var forgeryId = $("#forgeryToken").val();

    var CMS_PATIENT = {};
    CMS_PATIENT.SERVICE_GROUPID = 0;
    CMS_PATIENT.SERVICEID = $("#SERVICEID").val();
    CMS_PATIENT.PID = $('input[id="PID"]').val();
    CMS_PATIENT.SID = $('input[id="SID"]').val();
    CMS_PATIENT.locationID = $("#phong").val();

    if (CMS_PATIENT.SERVICEID != null) {


        if (CMS_PATIENT.SERVICEID.length < 1) {
            $.alert({
                title: 'Thông báo!',
                content: 'Bạn chưa chọn dịch vụ!',
            });

        }
        else {
            $.ajax({
                type: "POST",
                url: "/Clinic/SaveSERVICEExamination",
                data: '{locationID:' + JSON.stringify(CMS_PATIENT.locationID) + ',SERVICEID:' + JSON.stringify(CMS_PATIENT.SERVICEID) + ',pid:' + JSON.stringify(CMS_PATIENT.PID) + ',sid:' + JSON.stringify(CMS_PATIENT.SID) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                headers: {
                    'VerificationToken': forgeryId
                }
            }).done(function (msg) {
                if (msg == '1') {
                    $.alert({
                        title: 'Thông báo!',
                        content: 'Cập nhật thành công!',
                    });

                }
                else if (msg == '2') {
                    $.alert({
                        title: 'Thông báo!',
                        content: 'Đã tồn tại bệnh rồi! Mời bạn kiểm tra lại!',
                    });

                } else if (msg == '3') {
                    $.alert({
                        title: 'Thông báo!',
                        content: 'Mời bạn chọn dịch vụ!',
                    });

                } else if (msg == '4') {
                    $.alert({
                        title: 'Thông báo!',
                        content: 'Mời bạn chọn phòng khám!',
                    });

                } else if (msg.length > 3) {
                    $.alert({
                        title: 'Thông báo!',
                        content: msg,
                    });

                }
                else {
                    $.alert({
                        title: 'Thông báo!',
                        content: 'Cập nhật không thành công!',
                    });

                }
            });
        }
    } else {
        $.alert({
            title: 'Thông báo!',
            content: 'Bạn chưa chọn dịch vụ!',
        });
    }
}

 

//Update event handler.
$("body").on("click", "#table_history_PATIENT_PRESCRIPTION .Update", function () {

    var forgeryId = $("#forgeryToken").val();
    var row = $(this).closest("tr");

    // $("#MEDICINE_NAME").val(row.find(".MEDICINE_NAME1").text());
    $("#MEDICINE_AMOUNT").val(row.find(".COUNT").text());
    $("#MEDICINE_ID1").val(row.find(".MEDICINE_ID").text());
    $("#PATIENT_PRESCRIPTION_ID").val(row.find(".CMS_PATIENT_PRESCRIPTIONS_ID").text());
    $("#MEDICINE_USAGE").val(row.find(".MEDICINE_USAGE").text());

    var MEDICINE_ID = row.find(".MEDICINE_ID").text();

    $("#MEDICINE_ID").select2("val", MEDICINE_ID);


    $.ajax({
        type: "POST",
        url: "/pharmacyStore/GetInfoMedicine?ID=" + MEDICINE_ID,
        data: JSON.stringify(MEDICINE_ID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        $.each(msg, function (index, item) {

            if (msg != '') {
                $("#MEDICINE_ID1").val(item.ID);
                $("#MEDICINE_CODE").val(item.ID);
                $("#MEDICINE_CODE1").val(item.ID);
                $("#MEDICINE_NAME").val(item.MEDICINE_NAME);
                $("#MEDICINE_UNIT").val(item.MEDICINE_UNIT);
                $("#MEDICINE_UNIT_NAME").val(item.MEDICINE_UNIT_NAME);
               // $("#MEDICINE_USAGE").val(item.MEDICINE_USAGE);
                
            } else {
                $("#MEDICINE_ID1").val(0);
                $("#MEDICINE_CODE").val();
                $("#MEDICINE_CODE1").val();
                $("#MEDICINE_NAME").val();
                $("#MEDICINE_UNIT").val(0);
                $("#MEDICINE_UNIT_NAME").val();
                $("#MEDICINE_USAGE").val();
            }
        });

        });

       
    row.remove();  


});

//Update event handler.
$("body").on("click", "#table-sick .Update", function () {
    var row = $(this).closest("tr");
    $("#ALLERGY_NAME").val(row.find(".ALLERGY_NAME").text());
    
    $("#ALLERGY_NOTE").val(row.find(".ALLERGY_NOTE").text());

    var ALLERGY_TYPE = row.find(".ALLERGY_TYPE").text();

    $("#ALLERGY_TYPE").select2("val", ALLERGY_TYPE);
    $("#ALLERGGYID").val(row.find(".ALLERGY_TID").text());
     
    row.remove(); 
});


//Update event handler.
$("body").on("click", "#table_history .Update", function () {
    var row = $(this).closest("tr");
    $("#SICKYEAR").val(row.find(".SICKYEAR").text());

    $("#HISTORIENOTE").val(row.find(".HISTORIES_NOTE").text());

    var SICKNAME = row.find(".SICKNAME").text();

    $("#SICKNAME").select2("val", SICKNAME);
    $("#HISTORIEID").val(row.find(".HISTORIES_ID").text());

    row.remove(); 
});



$("body").on("click", "#CMS_PATIENT_SERVICE_RESULTS_History .Update", function () {
    var forgeryId = $("#forgeryToken").val();
    var row = $(this).closest("tr");
   
    var CMS_PATIENT_SERVICE_RESULTS_ID = row.find(".CMS_PATIENT_SERVICE_RESULTS_ID").text();
    

    $.ajax({
        type: "POST",
        url: "/Clinic/GetResultPatient?ID=" + CMS_PATIENT_SERVICE_RESULTS_ID,
        data: JSON.stringify(CMS_PATIENT_SERVICE_RESULTS_ID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {
        
        $.each(msg, function (index, item) {
           

            if (msg != '') {

                CKEDITOR.instances.CMS_PATIENT_SERVICE_RESULTS_INPUT_EXAMINATION_CONTENT.setData(item.EXAMINATION_CONTENT);
                CKEDITOR.instances.CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_RESULT.setData(item.SERVICE_RESULT);

                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_ID").val(item.ID);
                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_ADVICE").val(item.SERVICE_ADVICE);
                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_NOTE").val(item.SERVICE_NOTE);
                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_ID").select2("val", item.SERVICE_ID);
                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_MAINSICK").select2("val", item.MAINSICK);
                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_WEIRDO").select2("val", item.WEIRDO);
                $("#SECONDARY_SICK").val(item.SECONDARY_SICK);
                $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_ID").val(row.find(".ID").text());
               

                
            }  
        });

    });


 
    row.remove();
});


//Update event handler.
$("body").on("click", "#sorting-table-CMS_PATIENT_SERVICE_RESULTS .Update", function () {
    var row = $(this).closest("tr");
    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_HISTORY_SICK").val(row.find(".HISTORY_SICK").text());

    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_EXAMINATION_CONTENT").val(row.find(".EXAMINATION_CONTENT").text());

    var SERVICE_ID = row.find(".SERVICE_ID").text();

    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_ID").select2("val", SERVICE_ID);
    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_RESULT").val(row.find(".SERVICE_RESULT").text());

    var MAINSICK = row.find(".MAINSICK").text();

    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_MAINSICK").val(row.find(".MAINSICK").text());

    
    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_ADVICE").val(row.find(".SERVICE_ADVICE").text());
    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_NOTE").val(row.find(".SERVICE_NOTE").text());
    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_SERVICE_NOTE").val(row.find(".SERVICE_NOTE").text());
    $("#CMS_PATIENT_SERVICE_RESULTS_INPUT_ID").val(row.find(".CMS_PATIENT_SERVICE_RESULTSID").text());
    
});

this.imagePreview = function () {
    /* CONFIG */

    xOffset = 10;
    yOffset = 30;

    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result

    /* END CONFIG */
    $("a.preview").hover(function (e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "<br/>" + this.t : "";
        $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' width='250px' />" + c + "</p>");
        $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("fast");
    },
        function () {
            this.title = this.t;
            $("#preview").remove();
        });
    $("a.preview").mousemove(function (e) {
        $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px");
    });
};

