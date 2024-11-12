
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblRutas").DataTable({
        "ajax": {
            "url": "/admin/rutas/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "origen", "width": "10%" },
            { "data": "destino", "width": "10%" },
            { "data": "busesDisponibles", "width": "5%" },
            { "data": "horarios", "width": "30%" },
            { "data": "precio", "width": "5%" },
            { "data": "id", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    console.log("data", data)
                    return `<div class="text-center">
                                <a href="/Admin/Rutas/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                <i class="fa-solid fa-pen-to-square"></i>&nbsp;Editar
                                </a>
                           
                                <div class="text-center">
                                <a onclick=Delete("${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                <i class="fa-solid fa-trash"></i>&nbsp;Eliminar
                                </a>
                            </div>
                            `;
                }, "widht":"35%"
            },
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"

    });
}
function Delete(id) {
    new Swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
    }).then((result) => {
        console.log("url", id)
        if (result.isConfirmed) {
            $.ajax({
                url: `/admin/rutas/Delete/${id}`,
                type: 'DELETE',
                id: id,
                success: function (data) {
                    if (data.success) {
                        //$('#tblRutas').DataTable().row(`#row_${id}`).remove().draw();
                        dataTable.ajax.reload()
                        Swal.fire(
                            '¡Eliminado!',
                            'La ruta ha sido eliminada.',
                            'success'
                        );
                    }
                    else {
                        Swal.fire(
                            'Error',
                            'Hubo un problema al intentar eliminar la ruta.',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Error',
                        'Hubo un problema al intentar eliminar la ruta.',
                        'error'
                    );
                }
            });
        }
    });
}