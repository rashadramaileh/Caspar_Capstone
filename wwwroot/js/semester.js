var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_Semester').DataTable({
        "ajax": {
            "url": "/api/semester",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            // Should not be capital
            //This needs to be changed VVVV
            { "data": "semesterName", "width": "15%" },
            { "data": "beginDate", "width": "10%" },
            { "data": "endDate", "width": "10%" },
            { "data": "registerDate", "width": "10%" },
            { "data": "semesterStatus.semesterStatusName", "width": "15%" },
            { "data": "semesterType.semesterName", "width": "10%" },
            {
                "data": "semesterId",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admins/Semesters/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>

                                    <a href="/Admins/Semesters/Fill?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Fill Sections </a>
                                    
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