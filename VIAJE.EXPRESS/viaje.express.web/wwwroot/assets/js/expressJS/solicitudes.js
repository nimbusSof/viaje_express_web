import { url } from './env.js';
//import { ruta_solicitud, end_point_vehiculo, db } from './firebas.js';
var id_persona_rol = localStorage.getItem('id_usuario_rol');
var id_cooperativa = localStorage.getItem('id_cooperativa');
var token = localStorage.getItem('id_token');
var datatable;

var consult = {
    "offset": 0,
    "limit": 500,
    "columna": '',
    "nombre": '',
    "sort": ''
}
$(function () {
    obtenerSolicitudes();
});

function obtenerSolicitudes() {
    $.ajax({
        headers: _headers(token),
        url: `${url}/AgendarSolicitudCliente/Listar/${id_cooperativa}`,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            console.log(data);
            datatable = $("#tblSolicitudes").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblSolicitudes').DataTable({
                    ordering: false,
                    responsive: true,
                    autoWidth: false,
                    bFilter: false,
                    lengthChange: false,
                    bInfo: false,
                    data: data.data,
                    columns: [
                        { data: "id_agendar_solicitud_cliente" },
                        { data: "cedula_chofer" },
                        { data: "nombre_chofer" },
                        { data: "apellido_chofer" },
                        { data: "placa" },
                        { data: "tipo_solicitud" },
                        { data: "tipo_carrera" },
                        { data: "carrera_ejecucion" },
                        { data: "estado_solicitud" },
                        { data: "fecha_solicitud", "render": function (fecha) { return formatDate(fecha) } }
                        //{
                        //    data: "id_agendar_solicitud_cliente", "render": function (id) {
                        //        return '<button type="button" id="' + id + '" class="ver_solicitud btn btn-success btn-sm"><i class="fa fa-eye fa-lg"></i> Ver</button>';
                        //    }
                        //}
                    ]
                });
            } else {
                clearTable('#tblSolicitudes');
            }

        },
        error: function (err) {
            console.log(err);
        }
    });
}