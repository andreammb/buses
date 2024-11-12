
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblReservas").DataTable({
        "ajax": {
            "url": "/admin/reservas/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "asiento", "width": "20%" },
            { "data": "pago", "width": "5%" },
            { "data": "ruta.origen", "width": "30%" },
            { "data": "ruta.destino", "width": "30%" },
            { "data": "ruta.precio", "width": "30%" },
            { "data": "bus.horario", "width": "30%" },
            { "data": "usuario", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    console.log("data", data)
                    return `<div class="text-center">
                                <a href="/Admin/Reservas/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
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
                url: `/admin/reservas/Delete/${id}`,
                type: 'DELETE',
                id: id,
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload()
                        Swal.fire(
                            '¡Eliminado!',
                            'La reserva ha sido eliminada.',
                            'success'
                        );
                    }
                    else {
                        Swal.fire(
                            'Error',
                            'Hubo un problema al intentar eliminar la reserva.',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Error',
                        'Hubo un problema al intentar eliminar la reserva.',
                        'error'
                    );
                }
            });
        }
    });
}

`use strict`;
// select elements

const seatContainerEl = document.querySelector(`.seating-container`);
const countEl = document.getElementById(`count`);
const totalEl = document.getElementById(`total`);
const precio = document.getElementById("precio").dataset.precio;
const asientos = document.getElementById("asientos")
const busId = document.getElementById("busId")
const value = busId.dataset.bus
busId.value= parseInt(value)
console.log(busId)
// global variables
let seatCount = 0;

/*let ticketPrice = Number(Bus.);*/

// function
const totalPrice = function () {

    countEl.textContent = seatCount;
    totalEl.innerText = seatCount * precio;
};

// event listeners

seatContainerEl.addEventListener(`click`, function (e) {
    if (e.target.classList.contains(`seat`)) {
        if (!e.target.classList.contains(`sold`)) {
            e.target.classList.toggle(`selected`);
            const selectedSeatEl = document.querySelectorAll(`.row .seat.selected`);
            seatCount = selectedSeatEl.length;
            const ids = [""];
            asientos.value = seatCount;
            totalPrice();
        }
    }
});