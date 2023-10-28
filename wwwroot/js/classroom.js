﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Classroom').DataTable({
        "ajax": {
            "url": "/api/classroom",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "roomNumber", "width": "23%" },
            { "data": "capacity", "width": "23%" },
            { "data": "building.buildingName", "width": "23" },
            {
                "data": "classroomId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/ManageClassrooms/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Admins/ManageClassrooms/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
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