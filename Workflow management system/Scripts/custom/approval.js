var data = [];
var approval_json;
    data.push({
        id: "lect1234",
        status: "Approved"
    });
    approval_json = JSON.stringify(data);
    console.log(approval_json);

function myFunction() {
    $('#myForm').append("<input type='hidden' name='WorkflowID' value='" + $('#WorkflowID').val() + "' />");
    $('#myForm').append("<input type='hidden' name='WorkflowTypeID' value='" + $('#WorkflowTypeID').val() + "' />");
    $('#myForm').append("<input type='hidden' name='Value' value='" + $('#Value').val() + "' />");
    $('#myForm').append("<input type='hidden' name='approve' value='" + approval_json + "' />");
    console.log(approval_json);
    $('#myForm').submit();
}