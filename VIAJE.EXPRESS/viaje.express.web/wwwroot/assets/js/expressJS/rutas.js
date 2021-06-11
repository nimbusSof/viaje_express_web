import { url } from './env.js';
var datatable;
var token;
var id_usuario_rol;
var id_cooperativa;
const url_ruta = `${url}/Ruta`
var map;
var consult = {
    "offset": 0,
    "limit": 5,
    "columna": '',
    "nombre": '',
    "sort": ''
}
var ruta = {
    'id_cooperativa': '',
    'nombre_ruta': '',
    'origen_lat': '',
    'origen_lng': '',
    'destino_lat': '',
    'destino_lng': '',
    'distancia': '',
    'tiempo': '',
    'monto': '',
    'activo': '',
    'created_by': '',
    'modified_by': ''
};

$(function () {
    token = localStorage.getItem('id_token');
    id_usuario_rol = localStorage.getItem('id_usuario_rol');
    id_cooperativa = localStorage.getItem('id_cooperativa');
    obtenerRutas();
    obtenerCooperativa();
});


function obtenerRutas() {
    $.ajax({
        headers: _headers(token),
        url: `${url_ruta}/Listar/` + id_cooperativa,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            datatable = $("#tblRutas").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblRutas').DataTable({
                    ordering: false,
                    responsive: true,
                    autoWidth: false,
                    bFilter: false,
                    lengthChange: false,
                    bInfo: false,
                    data: data['data'],
                    columns: [
                        { data: "id_ruta" },
                        { data: "nombre_ruta" },
                        {
                            data: "distancia", "render": function (data) {
                                return data + " km"
                            }
                        },
                        {
                            data: "tiempo", "render": function (data) {
                                return data + ' min';
                            }
                        },
                        {
                            data: "monto", "render": function (data) {
                                return "$" + data;
                            }
                        },
                        {
                            data: "activo", "render": function (data) {
                                if (data) {
                                    return "Activo"
                                } else {
                                    return "Desactivo"
                                }
                            }
                        },
                        {
                            data: "id_ruta", "render": function (data) {
                                var id = data;
                                return '<button type="button"  name="edit" id="' + id + '"  class="edit btn btn-primary btn-sm"> <i class="fa fa-edit fa-lg"></i></button> <button type="button"   name="delete" id="' + id + '" class="delete btn btn-danger btn-sm"><i class="fa fa-trash fa-lg"></i> </button>';
                            }
                        }
                    ]
                });
            } else {
                clearTable('#tblRutas');
            }

        },
        error: function (err) {
            console.log(err);
        }
    });
}


$('#crear_ruta').click(function () {
    $('.modal-title').text('Agregar nueva ruta');
    $('#act').hide();
    $('#action_button').val('Add');
    $('#action').val('Add');
    $('#form_result').html('');
    $('#formulario_ruta').trigger("reset");
    $('#formModal').modal('show');
    $('.error').hide();
});


$('#formulario_ruta').on('submit', function (event) {
    $('.error').hide();
    var nombre = $("input#nombre").val();
    if (nombre == "") {
        $("label#nombre_error").show();
        $("input#nombre").focus();
        return false;
    }
    var distancia = $("input#distancia").val();
    if (distancia == "") {
        $("label#distancia_error").show();
        $("input#distancia").focus();
        return false;
    }
    var tiempo = $("input#tiempo").val();
    if (tiempo == "") {
        $("label#tiempo_error").show();
        $("input#tiempo").focus();
        return false;
    }
    var monto = $("input#monto").val();
    if (monto == "") {
        $("label#monto_error").show();
        $("input#monto").focus();
        return false;
    }
    var activo = document.getElementById("activo");
    ruta['id_cooperativa'] = id_cooperativa;
    ruta['nombre_ruta'] = nombre;
    ruta['tiempo'] = tiempo;
    ruta['monto'] = monto;
    ruta['distancia'] = distancia;
    ruta['activo'] = activo.checked;
    ruta['created_by'] = id_usuario_rol;
    ruta['modified_by'] = id_usuario_rol;
    let id_ruta = $('#hidden_id').val();
    let type_method = '';
    var action_url = '';
    if ($('#action').val() == 'Add') {
        action_url = url_ruta;
        type_method = 'POST'
    }
    if ($('#action').val() == 'Edit') {
        action_url = `${url_ruta}/${id_ruta}`;
        type_method = 'PUT'
    }
    $.ajax({
        headers: _headers(token),
        url: action_url,
        type: type_method,
        data: JSON.stringify(ruta),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModal').modal('hide');
                obtenerRutas();
                mensajeExito(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Error al ingresar los datos de la ruta');
        }
    });
    return false;
});


