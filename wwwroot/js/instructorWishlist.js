var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#Instructor_Wishlist').DataTable({
        "ajax": {
            "url": "/api/instructorwishlist",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "ranking.name", "width": "15%" },
            { "data": "course.name", "width": "25%" },
            { "data": "coursetype.name", "width": "15%" },
            { "data": "timeblock.name", "width": "15%" },
            { "data": "dayblock.name", "width": "15%" },
            { "data": "campus.name", "width": "15%" },
            { "data": "semester.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Instructors/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Instructors/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
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