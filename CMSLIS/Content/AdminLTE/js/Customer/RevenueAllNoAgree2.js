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
    imagePreview();
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



this.imagePreview = function () {
    /* CONFIG */

    xOffset = 10;
    yOffset = 30;

    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result

    /* END CONFIG */
    $("a.preview").hover(function (e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "<br/>" + this.t : "";
        $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' width='250px' />" + c + "</p>");
        $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("fast");
    },
        function () {
            this.title = this.t;
            $("#preview").remove();
        });
    $("a.preview").mousemove(function (e) {
        $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px");
    });
};
