$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $("#tblData").dataTable({
        "ajax": {
            "url": "/Admin/CoverType/GetAll"
        },
        "columns": [
            { "data": "name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                    <a href="/admin/covertype/upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                        <i class="fas fa-edit"></i>
                                    </a>
                                    <a onclick=Delete("${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                        <i class="fas fa-trash-alt"></i>
                                    </a>
                                </div>
                                
                                `;
                }
            }
        ]
    }
    );
}