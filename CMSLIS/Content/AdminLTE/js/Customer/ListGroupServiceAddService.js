(function ($) {
    'use strict';
    var datatableInit = function () {
        $('#sorting-table').dataTable(
            {
               // "pageLength": 300
                //"columnDefs": [{
                //    "targets": 'no-sort',
                //    "orderable": false,
                //}]
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
