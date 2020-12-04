$(document).ready(function () {
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });
});


//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {
    document.getElementById('cmdSearch').click();
}



//To get selected value an text of dropdownlist
function SelectedValueChild(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    var options = {};
    options.url = "/System/PermissionControlByParrentMenu?ParrentID=" + selectedValue;
    options.type = "POST";
    options.data = JSON.stringify(selectedValue);
    options.contentType = "application/json";
    options.dataType = "json";
    options.success = function (msg) {
        $("#MenChild").html('');
        $("#MenChild").get(0).options.length = 0;
        $("#MenChild").get(0).options[0] = new Option("Chọn nhóm menu", "0");
        $.each(msg, function (index, item) {
            $("#MenChild").get(0).options[$("#MenChild").get(0).options.length] = new Option(item.menName, item.menId);
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

     

}

