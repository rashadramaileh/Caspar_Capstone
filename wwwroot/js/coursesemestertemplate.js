var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_CourseSemester').DataTable({
        "ajax": {
            "url": "/api/courseSemester",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            { "data": "course.courseName", "width": "30%" },
            { "data": "quantityTaught", "width": "30%" },
            {
                "data": "semesterTypeId",
                "courseSemesterid": "courseSemesterId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/CourseSemesters/Upsert?id=${courseSemesterid}&sid=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
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