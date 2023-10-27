var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Course').DataTable({
        "ajax": {
            "url": "/api/course",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "coursePrefix", "width": "10%" },
            { "data": "courseNumber", "width": "10%" },
            { "data": "courseName", "width": "10%" },
            { "data": "courseDesc", "width": "10%" },
            { "data": "creditHours", "width": "10%" },
            { "data": "uniProgram.programName", "width": "10%" },
            { "data": "courseType.courseTypeName", "width": "10%" },
            {
                "data": "courseId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/Courses/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Admins/Courses/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-trash-alt"></i> Delete </a>
                        </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%",
        "order": [[2, "asc"]]
    });
}