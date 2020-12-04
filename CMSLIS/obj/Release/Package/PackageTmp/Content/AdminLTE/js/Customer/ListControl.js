//To get selected value an text of dropdownlist
function SelectedValue(ddlObject) {
    document.getElementById('cmdSearch').click();
}

$('#example2').Tabledit({
    editButton: false,
    deleteButton: false,
    hideIdentifier: false,
    columns: {
        identifier: [0, 'id'],
        editable: [[2, 'ControlID'], [3, 'ControlName'], [4, 'ControlDes']]
    }
});


//Update event handler.
$("body").on("click", "#example2 .Update", function () {
    var row = $(this).closest("tr");
    var cms_ControlName = {};
    cms_ControlName.menID = row.find(".menID").val();
    cms_ControlName.id = row.find('input[name="id"]').val();
    cms_ControlName.ControlID = row.find('input[name="ControlID"]').val();
    cms_ControlName.ControlName = row.find('input[name="ControlName"]').val();
    cms_ControlName.ControlDes = row.find('input[name="ControlDes"]').val();
    cms_ControlName.ControlStatus = row.find('select[id="ControlStatus"]').val();
    cms_ControlName.LangID = row.find('select[id="LangID"]').val();
    $.ajax({
        type: "POST",
        url: "/System/ListControlUpdate",
        data: '{ControlNameValue:' + JSON.stringify(cms_ControlName) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });

    location.reload();


});
