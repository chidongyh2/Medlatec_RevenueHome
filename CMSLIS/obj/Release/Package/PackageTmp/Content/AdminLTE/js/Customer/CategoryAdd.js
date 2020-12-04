
var keyCodeOld; 
document.addEventListener("keydown", function (event) {

    
    if (event.keyCode == 18) {
        keyCodeOld = 18;        
    }
    if (event.keyCode == 83 && keyCodeOld == 18) {
        keyCodeOld = 0;   
        document.getElementById('SaveCategoryAdd').click();
        return false;
    }

    if (event.keyCode == 90 && keyCodeOld == 18) {
        var url = document.getElementById("listCategory").href;
        keyCodeOld = 0;   
        window.location.href = url;
    }

});



$(document).ready(function () {

    $('.select2').select2();

});
