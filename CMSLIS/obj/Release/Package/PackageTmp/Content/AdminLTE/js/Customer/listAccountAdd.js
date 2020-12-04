var keyCodeOld; 

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        document.getElementById('SaveProfileUser').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;  
        var url = document.getElementById("BacklistAccount").href;
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();

});


//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    var options = {};
    options.url = "/System/getListGroupAccount?PARTNERID=" + selectedValue;
    options.type = "POST";
    options.data = JSON.stringify(selectedValue);
    options.contentType = "application/json";
    options.dataType = "json";
    options.success = function (msg) {
        $("#AccountType").html('');
        $("#AccountType").get(0).options.length = 0;
        $("#AccountType").get(0).options[0] = new Option("Chọn nhóm account", "0");
        $.each(msg, function (index, item) {
            $("#AccountType").get(0).options[$("#AccountType").get(0).options.length] = new Option(item.AName, item.AccountTypeId);
        });

        // $("#AccountType").focus();
    };
    options.error = function () {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình nhóm account!',
        });            
    };
    $.ajax(options);


    var options1 = {};
    options1.url = "/System/getListPartner_Code?PARTNERID=" + selectedValue;
    options1.type = "POST";
    options1.data = JSON.stringify(selectedValue);
    options1.contentType = "application/json";
    options1.dataType = "json";
    options1.success = function (msg) {
        $("#PARTNER_CODE").val('');
        $.each(msg, function (index, item) {
            $("#PARTNER_CODE").val(item.PARTNER_CODE);
        });
        $("#PARTNER_CODE1").val('');
        $.each(msg, function (index, item) {
            $("#PARTNER_CODE1").val(item.PARTNER_CODE);
        });

        // $("#AccountType").focus();
    };
    options1.error = function () {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá trình lấy mã đối tác!',
        });         
    };
    $.ajax(options1);


}