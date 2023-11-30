var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Sections').DataTable({
        "ajax": {
            "url": "/api/building",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "applicationUser.fullName", "width": "5%" },
            { "data": "course.courseName", "width": "5%" },
            { "data": "cRN", "width": "5%" },
            { "data": "modality.modalityName", "width": "5%" },
            { "data": "meetingTime.meetingTimeName", "width": "5%" },
            { "data": "dayBlock.dayName", "width": "5%" },
            { "data": "classroom.roomNumber", "width": "5%" },
            { "data": "maxEnrollment", "width": "5%" },
            { "data": "course.creditHours", "width": "5%" },
            { "data": "partOfTerm.partOfTermName", "width": "5%" },
            { "data": "campus.campusName", "width": "5%" },
            { "data": "payModel.payModelName", "width": "5%" },
            { "data": "whoPays.whoPaysName", "width": "5%" },
            { "data": "sectionStatus.statusName", "width": "5%" },
            { "data": "notes", "width": "5%" },
            { "data": "semester.semesterName", "width": "5%" },
            { "data": "firstWeekEnroll", "width": "5%" },
            { "data": "thirdWeekEnroll", "width": "5%" },
            {
                "data": "isActive",
                "render": function (data) {

                    if (data == 1) {
                        return `<div class="text-center"> 
                            
                            <button type="button" class="btn btn-success text-white" style="cursor:pointer; width: 100px;" disabled>
                               Active </button>
                        </div>`
                    } else {
                        return `<div class="text-center"> 
                            
                           <button type="button" class="btn btn-warning text-white" style="cursor:pointer; width: 100px;" disabled>
                               Inactive </button>
                        </div>`

                    }

                }, "width": "15%"

            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%",
    });

    dataTable.on('click', 'tbody td:not(:first-child)', function (e) {
        editor.inline(this);
    });
}

