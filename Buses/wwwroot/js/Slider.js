
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblSliders").DataTable({
        "ajax": {
            "url": "/admin/sliders/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "nombre", "width": "20%" },
            {
                "data": "estado",
                "render": function (estadoActual) {
                    if (estadoActual == true) {
                        return "Activo"
                    } else {
                        return "Inactivo"
                    }
                }, "width": "15%"
            },
            {
                "data": "urlImagen",
                "render": function (imagen) {
                    return `<img src="../${imagen}" width="120">`
                }, "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    console.log("data", data)
                    return `<div class="text-center">
                                <a href="/Admin/Sliders/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                <i class="fa-solid fa-pen-to-square"></i>&nbsp;Editar
                                </a>
                           
                                <div class="text-center">
                                <a onclick=Delete("/Admin/Sliders/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
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
function Delete(url) {
    new Swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
    }).then((result) => {
        console.log("url", url)
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        //$('#tblRutas').DataTable().row(`#row_${id}`).remove().draw();
                        dataTable.ajax.reload()
                        Swal.fire(
                            '¡Eliminado!',
                            'La promoción ha sido eliminada.',
                            'success'
                        );
                    }
                    else {
                        Swal.fire(
                            'Error',
                            'Hubo un problema al intentar eliminar la promoción.',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Error',
                        'Hubo un problema al intentar eliminar la promoción.',
                        'error'
                    );
                }
            });
        }
    });
}