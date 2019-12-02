$('#requirements').on('change', function (evt) {
    $first = '<div class="form-group" id="add_desc">';
    $first += '<label asp-for="Description" class="control-label col-md-2">Description</label>';
    $first += '<div class="col-md-4">';
    $first += '<input type="text" class="form-control" id="desc" /></div>';
    $first += '<div class="col-md-4">';
    $first += '<span class="btn btn-primary" id="add_req" onclick="myFunction()">ADD</span></div></div>';
    $('#add_desc').replaceWith($first);
    evt.preventDefault();
});

var data = [];
var requirements_json;
function myFunction() {
    data.push({
        type: $('#requirements').val(),
        description: $('#desc').val()
    });
    requirements_json = JSON.stringify(data);
    console.log(requirements_json);
}

function mFunction() {
    $('#myForm').append("<input type='hidden' name='requirements' value='" + requirements_json + "' />");
    console.log(requirements_json);
    $('#myForm').submit();
}
