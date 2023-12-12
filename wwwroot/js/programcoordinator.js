var dataTable;
var id;

$(document).ready(function () {
    var url_string = window.location.href; // www.test.com?filename=test
    var url = new URL(url_string);
    id = url.searchParams.get("id");
    loadList();
});

function loadList() {
    dataTable = $('#DT_Sections').DataTable({
        "ajax": {
            "url": "/api/programcoordinator",
            "type": "GET",
            "data": { "id": id },
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            { "data": "applicationUser.fullName", "width": "5%" },
            { "data": "course.fullName"},
            { "data": "crn", "width": "5%" },
            { "data": "modality.modalityName", "width": "5%" },
            { "data": "meetingTime.meetingTimeName", "width": "5%" },
            { "data": "dayBlock.dayName", "width": "5%" },
            { "data": "classroom.roomNumber", "width": "5%" },
            { "data": "maxEnrollment", "width": "5%" },
            { "data": "course.creditHours", "width": "5%" },
            { "data": "partOfTerm.partOfTermName", "width": "5%" },
            { "data": "campus.campusName", "width": "5%" },
            { "data": "payModel.payType", "width": "5%" },
            { "data": "whoPays.whoPaysName", "width": "5%" },
            { "data": "sectionStatus.statusName", "width": "5%" },
            { "data": "notes", "width": "5%" },
            { "data": "semester.semesterName", "width": "5%" },
            { "data": "firstWeekEnroll", "width": "5%" },
            { "data": "thirdWeekEnroll", "width": "5%" },
            {
                "data": "sectionId",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/ProgramCoordinator/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                    <i class="far fa-edit"></i> Edit </a></div>`;
                }, "width": "15%"
            },
            {
                "data": "isActive",
                "render": function (data) {
                    if (data == 1) {
                        return `<div class="text-center"> 
                            <button type="button" class="btn btn-success text-white" style="cursor:pointer; width: 100px;" disabled>
                               Active </button>
                        </div>`;
                    } else {
                        return `<div class="text-center"> 
                           <button type="button" class="btn btn-warning text-white" style="cursor:pointer; width: 100px;" disabled>
                               Inactive </button>
                        </div>`;
                    }
                }, "width": "15%"
            },
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%",
    });
}
