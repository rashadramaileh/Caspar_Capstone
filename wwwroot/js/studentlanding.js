var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_StudentLanding').DataTable({
        "ajax": {
            "url": "/api/studentlanding",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            { "data": "course.prefix" + "course.number" + "course.name", "width": "70%" },
            { "data": "modality.modalityname", "width": "70%" },
            { "data": "campus.campusname", "width": "70%" },
            { "data": "timeblock.timename", "width": "70%" },
            {
                "data": "studentWishlistId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Students/Courses/WishlistDetails?id=${data}" class="btn btn-primary text-white" style="cursor:pointer; width: 100px;">
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