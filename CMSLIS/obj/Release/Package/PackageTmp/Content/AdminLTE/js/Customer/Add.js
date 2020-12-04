var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SaveAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("backAdd").href;
        window.location.href = url;
    }

});



(function ($) {
    'use strict';
    //var datatableInit = function () {
    //    $('#sorting-table').dataTable(
    //        {
    //            "columnDefs": [{
    //                "targets": 'no-sort',
    //                "orderable": false,
    //            }]
    //        }
    //    );
    //};
    //$(function () {
    //    datatableInit();
    //});


    $('#dateAdd').daterangepicker({
        singleDatePicker: true,
        locale: {
            format: 'DD/MM/YYYY HH:mm:ss',
            pick12HourFormat: true
        }
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

 