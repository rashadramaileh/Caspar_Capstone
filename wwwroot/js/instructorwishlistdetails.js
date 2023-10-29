var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_InstructorWishlistDetails').DataTable({
        "ajax": {
            "url": "/api/instructorwishlistdetails",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "course.courseName", "width": "30%" },
            { "data": "instructorNotes", "width": "35%" },
            { "data": "instructorWishlistId", "width": "5%" },
            {
                "data": "instructorWishlistDetailsId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/Semesters/Upsert?id=${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> View </a>

                                <a href="/Admins/Semesters/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Admins/Semesters/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-trash-alt"></i> Delete </a>
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