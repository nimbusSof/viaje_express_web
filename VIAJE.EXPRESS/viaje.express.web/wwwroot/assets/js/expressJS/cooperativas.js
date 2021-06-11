import { url } from './env.js';
var datatable;
var id_usuario_rol;
var map;
var token;
const url_modulo_coop = `${url}/Cooperativa`;
var consult = {
    "offset": 0,
    "limit": 5,
    "columna": '',
    "nombre": '',
    "sort": ''
}

$(function () {
    id_usuario_rol = localStorage.getItem('id_usuario_rol');
    token = localStorage.getItem('id_token');
    obtenerCooperativa();
});

function numadministradores(data, id) {
    var num;
    data.forEach((coop) => {
        if (coop.id_cooperativa == id) {
            num = coop.administradores;
        }
    });
    return num;
}

function obtenerCooperativa() {
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo_coop}/Listar`,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            datatable = $("#tblCoop").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblCoop').DataTable({
                    ordering: false,
                    responsive: true,
                    autoWidth: false,
                    bFilter: false,
                    lengthChange: false,
                    bInfo: false,
                    data: data.data,
                    columns: [
                        { data: "id_cooperativa" },
                        { data: "nombre" },
                        { data: "telefono" },
                        { data: "direccion" },
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
                            data: "id_cooperativa", "render": function (idcoop) {
                                var id = idcoop;
                                var administradores = numadministradores(data['data'], id)
                                return '<button type="button" name="admincoop" id="' + id + '" class="admincoop btn btn-success btn-sm">' + administradores + ' <i class="fa fa-user-plus fa-lg"></i> </button>';
                            }
                        }, {
                            data: "id_cooperativa", "render": function (data) {
                                var id = data;
                                return '<button type="button"  name="edit" id="' + id + '"  class="edit btn btn-primary btn-sm"> <i class="fa fa-edit fa-lg"></i></button> <button type="button"   name="delete" id="' + id + '" class="delete btn btn-danger btn-sm"><i class="fa fa-trash fa-lg"></i> </button>';
                            }
                        }
                    ]
                });
            } else {
                clearTable('#tblCoop');
            }

        },
        error: function (err) {
            console.log(err);
        }
    });
}


$('#crear_cooperativa').click(function () {
    $('.modal-title').text('Agregar nueva Cooperativa');
    $('#act').hide();
    $('#action_button').val('Add');
    $('#action').val('Add');
    $('#form_result').html('');
    $('#formulario_cooperativa').trigger("reset");
    $('#formModal').modal('show');
    $('.error').hide();
});


$('#formulario_cooperativa').on('submit', function (event) {
    $('.error').hide();
    var nombre = $("input#nombre").val();
    if (nombre == "") {
        $("label#nombre_error").show();
        $("input#nombre").focus();
        return false;
    }
    var direccion = $("input#direccion").val();
    if (direccion == "") {
        $("label#direccion_error").show();
        $("input#direccion").focus();
        return false;
    }
    var telefono = $("input#telefono").val();
    if (telefono == "") {
        $("label#telefono_error").show();
        $("input#telefono").focus();
        return false;
    }
    var lat = $("input#lat").val();
    if (lat == "") {
        $("label#lat_error").show();
        $("input#lat").focus();
        return false;
    }
    var lng = $("input#lng").val();
    if (lng == "") {
        $("label#lng_error").show();
        $("input#lng").focus();
        return false;
    }
    var activo = document.getElementById("activo");

    var cooperativa = {
        "id_persona_rol_admin": id_usuario_rol,
        'nombre': nombre,
        'direccion': direccion,
        'telefono': telefono,
        'lat': lat,
        'lng': lng,
        "activo": activo.checked,
        "created_by": id_usuario_rol,
    };
    let id_coop = $('#hidden_id').val();
    let type_method = '';
    var action_url = '';
    if ($('#action').val() == 'Add') {
        action_url = url_modulo_coop;
        type_method = 'POST'
        cooperativa['activo'] = true;
    }
    if ($('#action').val() == 'Edit') {
        action_url = `${url_modulo_coop}/${id_coop}`;
        type_method = 'PUT'
    }
    $.ajax({
        headers: _headers(token),
        url: action_url,
        type: type_method,
        data: JSON.stringify(cooperativa),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModal').modal('hide');
                mensajeExito(data.mensaje);
                obtenerCooperativa();
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Error al ingresar los datos de coopertaiva');
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
        url: `${url_modulo_coop}/${id}`,
        dataType: "json",
        success: function (resp) {
            $('#nombre').val(resp.data.nombre);
            $('#direccion').val(resp.data.direccion);
            $('#telefono').val(resp.data.telefono);
            $('#lat').val(resp.data.lat);
            $('#lng').val(resp.data.lng);
            document.getElementById("activo").checked = resp.data.activo;
            $('#hidden_id').val(id);
            $('.modal-title').text('Editar cooperativa');
            $('#action_button').val('Edit');
            $('#action').val('Edit');
            $('#formModal').modal('show');
        }
    });
});




$(document).on('click', '.delete', function () {
    let coop_id = $(this).attr('id');
    swal({
        title: "¿Esta seguro de eliminar?",
        text: "Al eliminar la cooperativa tambien se eliminara todas sus dependencias como administradores, operadores, vehiculos, etc.",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar!",
        closeOnConfirm: false
    },
        function () {
            eliminarCooperativa(coop_id);
        });
});


function eliminarCooperativa(idcoop) {
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo_coop}/${idcoop}`,
        type: 'DELETE',
        dataType: "json",
        data: JSON.stringify({ "deleted_by": id_usuario_rol }),
        success: function (data) {
            if (data.exito) {
                mensajeExito(data.mensaje);
                obtenerCooperativa();
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Transaccion procesada correctamente');
        }
    });
}




