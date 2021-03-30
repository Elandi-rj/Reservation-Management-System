$(function () {


    var editableTable = new BSTable("example", {
        editableColumns: "-1",
        $addButton: $('#new-row-button'),
        onEdit: function (el) {
            var row = el[0];
            var arr = row.cells;
            console.log(el[0]);
            console.log(arr.sid);
            console.log(arr.selectStatus.children[0].value);
            console.log(arr.selectType.children[0].value);
            var data =
            {
                Id: arr.rid.innerText,
                SittingId: arr.sid.innerText,
                CustomerId: arr.cid.innerText,
                ReservationTypeId: arr.selectType.children[0].value,
                Guests: arr.g.innerText,
                Duration: arr.d.innerText,
                Note: arr.n.innerText,
                ReservationStatusId: arr.selectStatus.children[0].value,
                StartTime: arr.st.innerText
            };
            $.post("/staff/reservation/edit", { id: arr.rid.innerText, reservation: data }, function () { alert('Successfully Edited'); });
        },
        advanced: {
            columnLabel: 'Actions',
            buttonHTML: `<div class="btn-group pull-right">
                <button id="bEdit" type="button" class="btn btn-sm btn-default">
                  <span class="fa fa-edit" > </span>
                </button>
                <button id="bDel" type="button" class="btn btn-sm btn-default">
                  <span class="fa fa-trash" > </span>
                </button>
                <button id="bAcep" type="button" class="btn btn-sm btn-default" style="display:none;">
                  <span class="fa fa-check-circle" > </span>
                </button>
                <button id="bCanc" type="button" class="btn btn-sm btn-default" style="display:none;">
                  <span class="fa fa-times-circle" > </span>
                </button>
              </div>`
        }
    });
    editableTable.init();

});