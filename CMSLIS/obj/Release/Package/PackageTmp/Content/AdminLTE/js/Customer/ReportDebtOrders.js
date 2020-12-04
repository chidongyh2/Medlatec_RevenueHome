$(document).ready(function () {

    var start = $('input[id="date"]').val();
    var end = $('input[id="dateDenngay"]').val();
    var producid = $("#ItemCateItemID option:selected").val();

    start = start.replace('/', '').replace('/', '');

    var start1 = start.substring(4, 9) + start.substring(2, 4) + start.substring(0, 2);
    end = end.replace('/', '').replace('/', '');
    var end1 = end.substring(4, 9) + end.substring(2, 4) + end.substring(0, 2);

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/Report/ReportDebtOrdersView",
        data: '{start:' + JSON.stringify(start1) + ',end:' + JSON.stringify(end1) + ',producid:' + JSON.stringify(producid) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        /**/
        new Morris.Bar({
            // ID of the element in which to draw the chart.
            element: 'Revenue',
            data: msg,


            xkey: 'create_date_View',
            ykeys: ['Total'],
            labels: ['Tiền nợ khác hàng'],
            fillOpacity: 0.6,
            hideHover: 'auto',
            behaveLikeLine: true,
            resize: true,
            pointFillColors: ['#ffffff'],
            pointStrokeColors: ['black'],
            lineColors: [ 'red'],
            horizontal: true



        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });




});


function SelectedValueType(ddlObject) {
    //Selected value of dropdownlist
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    Report()
}



function Report() {



    var start = $('input[id="date"]').val();
    var end = $('input[id="dateDenngay"]').val();
    var producid = $("#ItemCateItemID option:selected").val();

    start = start.replace('/', '').replace('/', '');

    var start1 = start.substring(4, 9) + start.substring(2, 4) + start.substring(0, 2);
    end = end.replace('/', '').replace('/', '');
    var end1 = end.substring(4, 9) + end.substring(2, 4) + end.substring(0, 2);

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/Report/ReportDebtOrdersView",
        data: '{start:' + JSON.stringify(start1) + ',end:' + JSON.stringify(end1) + ',producid:' + JSON.stringify(producid) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        /**/
        new Morris.Bar({
            // ID of the element in which to draw the chart.
            element: 'Revenue',
            data: msg,


            xkey: 'create_date_View',
            ykeys: ['Total'],
            label: ['Tiền nợ khác hàng'],
            fillOpacity: 0.6,
            hideHover: 'auto',
            behaveLikeLine: true,
            resize: true,
            pointFillColors: ['#ffffff'],
            pointStrokeColors: ['black'],
            lineColors: ['red'],
            horizontal: true



        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });


}

