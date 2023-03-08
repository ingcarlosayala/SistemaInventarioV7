let datatable;

$(document).ready(function () {
    loadDataTable();
});

const loadDataTable = () => {
    datatable = $("#tblDatos").DataTable({
        "ajax": {
            "url": "/Admin/Almacen/ObtenerTodos"
        },
        "columns":[
            {"data": "nombre", "width": "40%"},
            {"data": "descripcion", "width": "40%"},
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    } else {
                        return "Inactivo";
                    }
                },"width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Almacen/upSert/${data}" class="btn btn-success btn-sm text-white">
                                    <i class="bi bi-pencil-square"></i>
                                </a>
                                <a onclick=Delete("/Admin/Almacen/delete/${data}") class="btn btn-danger btn-sm"><i class="bi bi-trash"></i> </a>
                            </div>`;
                },"width": "20%"
            }
        ]
    });
}
function Delete(url) {

    Swal.fire({
        title: 'Estas Seguro?',
        text: "Este Archivo no se podra revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}