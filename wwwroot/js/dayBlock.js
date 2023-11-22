﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Day_Block').DataTable({
        "ajax": {
            "url": "/api/dayblock",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "dayName", "width": "70%" },
            {
                "data": "daysBlockId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/DayBlocks/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
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
    });
}