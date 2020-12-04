$(document).ready(function () {

    var forgeryId = $("#forgeryToken").val();

    $.ajax({
        type: "POST",
        url: "/home/getDashboard?type=0",
        data: JSON.stringify('0'),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        /**/
        new Morris.Line({
            // ID of the element in which to draw the chart.
            element: 'Revenue',
            data: msg,           
            xkey: 'create_date_View',
            ykeys: ['Total'],
            labels: ['Doanh thu'],
            lineColors: ['#efefef'],
            lineWidth: 2,
            hideHover: 'auto',
            gridTextColor: '#fff',
            gridStrokeWidth: 0.4,
            pointSize: 4,
            pointStrokeColors: ['#efefef'],
            gridLineColor: '#efefef',
            gridTextFamily: 'Open Sans',
            gridTextSize: 10,
            parseTime: false 
 

        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });



    $.ajax({
        type: "POST",
        url: "/home/getDashboard?type=1",
        data: JSON.stringify('1'),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        /**/
        new Morris.Bar({
            // ID of the element in which to draw the chart.
            element: 'PatienInfos',
            data: msg,
            xkey: 'create_date_View',
            ykeys: ['Total'],
            labels: ['Số bệnh nhân'],
            

        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });


    $.ajax({
        type: "POST",
        url: "/home/getDashboard?type=3",
        data: JSON.stringify('1'),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        /**/
        new Morris.Bar({
            // ID of the element in which to draw the chart.
            element: 'Prescriptions',
            data: msg,
            xkey: 'create_date_View',
            ykeys: ['Total'],
            labels: ['Số đơn thuốc'],


        });
    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
        });



    $.ajax({
        type: "POST",
        url: "/home/getDashboard?type=2",
        data: JSON.stringify('2'),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            'VerificationToken': forgeryId
        }
    }).done(function (msg) {

        /**/
        new Morris.Line({
            // ID of the element in which to draw the chart.
            element: 'RevenueMedicine',
            data: msg,
            xkey: 'create_date_View',
            ykeys: ['Total'],
            labels: ['Doanh thu bán thuốc'],
            lineColors: ['#efefef'],
            lineWidth: 2,
            hideHover: 'auto',
            gridTextColor: '#fff',
            gridStrokeWidth: 0.4,
            pointSize: 4,
            pointStrokeColors: ['#efefef'],
            gridLineColor: '#efefef',
            gridTextFamily: 'Open Sans',
            gridTextSize: 10,
            parseTime: false 


        });


    }).fail(function (data) {
        $.alert({
            title: 'Thông báo!',
            content: 'Có lỗi trong quá lấy thông tin!',
        });
    });



});
