$(document).ready(function () {
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });

    $('#checkBoxNoAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxNotId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxNotId").prop("checked", false)
        }
    });

    $('.select2').select2();
});


(function ($) {
    'use strict';
    var datatableInit = function () {
        $('#sorting-table').dataTable(
            {
                "pageLength": 100,
                "columnDefs": [{
                    "targets": 'no-sort',
                    "orderable": false,
                }],

            }
        );
    };
    $(function () {
        datatableInit();
    });

}).apply(this, [jQuery]);


//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {
    document.getElementById('cmdSearch').click();
}



//To get selected value an text of dropdownlist
function SelectedGroupValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    var options = {};
    options.url = "/RevenueHome/getListLocationByGroupID?groupid=" + selectedValue;
    options.type = "POST";
    options.data = JSON.stringify(selectedValue);
    options.contentType = "application/json";
    options.dataType = "json";
    options.success = function (msg) {
        $("#Groupid").html('');
        $("#Groupid").get(0).options.length = 0;
        $("#Groupid").get(0).options[0] = new Option("Tất cả", "0");
        $.each(msg, function (index, item) {
            $("#Groupid").get(0).options[$("#Groupid").get(0).options.length] = new Option(item.LocationName, item.LocationID);
        });
        

    };

    document.getElementById('cmdSearch').click();
}
