 


(function ($) {
    'use strict';
    var datatableInit = function () {
        $('#sorting-table').dataTable(
            {
                "pageLength": 100,
                "columnDefs": [{
                    "targets": 'no-sort',
                    "orderable": false,
                }]
            }
        );
    };
    $(function () {
        datatableInit();
    });

}).apply(this, [jQuery]);




$(document).ready(function () {
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });

    $('.select2').select2()





});

 
 
function SelectedValueStatus(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    document.getElementById('cmdSearch').click();

}


function SelectedValue(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    document.getElementById('cmdSearch').click();

}


function SelectedValueType(ddlObject) {

    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
    document.getElementById('cmdSearch').click();

}

