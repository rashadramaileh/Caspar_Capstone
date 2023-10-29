var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_CourseSemester').DataTable({
        "ajax": {
            "url": "/api/courseSemester",
            "type": "GET",
            "data": { id: $('stid').id },
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            { "data": "course.courseName", "width": "30%" },
            { "data": "quantityTaught", "width": "30%" },
            {
                "data": {
                    "id": "semesterTypeId",
                    "sid": "courseSemesterId"
                },
                "render": function (row) {
                    return `<div class="text-center"> 
                                <a href="/Admins/CourseSemesters/Upsert?id=${row.id}&sid=${row.sid}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                        </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%",
    });

}