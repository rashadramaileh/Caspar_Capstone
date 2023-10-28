﻿var dataTable;

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
            //This needs to be changed VVVV
            { "data": "semester.semesterName", "width": "70%" },
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