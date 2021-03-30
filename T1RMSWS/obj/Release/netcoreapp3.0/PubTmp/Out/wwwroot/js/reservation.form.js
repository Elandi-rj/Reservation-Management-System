$(document).ready(function () {
    //Get starting slots
    $.get("/ApiReservation/GetStartSlots",
        {
            sittingId: $("#txtSittingId").val(),
            guests: $("#txtGuests").val(),
        },
        function (data, status) {
            if (status == "success") {
                $('input.timepicker').timepicker({
                    minTime: $("#txtReservationStart").val(),
                    maxTime: $("#txtReservationEnd").val(),
                    disableTimeRanges: data
                });
            }
        });
    //get duration for that slot.
    var durationClone = $('#durationExample').clone();
    $('#durationExample').hide();
    $('#lblDuration').hide();
    
    $('input.timepicker').on('changeTime', function () {
        var st = $("#txtTime").val();
        $.get("/ApiReservation/GetDuration",
            {
                sittingId: $("#txtSittingId").val(),
                guests: $("#txtGuests").val(),
                startTime: st
            },
            function (data, status) {
                if (status == "success") {
                    $('#durationExample').replaceWith(durationClone.clone());
                    $('#lblDuration').show();
                    $('#durationExample').timepicker({
                        minTime: data[1],
                        maxTime: data[0],
                        showDuration: true
                    });
                }
            });
        
    });
    
    //submission
    $("#btnSubmit").click(function () {
        var reservation = {
            sittingId: $("#txtSittingId").val(),
            customerId: $("#txtCustomerId").val(),
            reservationTypeId: $("#txtSource").val() - 0,
            guests: $("#txtGuests").val(),
            duration: $("#durationExample").val(),
            note: $("#txtNote").val(),
            startTime: $("#txtTime").val(),
            customer: {
                Id: $("#txtCustomerDotId").val(),
                UserId: $("#txtUserId").val(),
                FirstName: $("#txtFname").val(),
                LastName: $("#txtLname").val(),
                PhoneNumber: $("#txtPhone").val(),
                Email: $("#txtEmail").val()
            }
        };

        $.post("/ApiReservation/Submit",
            {
                r: reservation
            },
            function (data, status) {
                if (status == "success") {
                    if (data.valid) {
                        window.location.replace("/Reservation/Confirmation");
                    }
                    else {
                        $("#lblMessage").html(data.error);
                        $("#lblMessage").show();
                    }
                }
            });
    });
});