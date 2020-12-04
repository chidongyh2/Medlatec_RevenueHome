$(document).ready(function () {

    var start = $('input[id="date"]').val();
    var end = $('input[id="dateDenngay"]').val();
    start = start.replace('/', '').replace('/', '');

    var start1 = start.substring(4, 9) + start.substring(2, 4) + start.substring(0, 2);
    end = end.replace('/', '').replace('/', '');
    var end1 = end.substring(4, 9) + end.substring(2, 4) + end.substring(0, 2);

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/Report/getDashboardView",
        data: '{start:' + JSON.stringify(start1) + ',end:' + JSON.stringify(end1)   + '}',
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
            ykeys: ['Total', 'Total2','Total3'],
            labels: ['Tổng tiền', 'Tiền đã trả','Tiền nguyên liệu'],
            fillOpacity: 0.6,
            hideHover: 'auto',
            behaveLikeLine: true,
            resize: true,
            pointFillColors: ['#ffffff'],
            pointStrokeColors: ['black'],
            lineColors: ['gray', 'red','yellow'],
            horizontal: true 
           


        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });

     


});



function Report() {

    
    var start = $('input[id="date"]').val();
    var end = $('input[id="dateDenngay"]').val();
    start = start.replace('/', '').replace('/', '');
    
    var start1 = start.substring(4, 9) + start.substring(2, 4) + start.substring(0, 2);
    end = end.replace('/', '').replace('/', '');
    var end1 = end.substring(4, 9) + end.substring(2, 4) + end.substring(0, 2);

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/Report/getDashboardView",
        data: '{start:' + JSON.stringify(start1) + ',end:' + JSON.stringify(end1) + '}',
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
            ykeys: ['Total', 'Total2', 'Total3'],
            labels: ['Tổng tiền', 'Tiền đã trả', 'Tiền nguyên liệu'],
            fillOpacity: 0.6,
            hideHover: 'auto',
            behaveLikeLine: true,
            resize: true,
            pointFillColors: ['#ffffff'],
            pointStrokeColors: ['black'],
            lineColors: ['gray', 'red', 'yellow'],
            horizontal: true



        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });


}

