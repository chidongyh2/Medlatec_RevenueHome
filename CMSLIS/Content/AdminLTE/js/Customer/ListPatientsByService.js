$(document).ready(function () {
    $('#checkBoxAll').click(function () {
        if ($(this).is(":checked")) {
            $(".chkCheckBoxId").prop("checked", true)
        }
        else {
            $(".chkCheckBoxId").prop("checked", false)
        }
    });


    var sid = $('#sid').val();
    $("#ChoiListPatientsByService").click(function () {
        var forgeryId = $("#forgeryToken").val();
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
        if (selectedIDs == '') {
            alert("Mời chọn bản ghi để chọn");
        } else {
            var options = {};
            options.url = "/Clinic/ChoiListPatientsByService";
            options.type = "POST";
            options.data = "{'customerIDs':'" + JSON.stringify(selectedIDs) + "', 'sid':'" + sid + "'}",

                options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {
                // alert(msg);
                location.reload();
            };
            options.error = function () {
                alert("Có lỗi trong quá trình chọn bản ghi");
            };
            $.ajax(options);
        }
    });


    $("#DeleListPatientsByService").click(function () {
        var forgeryId = $("#forgeryToken").val();
        var selectedIDs = new Array();
        $('input:checkBox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });
        if (selectedIDs == '') {
            alert("Mời chọn bản ghi để chọn");
        } else {

            var options = {};
            options.url = "/Clinic/DeleListPatientsByService";
            options.type = "POST";
            options.data = "{'customerIDs':'" + JSON.stringify(selectedIDs) + "', 'newid':'" + newid + "'}",

                options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {
                // alert(msg);
                location.reload();
            };
            options.error = function () {
                alert("Có lỗi trong quá trình chọn bản ghi");
            };
            $.ajax(options);
        }
    });

    $("#CloseListPatientsByService").click(function () {

        //var opener = window.opener;
        //if (opener) {
        //    var oDom = opener.document;
        //    var elem = oDom.getElementById("ListNewsRelate");
        //    if (elem) {
        //        elem.value = "Số tin liên quan là: " + @countChoi.ToString();
        //    }
        //}

        var daddy = window.self;
        daddy.opener = window.self;
        daddy.close();
    });






});

