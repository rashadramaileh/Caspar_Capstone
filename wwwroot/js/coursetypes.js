﻿var dataTable;
$(document).ready(function () {
    loadList();
})

function loadList() {
    dataTable = $('#DT_CourseType').DataTable({
        "ajax": {
            "url": "/api/coursetype",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            //should be lowercase for first letter, camelcase
            { "data": "courseTypeName", "width": "25%" },
            //{ "data": "listPrice", render: $.fn.dataTable.render.number(',', '.', 2, '$'), "width": "15%" }, //see rendered documentation in datatables docs
            //{ "data": "category.name", "width": "15%" },
            //{ "data": "manufacturer.name", "width": "15%" },
            {
                "data": "courseTypeId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admins/CourseTypes/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;"> 
                                <i class="far fa-edit"></i> Edit </a>

                                <a href="/Admins/CourseTypes/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width:100px;"> 
                                <i class="far fa-trash-alt"></i> Delete </a></div>`;

                },
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%",
        "order": [[0, "asc"]]
    });
}