$(document).on('click', '.admincoop', function () {
    $('.error').hide();
    var id = $(this).attr('id');
    $('#form_resultadmin').html('');
    $('.modal-title').text('Agregar Nuevo Administrador Cooperativa');
    $('#action_buttonadmin').val('Add');
    $('#hidden_id_admin').val(id);
    $('#form_resultadmin').html('');
    $('#formModaladmin').modal('show');
    $('.error').hide();
});


$('#formulario_adminCoop').on('submit', function (event) {
    $('.error').hide();
    let id_coop = $('#hidden_id_admin').val();
    var cedula = $("input#cedula").val();
    if (cedula == "") {
        $("label#cedula_error").show();
        $("input#cedula").focus();
        return false;
    }
    var nombres = $("input#nombres").val();
    if (nombres == "") {
        $("label#nombres_error").show();
        $("input#nombres").focus();
        return false;
    }
    var apellidos = $("input#apellidos").val();
    if (apellidos == "") {
        $("label#apellidos_error").show();
        $("input#apellidos").focus();
        return false;
    }
    var fechan = $("input#fechan").val();
    if (fechan == "") {
        $("label#fechan_error").show();
        $("input#fechan").focus();
        return false;
    }
    var telefonoa = $("input#telefonoa").val();
    if (telefonoa == "") {
        $("label#telefonoa_error").show();
        $("input#telefonoa").focus();
        return false;
    }
    var genero = $("select#genero").val();
    if (genero == "") {
        $("label#genero_error").show();
        $("select#genero").focus();
        return false;
    }
    var correo = $("input#correo").val();
    if (correo == "") {
        $("label#correo_error").show();
        $("input#correo").focus();
        return false;
    }


    var admincooperativa = {
        "cedula": cedula,
        "nombre": nombres,
        "apellido": apellidos,
        "fecha_nacimiento": fechan,
        "genero": genero,
        "telefono": telefonoa,
        "correo": correo,
        "path_foto": "image/image",
        "id_cooperativa": id_coop,
        "id_persona_rol_ejecucion": id_usuario_rol,
        "created_by": id_usuario_rol
    };
    $.ajax({
        headers: _headers(token),
        url: `${url}/UsuarioAdministradorCooperativa`,
        type: 'POST',
        data: JSON.stringify(admincooperativa),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModaladmin').modal('hide');
                obtenerCooperativa();
                mensajeExito(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Error al ingresar los datos de coopertaiva');
        }
    });
    return false;
});

//mapoa
map = L.map('map2').setView([0.04104004628590023, -78.14285258539633], 13);
//[0.04104004628590023, -78.14285258539633], 13

L.marker([48.86, 2.35]).addTo(map);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

// Comment out the below code to see the difference.
$('#formModal').on('shown.bs.modal', function () {
    map.invalidateSize();
});
var popup = L.popup();
var txt_latitud = document.getElementById("lat");
var txt_longitud = document.getElementById("lng");


function onMapClick(e) {
    popup.setLatLng(e.latlng).setContent("Lugar seleccionado").openOn(map);
    txt_latitud.value = e.latlng.lat;
    txt_longitud.value = e.latlng.lng;
}

map.on('click', onMapClick);


const selectlimitar = document.querySelector('.limitar');

const colnombre = document.querySelector('.colnombre');
const coldireccion = document.querySelector('.coldireccion');
const coltelefono = document.querySelector('.coltelefono');
const colactivo = document.querySelector('.colactivo');

selectlimitar.addEventListener('change', (event) => {
    consult['limit'] = event.target.value;
    obtenerCooperativa();
});

colnombre.addEventListener('input', (event) => {
    consult['columna'] = 'nombre';
    consult['nombre'] = event.srcElement.value;
    obtenerCooperativa();
});
coldireccion.addEventListener('input', (event) => {
    consult['columna'] = 'direccion';
    consult['nombre'] = event.srcElement.value;
    obtenerCooperativa();
});
coltelefono.addEventListener('input', (event) => {
    consult['columna'] = 'telefono';
    consult['nombre'] = event.srcElement.value;
    obtenerCooperativa();
});
colactivo.addEventListener('change', (event) => {
    consult['columna'] = 'activo';
    consult['nombre'] = event.target.value;
    obtenerCooperativa();

});