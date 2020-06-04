var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable(){
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
                                    <a href="/admin/category/upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
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

function Delete(id) {
    if (confirm("Are you sure you want to delete the category?")) {
        $.ajax({
            url: "/admin/category/Delete/" + id,
            method: "DELETE",
            success: function () {
                dataTable.api().ajax.reload();
            }
        })
    }
}

