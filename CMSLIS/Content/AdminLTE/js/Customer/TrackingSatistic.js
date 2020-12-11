var map;
function initMap() {
    // The map, centered at Uluru
    map = new google.maps.Map(document.getElementById("tracking-map"), {
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
                color: '#007455'
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
                openModal(data, location.userFullName);
                $(".spinner-loader").removeClass("show");
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

function openModal(data, currUserName) {
    $(".content-data").empty();
    $("#modalDetailInfoTitle").text('Doanh thu tại nhà của ' + currUserName);
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
                            <td style="font-weight:bold;">` + new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(payTotalAgree) + `</td>
                        </tr>`
        $(".content-data").append(result);
        $("#modalDetailInfo").modal('show');
    }
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

$(document).ready(function () {
    var isShow = false;
    $(".widget-pane-toggle-button").click(function () {
        $(".widget-pane-content-holder").toggle(0);
        isShow = !isShow;
        if (isShow) {
            $(".widget-panel-toggle-button-container").animate({ left: 260 }, 200, 'linear');
            $("#users-navigate-tab").removeClass("fa-chevron-right");
            $("#users-navigate-tab").addClass("fa-chevron-left");
        } else {
            $(".widget-panel-toggle-button-container").animate({ left: 10 }, 200, 'linear');
            $("#users-navigate-tab").removeClass("fa-chevron-left");
            $("#users-navigate-tab").addClass("fa-chevron-right");
        }
    });
    $(".user-suggest").click(function (e) {
        const clickedElement = $(event.target);
        const targetUserId = clickedElement.attr('id');
        var locate = locations.find(x => x.userId == targetUserId)
        if (locate != null) {
            map.setCenter(new google.maps.LatLng(locate.lat, locate.lng));
        }
    })

    var listUsers = accounts;
    if (listUsers) {
        renderListUsers(listUsers);
    }

    $("#keyword").keyup(function (e) {
        if (e.target.value) {
            var listUsersSearch = listUsers.filter(x => x.hoten && stripVietnameseChars(x.hoten).toUpperCase().indexOf(stripVietnameseChars(e.target.value.trim())) > -1);
            renderListUsers(listUsersSearch);
        } else {
            renderListUsers(listUsers);
        }
    });
});

function renderListUsers(users) {
    $(".list-users").empty();
    var htmlRender = '';
    for (let i = 0; i < users.length; i++) {
        var tempItem = `<li id="` + users[i].accountLis + `" class="item user-suggest">
                                <label class="item-label">` + users[i].hoten + `</label>
                                <i id="`+ users[i].accountLis +`" class="user-detail-actions fa fa-eye-slash ml-auto"></i>
                            </li>`;
        htmlRender += tempItem;
    }
    $(".list-users").append(htmlRender);
    $(".user-detail-actions").click(function (event) {
        var forgeryId = $("#forgeryToken").val();
        const clickedElement = $(event.target);
        const targetUserId = clickedElement.attr('id');
        var user = users.find(x => x.accountLis == targetUserId);
        $(".spinner-loader").addClass("show");
        $.ajax({
            type: "GET",
            url: "/RevenueHome/RevenueDetailByUser",
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: {
                userId: targetUserId
            },
            headers: {
                'VerificationToken': forgeryId
            },
            success: function (data) {
                openModal(data, user.hoten);
                $(".spinner-loader").removeClass("show");
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

function stripVietnameseChars(str) {
    str = str.replace(/\s+/g, ' ');
    str.trim();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/Đ/g, "D");
    return str.toUpperCase();
}