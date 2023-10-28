﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_SemesterStatus').DataTable({
        "ajax": {
            "url": "/api/semesterstatus",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "semesterStatusName", "width": "30%" },
            { "data": "semesterStatusDescription", "width": "40%" },
            {
                "data": "semesterStatusID",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/SemestersStatus/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Admins/SemestersStatus/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
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