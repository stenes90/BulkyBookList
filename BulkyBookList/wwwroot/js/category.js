var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable(){
    $("#tblData").dataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
            "columns": [
                { "data": "name" },
                {
                    "data": "id",
                    "render": function (data) {
                        return `
                                <div class="text-center">
                                    <a href="/admin/category/upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                        <i class="fas fa-edit"></i>
                                    </a>
                                    <a href="/admin/category/upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
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