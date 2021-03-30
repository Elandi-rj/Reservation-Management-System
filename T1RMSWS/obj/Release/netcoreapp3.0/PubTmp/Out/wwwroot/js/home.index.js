$(document).ready(function () {
    $("#btnGuests").click(function () {
        var txtGuests = $("#txtGuest").val() - 0;
        if (txtGuests == 0) {
            txtGuests = 1;
        }
        
    $.post("/Sittings/GetList",
        {
            guests: txtGuests
        },
        function (data, status) {
            if (status == "success") {
                $('#mycalendar').empty();
                $('#mycalendar').monthly({
                    mode: 'event',
                    dataType: 'json',
                    events: data,
                    weekStart: 1,	// Monday
                    stylePast: true,
                });
            }
        });
});
});
