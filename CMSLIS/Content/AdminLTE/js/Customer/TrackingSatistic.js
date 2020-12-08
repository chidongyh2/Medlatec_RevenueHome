function initMap() {
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("tracking-map"), {
        zoom: 8,
        center: new google.maps.LatLng(21.0220951, 105.850696),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var marker, i;

    for (i = 0; i < locations.length; i++) {
       marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i].lat, locations[i].lng),
            map: map,
            label: {
                text: locations[i].userFullName,
                fontSize: '14px',
                fontWeight: 'bold',
                color: '#00c0ef'
            },
            icon: {
                labelOrigin: new google.maps.Point(75, 32),
                size: new google.maps.Size(32, 32),
                anchor: new google.maps.Point(16, 32)
            }
       });
       listenMarkerEvent(marker, locations[i]);
    }
}
function listenMarkerEvent(marker, location) {
    var forgeryId = $("#forgeryToken").val();
    marker.addListener("click", () => {
        $(".content-data").empty();
        $(".spinner-loader").addClass("show");
        $.ajax({
            type: "GET",
            url: "/RevenueHome/RevenueDetailByUser",
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: {
                userId: location.userId
            },
            headers: {
                'VerificationToken': forgeryId
            },
            success: function (data) {
                $("#modalDetailInfoTitle").text('Doanh thu tại nhà của ' + location.userFullName);
                var result = '';
                var sumMoneyTotal = 0;
                var sumPerTageTotal = 0;
                var payTotal = 0;
                var payTotalAgree = 0;
                if (data) {
                    for (var i = 0; i < data.length; i++) {
                        var row = '<tr>' +
                            '<td>' + data[i].UserTC + '</td>' +
                            '<td>' + formatDate(data[i].NgayThu) + '</td>' +
                            '<td>' + data[i].GroupName + '</td>' +
                            '<td>' + data[i].LocationName + '</td>' +
                            '<td>' + data[i].S_ID + '</td>' +
                            '<td>' + data[i].HoTen + '</td>' +
                            '<td class="text-right" style="color:red;">' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].TongCP) + '</td>' +
                            '<td class="text-right" style="color:red;">' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].TienDiemPID + data[i].TienGG) + '</td>' +
                            '<td class="text-right" style="color:red;">' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].PhiDiLai) + '</td>' +
                            '<td class="text-right" style="color:red;">' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].BHTT) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].BHBLTT) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].TongCP - data[i].BHBLTT - data[i].BHBLTT - data[i].TienGG - data[i].TienDiemPID) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].ThePOS) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].TraTruoc) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].TraSau) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].TongCP - data[i].BHBLTT - data[i].BHBLTT - data[i].TienGG - data[i].TienDiemPID - data[i].ThePOS - data[i].TraSau - data[i].TraTruoc) + '</td>' +
                            '<td>' + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data[i].SumAgree) + '</td>' +
                            '</tr>';
                        result += row;
                        sumMoneyTotal = sumMoneyTotal + data[i].TongCP;
                        sumPerTageTotal = sumPerTageTotal + data[i].TongCP - data[i].BHBLTT - data[i].BHBLTT - data[i].TienGG - data[i].TienDiemPID;
                        payTotal = payTotal + (data[i].TongCP - data[i].BHBLTT - data[i].BHBLTT - data[i].TienGG - data[i].TienDiemPID - data[i].ThePOS - data[i].TraSau - data[i].TraTruoc);
                        payTotalAgree = payTotalAgree + data[i].SumAgree;
                    }
                    result +=
                        `<tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td style="font-weight:bold;">Tổng</td>
                            <td class="text-right" style="font-weight:bold;">` + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(sumMoneyTotal) + `</td>
                            <td> </td>
                            <td> </td>
                            <td>  </td>
                            <td> </td>
                            <td style="font-weight:bold;">` + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(sumPerTageTotal) + `</td>
                            <td>  </td>
                            <td> </td>
                            <td>  </td>
                            <td style="font-weight:bold;">`+ new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(payTotal) + `</td>
                            <td style="font-weight:bold;">` + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(payTotalAgree) +`</td>
                        </tr>`
                    $(".content-data").append(result);
                    $("#modalDetailInfo").modal('show');
                    $(".spinner-loader").removeClass("show");
                }
            },
            error: function (err) {
                $(".spinner-loader").removeClass("show");
                $.alert({
                    title: 'Thông báo!',
                    content: 'Có lỗi trong quá trình duyệt bản ghi!',
                });
            }
        })
    });
}
function formatDate(dateVal) {
    var newDate = new Date(dateVal);

    var sMonth = padValue(newDate.getMonth() + 1);
    var sDay = padValue(newDate.getDate());
    var sYear = newDate.getFullYear();
    var sHour = newDate.getHours();
    var sMinute = padValue(newDate.getMinutes());
    var sAMPM = "AM";

    var iHourCheck = parseInt(sHour);

    if (iHourCheck > 12) {
        sAMPM = "PM";
        sHour = iHourCheck - 12;
    }
    else if (iHourCheck === 0) {
        sHour = "12";
    }

    sHour = padValue(sHour);

    return sDay + "-" + sMonth + "-" + sYear + " " + sHour + ":" + sMinute + " " + sAMPM;
}

function padValue(value) {
    return (value < 10) ? "0" + value : value;
}