$(document).ready(function () {
    if ($("#selectTables")[0].length <= 0) {
        $("#addSubmit").val('No available tables');
        $("#addSubmit").attr("disabled", true);
    }
});
