﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_SemesterType').DataTable({
        "ajax": {
            "url": "/api/courseSemester",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "semesterName", "width": "70%" },
            {
                "data": "semesterTypeId",
                "coursesemesterid": "courseSemesterId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/CourseSemester/TermCourse?id=${coursesemesterid}cs=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> View & Manage </a>
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