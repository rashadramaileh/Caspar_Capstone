var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Modality').DataTable({
        "ajax": {
            "url": "/api/modality",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "modalityName", "width": "30%" },
            { "data": "modalityDescription", "width": "30%" },
            { "data": "additionalWishlistInfo", "width": "10%" },
            {
                "data": "modalityId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/ManageModality/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                    
                                <a href="/Admins/ManageModality/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
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