var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#Student_Wishlist').DataTable({
        "ajax": {
            "url": "/api/studentwishlist",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "course.courseName", "width": "25%" },
            { "data": "courseType.courseTypeName",  "width": "15%" },
            { "data": "timeBlock.timeName", "width": "15%" },
            { "data": "campus.campusName", "width": "15%" },
            { "data": "semester.semesterName", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Students/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Students/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
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