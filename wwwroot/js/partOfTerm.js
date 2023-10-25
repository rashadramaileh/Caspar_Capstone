﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Part_Of_Term').DataTable({
        "ajax": {
            "url": "/api/partofterm",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "partOfTermName", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/PartOfTerms/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Admins/PartOfTerms/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
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