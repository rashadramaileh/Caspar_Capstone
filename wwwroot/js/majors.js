var dataTable;
$(document).ready(function () {
    loadList();
})

function loadList() {
    dataTable = $('#DT_Majors').DataTable({
        "ajax": {
            "url": "/api/major",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            //should be lowercase for first letter, camelcase
            { "data": "majorName", "width": "70%" },
            //{ "data": "listPrice", render: $.fn.dataTable.render.number(',', '.', 2, '$'), "width": "15%" }, //see rendered documentation in datatables docs
            //{ "data": "category.name", "width": "15%" },
            //{ "data": "manufacturer.name", "width": "15%" },
            {
                "data": "majorID",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admins/Majors/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;"> 
                                <i class="far fa-edit"></i> Edit </a></div>`;

                },
                "width": "15%"
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
        "order": [[0, "asc"]]
    });
}