var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Classroom').DataTable({
        "ajax": {
            "url": "/api/classrooms",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "roomNumber", "width": "17.5%" },
            { "data": "capacity", "width": "17.5%" },
            { "data": "roomConfig.roomConfig", "width": "17.5%" },
            { "data": "building.building", "width": "17.5%" },
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