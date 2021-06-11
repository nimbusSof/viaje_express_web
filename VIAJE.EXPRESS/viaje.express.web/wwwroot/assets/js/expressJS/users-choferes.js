import { url } from './env.js';
var datatable;
var token;
var id_usuario_rol;
var id_cooperativa;
const url_choferes = `${url}/UsuarioChofer`;
var consult = {
    "offset": 0,
    "limit": 5,
    "columna": '',
    "nombre": '',
    "sort": ''
}
$(function () {
    token = localStorage.getItem('id_token');
    id_usuario_rol = localStorage.getItem('id_usuario_rol');
    id_cooperativa = localStorage.getItem('id_cooperativa');
    obtenerChofer();
    seleccionarVehiculo();
});

function obtenerChofer() {
    $.ajax({
        headers: _headers(token),
        url: `${url_choferes}/Listar/` + id_cooperativa,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            datatable = $("#tblChoferes").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblChoferes').DataTable({
                    ordering: false,
                    responsive: true,
                    autoWidth: false,
                    bFilter: false,
                    lengthChange: false,
                    bInfo: false,
                    data: data.data,
                    columns: [
                        { data: "id_persona_rol" },
                        { data: "cedula" },
                        { data: "nombre" },
                        { data: "apellido" },
                        { data: "correo" },
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
                            data: "id_persona_rol", "render": function (data) {
                                var id = data;
                                return '<button type="button"  name="edit" id="' + id + '"  class="edit btn btn-primary btn-sm"> <i class="fa fa-edit fa-lg"></i></button> <button type="button"   name="delete" id="' + id + '" class="delete btn btn-danger btn-sm"><i class="fa fa-trash fa-lg"></i> </button>';
                            }
                        }
                    ]
                });
            } else {
                clearTable('#tblChoferes');
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}
function seleccionarVehiculo() {
    let vehiculo = document.getElementById('vehiculo');
    consult['limit'] = 500;
    $.ajax({
        headers: _headers(token),
        url: `${url}/Vehiculo/Listar/` + id_cooperativa,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                var vehiculos= data.data;
                vehiculos.forEach((item) => {
                    vehiculo.innerHTML += `<option value=${item.id_vehiculo}>${item.placa}</option>`
                });
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

$('#crear_chofer').click(function () {
    $('.modal-title').text('Agregar nuevo chofer');
    $('#action_button').val('Add');
    $('#action').val('Add');
    $('#form_result').html('');
    $('#act').hide();
    $('#resetc').hide();
    $('#formModal').modal('show');
    $('#formulario_chofer').trigger("reset");
    $('.error').hide();
});


$('#formulario_chofer').on('submit', function (event) {
    $('.error').hide();
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
    var telefono = $("input#telefono").val();
    if (telefono == "") {
        $("label#telefono_error").show();
        $("input#telefono").focus();
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
    var puntos_licencia = $("input#puntos").val();
    if (puntos_licencia == "") {
        $("label#puntos_error").show();
        $("input#puntos").focus();
        return false;
    }
    var modulo_id = $("select#modulo").val();
    if (modulo_id == "") {
        $("label#modulo_error").show();
        $("select#modulo").focus();
        return false;
    }
    var vehiculo_id = $("select#vehiculo").val();
    var activo = document.getElementById("activo");

    var chofer = {
        'cedula': cedula,
        'nombre': nombres,
        'apellido': apellidos,
        'fecha_nacimiento': fechan,
        'genero': genero,
        'telefono': telefono,
        'correo': correo,
        'clave': cedula,
        'activo': activo.checked,
        'path_foto': 'image/image',
        'id_cooperativa': id_cooperativa,
        "id_vehiculo": vehiculo_id,
        "puntos_licencia": puntos_licencia,
        "created_by": id_usuario_rol,
        "id_persona_rol_ejecucion": id_usuario_rol
    };

    let type_met = '';
    var action_url = '';
    let id_operador = $('#hidden_id').val();
    if ($('#action').val() == 'Add') {
        action_url = url_choferes;
        type_met = 'POST'
    }
    if ($('#action').val() == 'Edit') {
        action_url = `${url_choferes}/${id_operador}`;
        type_met = 'PUT'
    }
    $.ajax({
        headers: _headers(token),
        url: action_url,
        type: type_met,
        data: JSON.stringify(chofer),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModal').modal('hide');
                mensajeExito(data.mensaje);
                obtenerChofer();
            } else {
                mensajeError(data.mensaje);
            }


        },
        error: function (err) {
            mensajeError('Error al guardar datos del chofer');
        }
    });
    return false;
});


$('#resetearc').click(function () {
    var id = $('#hidden_id').val();
    resetearClave(url_choferes, id, token);
});

$(document).on('click', '.edit', function () {
    $('.error').hide();
    $('#act').show();
    $('#resetc').show();
    var id = $(this).attr('id');
    $('#form_result').html('');
    $.ajax({
        headers: _headers(token),
        url: `${url_choferes}/${id}`,
        dataType: "json",
        success: function (resp) {
            $("#fechan").val(formatDate(resp.data.fecha_nacimiento));
            $('#cedula').val(resp.data.cedula);
            $('#nombres').val(resp.data.nombre);
            $('#apellidos').val(resp.data.apellido);
            $('#genero').val(resp.data.genero);
            $('#modulo').val(modulos);
            $('#telefono').val(resp.data.telefono);
            $('#correo').val(resp.data.correo);
            $('#puntos').val(resp.data.puntos_licencia);
            $('#vehiculo').val(resp.data.id_vehiculo);
            document.getElementById("activo").checked = resp.data.activo;
            $('#hidden_id').val(id);
            $('.modal-title').text('Editar Chofer');
            $('#action_button').val('Edit');
            $('#action').val('Edit');
            $('#formModal').modal('show');
        }
    });
});


$(document).on('click', '.delete', function () {
    let chofer_id = $(this).attr('id');
    swal({
        title: "¿Esta seguro de eliminar?",
        text: "Al eliminar al Chofer de cooperativa este perdera el acceso a su cuenta",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar!",
        closeOnConfirm: false
    },
        function () {
            eliminarChofer(chofer_id);
        });
});

function eliminarChofer(idChofer) {
    $.ajax({
        headers: _headers(token),
        url: `${url_choferes}/${idChofer}`,
        type: 'DELETE',
        dataType: "json",
        data: JSON.stringify({ "deleted_by": id_usuario_rol }),
        success: function (data) {
            if (data.exito) {
                mensajeExito(data.mensaje);
                obtenerChofer();
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Ocurrio un error inesperado durante la ejecución');
        }
    });
}

const selectlimitar = document.querySelector('.limitar');

const colcedula = document.querySelector('.colcedula');
const colnombre = document.querySelector('.colnombre');
const colapellido = document.querySelector('.colapellido');
const colcorreo = document.querySelector('.colcorreo');
const colactivo = document.querySelector('.colactivooper');

selectlimitar.addEventListener('change', (event) => {
    consult['limit'] = event.target.value;
    obtenerChofer();

});

colcedula.addEventListener('input', (event) => {
    consult['columna'] = 'p.cedula';
    consult['nombre'] = event.srcElement.value;
    obtenerChofer();
});
colnombre.addEventListener('input', (event) => {
    consult['columna'] = 'p.nombre';
    consult['nombre'] = event.srcElement.value;
    obtenerChofer();
});
colapellido.addEventListener('input', (event) => {
    consult['columna'] = 'p.apellido';
    consult['nombre'] = event.srcElement.value;
    obtenerChofer();
});
colcorreo.addEventListener('input', (event) => {
    consult['columna'] = 'p.correo';
    consult['nombre'] = event.srcElement.value;
    obtenerChofer();
});

colactivo.addEventListener('change', (event) => {
    consult['columna'] = 'pr.activo';
    consult['nombre'] = event.target.value;
    obtenerChofer();
});