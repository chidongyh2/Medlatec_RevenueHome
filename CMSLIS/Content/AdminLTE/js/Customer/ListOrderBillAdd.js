var keyCodeOld;

document.addEventListener("keydown", function (event) {
    if (event.keyCode == 18) {
        keyCodeOld = 18;
    }

    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;
        document.getElementById('SaveListOrderBillAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        keyCodeOld = 0;
        var url = document.getElementById("BackListItem").href;
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();
    $('#Order_Bill_BillTotalView').maskNumber({ integer: true });
    imagePreview();
});





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