$(document).on('click', '.edit', function () {
    $('.error').hide();
    $('#act').show();
    var id = $(this).attr('id');
    $('#form_result').html('');
    $.ajax({
        headers: _headers(token),
        url: `${url_ruta}/${id}`,
        dataType: "json",
        success: function (resp) {
            $('#nombre').val(resp.data.nombre_ruta);
            $('#distancia').val(resp.data.distancia);
            $('#tiempo').val(resp.data.tiempo);
            $('#monto').val(resp.data.monto);
            id_cooperativa = resp.data.id_cooperativa;
            document.getElementById("activo").checked = resp.data.activo;
            ruta['origen_lat'] = resp.data.origen_lat;
            ruta['origen_lng'] = resp.data.origen_lng;
            ruta['destino_lat'] = resp.data.destino_lat;
            ruta['destino_lng'] = resp.data.destino_lng;
            $('#hidden_id').val(id);
            $('.modal-title').text('Editar ruta');
            $('#action_button').val('Edit');
            $('#action').val('Edit');
            $('#formModal').modal('show');
        }
    });
});




$(document).on('click', '.delete', function () {
    let ruta_id = $(this).attr('id');
    swal({
        title: "¿Esta seguro de eliminar?",
        text: "Al eliminar la ruta no se mostrara en el registro",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar!",
        closeOnConfirm: false
    },
        function () {
            eliminarRuta(ruta_id);
        });
});


function eliminarRuta(idruta) {
    $.ajax({
        headers: _headers(token),
        url: `${url_ruta}/${idruta}`,
        type: 'DELETE',
        dataType: "json",
        data: JSON.stringify({ "deleted_by": id_usuario_rol }),
        success: function (data) {
            if (data.exito) {
                mensajeExito(data.mensaje);
                obtenerRutas();
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Transaccion procesada correctamente');
        }
    });
}


function obtenerCooperativa() {
    var m;
    $.ajax({
        headers: _headers(token),
        url: `${url}/Cooperativa/${id_cooperativa}`,
        dataType: "json",
        success: function (data) {
            //lat_c = data.data.lat;
            //lng_c = data.data.lng;

        }
    });
}


//mapoa
map = L.map('mapr').setView([0.04104004628590023, -78.14285258539633], 16);
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

var llenar = L.Routing.control({
    show: false,
    //addWaypoints: false,
    // draggableWaypoints: false,
    //fitSelectedRoutes: false,
    waypoints: [
        L.latLng(0.047103, -78.142129),
        L.latLng(0.038682, -78.143966)
    ],
    language: 'es'
}).addTo(map);

// Comment out the below code to see the difference.
$('#formModal').on('shown.bs.modal', function () {
    map.invalidateSize();
});

$('#llenar_campos').click(function () {
    console.log(llenar['_selectedRoute']);
    /*let nom = llenar['_selectedRoute'].name;
    var res = nom.split(",");
    $('#origen').val(res[0]);
    $('#destino').val(res[1]);*/
    ruta['origen_lat'] = llenar['_selectedRoute'].waypoints[0].latLng.lat;
    ruta['origen_lng'] = llenar['_selectedRoute'].waypoints[0].latLng.lng;
    ruta['destino_lat'] = llenar['_selectedRoute'].waypoints[1].latLng.lat;
    ruta['destino_lng'] = llenar['_selectedRoute'].waypoints[1].latLng.lng;

    $('#nombre').val(llenar['_selectedRoute'].name);
    let distan = llenar['_selectedRoute'].summary.totalDistance / 1000;
    // $('#distancia').val(distan + ' km');
    $('#distancia').val(distan);
    ruta['distancia'] = distan;
    let tiem = llenar['_selectedRoute'].summary.totalTime / 60;
    let part_entera = Math.trunc(tiem);
    let part_decimal = tiem - part_entera;
    if (part_decimal > 0.49) {
        part_entera++;
    } else if (part_entera == 0) {
        part_entera = tiem;
    }
    // $('#tiempo').val(part_entera + ' min');
    $('#tiempo').val(part_entera);
    ruta['tiempo'] = part_entera;


});
const selectlimitar = document.querySelector('.limitar');

const colnombre = document.querySelector('.colnombre');
const coldistancia = document.querySelector('.coldistancia');
const colmonto = document.querySelector('.colmonto');
const coltiempo = document.querySelector('.coltiempo');
const colactivo = document.querySelector('.colactivo');

selectlimitar.addEventListener('change', (event) => {
    consult['limit'] = event.target.value;
    obtenerRutas();
});

colnombre.addEventListener('input', (event) => {
    consult['columna'] = 'r.nombre_ruta';
    consult['nombre'] = event.srcElement.value;
    obtenerRutas();
});
coldistancia.addEventListener('input', (event) => {
    consult['columna'] = 'r.distancia';
    consult['nombre'] = event.srcElement.value;
    obtenerRutas();
});
colmonto.addEventListener('input', (event) => {
    consult['columna'] = 'r.monto';
    consult['nombre'] = event.srcElement.value;
    obtenerRutas();
});
coltiempo.addEventListener('input', (event) => {
    consult['columna'] = 'r.tiempo';
    consult['nombre'] = event.srcElement.value;
    obtenerRutas();
});
colactivo.addEventListener('change', (event) => {
    consult['columna'] = 'r.activo';
    consult['nombre'] = event.target.value;
    obtenerRutas();

});