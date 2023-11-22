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
            { "data": "coursePrefix", "width": "15%" },
            { "data": "courseNumber", "width": "15%" },
            { "data": "courseName", "width": "10%" },
            { "data": "courseDesc", "width": "10%" },
            { "data": "creditHours", "width": "10%" },
            { "data": "uniProgram.programName", "width": "10%" },
            {
                "data": "courseId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/Courses/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                        </div>`;
                }, "width": "15%"
            },
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
        "order": [[2, "asc"]]
    });
}