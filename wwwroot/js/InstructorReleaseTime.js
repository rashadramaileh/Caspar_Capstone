var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_ReleaseTime').DataTable({
        "ajax": {
            "url": "/api/instructorreleasetime",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            { "data": "instructor.name", "width": "70%" },
            { "data": "instructorrelease.releasetimeamount", "width": "70%" },
            { "data": "instructorrelease.releasetimeamount", "width": "70%" },
            { "data": "instructorrelease.releasetimeamount", "width": "70%" },
            { "data": "instructorrelease.releasenotes", "width": "70%" },
            {
                "data": "instructorReleaseId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admin/InstructorReleaseTimes/InstructorReleaseTime?id=${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> View </a>
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