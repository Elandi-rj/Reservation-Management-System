$(document).ready(function () {
    $("#btnAddSitting").click(function () {
        $.post("MakeSittingType",
            {
                description: $("#txtSittingType").val()
            },
            function (data, status) {
                if (status == "success") {
                    $("#txtSittingType ").append($('<option/>', {
                        value: data,
                        text: $("#txtSittingType").val()
                    }));
                }
            });
    });
});