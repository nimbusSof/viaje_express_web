import { url } from './env.js';
var datatable;
var id_usuario_rol;
var id_cooperativa;
var rol;
var token;
var modulos_operador = [];
const url_modulo = `${url}/UsuarioOperadorCooperativa`;
var consult = {
    "offset": 0,
    "limit": 5,
    "columna": '',
    "nombre": '',
    "sort": ''
}
$(function () {
    id_usuario_rol = localStorage.getItem('id_usuario_rol');
    id_cooperativa = localStorage.getItem('id_cooperativa');
    token = localStorage.getItem('id_token');
    rol = localStorage.getItem('rol');
    obtenerOperadoresCoop();
    obtenerModulos();
});

function obtenerOperadoresCoop() {
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo}/Listar/` + id_cooperativa,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            datatable = $("#tblOPeradoresCoop").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblOPeradoresCoop').DataTable({
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
                clearTable('#tblOPeradoresCoop');
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}
function obtenerModulos() {
    let modulo = document.getElementById('modulo');
    $.ajax({
        headers: _headers(token),
        url: `${url}/Modulo/ListarModulo/${rol}`,
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.exito) {
                modulo.innerHTML = "";
                var modul = data.data;
                modul.forEach((item, i) => {
                    if (i == 0) {
                        modulo.innerHTML += `<option  value=${item.id_modulo} selected>${item.nombre_modulo}</option>`
                    } else if (i != 0) {
                        modulo.innerHTML += `<option  value=${item.id_modulo}>${item.nombre_modulo}</option>`
                    }
                });
            } else {
                mensajeError(data.mensaje)
            }
        }
    });
}
function obtenerModulos2() {
    modulos_operador = [];
    $.ajax({
        headers: _headers(token),
        url: `${url}/Modulo/ListarModulo/${rol}`,
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.exito) {
                var modul = data.data;
                modul.forEach((item, i) => {
                    modulos_operador.push(item);
                });
            } else {
                mensajeError(data.mensaje)
            }
        }
    });
}

$('#crear_operadorcooperativa').click(function () {
    $('.modal-title').text('Agregar nuevo Operador de Cooperativa');
    $('#action_button').val('Add');
    $('#action').val('Add');
    $('#form_result').html('');
    $('#act').hide();
    $('#resetc').hide();
    $('#formModal').modal('show');
    $('#formulario_operadorcooperativa').trigger("reset");
    $('.error').hide();
    obtenerModulos();
});


$('#formulario_operadorcooperativa').on('submit', function (event) {
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
    var modulo_id = $("select#modulo").val();
    if (modulo_id == "") {
        $("label#modulo_error").show();
        $("select#modulo").focus();
        return false;
    }
    var activo = document.getElementById("activo");

    var operadorcoop = {
        'cedula': cedula,
        'nombre': nombres,
        'apellido': apellidos,
        'fecha_nacimiento': fechan,
        'genero': genero,
        'telefono': telefono,
        'correo': correo,
        'clave': cedula,
        'path_foto': 'image/image',
        'id_cooperativa': id_cooperativa,
        "modulos": modulo_id,
        "activo": activo.checked,
        "created_by": id_usuario_rol,
        "id_persona_rol_ejecucion": id_usuario_rol,
        "modified_by": id_usuario_rol
    };
    let type_met = '';
    var action_url = '';
    let id_operador = $('#hidden_id').val();
    if ($('#action').val() == 'Add') {
        action_url = url_modulo;
        type_met = 'POST'
    }
    if ($('#action').val() == 'Edit') {
        action_url = `${url_modulo}/${id_operador}`;
        type_met = 'PUT'
    }
    $.ajax({
        headers: _headers(token),
        url: action_url,
        type: type_met,
        data: JSON.stringify(operadorcoop),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModal').modal('hide');
                mensajeExito(data.mensaje);
                obtenerOperadoresCoop();
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Error al guardar datos del administrador');
        }
    });
    return false;
});


$('#resetearc').click(function () {
    var id = $('#hidden_id').val();
    resetearClave(url_modulo, id, token);
});

$(document).on('click', '.edit', function () {
    var modulo = document.getElementById('modulo');
    $('.error').hide();
    $('#act').show();
    $('#resetc').show();
    var id = $(this).attr('id');
    $('#form_result').html('');
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo}/${id}`,
        dataType: "json",
        success: function (resp) {
            modulo.innerHTML = "";
            obtenerModulos2();
            modulos_operador.forEach((_mod, i, array) => {
                if (i < resp.data.modulos.length) {
                    array.find(elemet => {
                        if (resp.data.modulos[i].id_modulo === elemet.id_modulo) {
                            modulo.innerHTML += `<option  value=${elemet.id_modulo} selected>${elemet.nombre_modulo}</option>`
                        }
                    });

                    let l = array.findIndex(data => resp.data.modulos[i].id_modulo === data.id_modulo);
                    if (l !== -1) {
                        array.splice(l, 1);
                    } 
                }
                if (i === resp.data.modulos.length) {
                    array.forEach((mod_los) => {
                        modulo.innerHTML += `<option  value=${mod_los.id_modulo}>${mod_los.nombre_modulo}</option>`
                    });
                }
                
            });
            $("#fechan").val(formatDate(resp.data.fecha_nacimiento));
            $('#cedula').val(resp.data.cedula);
            $('#nombres').val(resp.data.nombre);
            $('#apellidos').val(resp.data.apellido);
            $('#genero').val(resp.data.genero);
            $('#telefono').val(resp.data.telefono);
            $('#correo').val(resp.data.correo);
            document.getElementById("activo").checked = resp.data.activo;
            $('#hidden_id').val(id);
            $('.modal-title').text('Editar Operador de Cooperativa');
            $('#action_button').val('Edit');
            $('#action').val('Edit');
            $('#formModal').modal('show');
        }
    });
});

$(document).on('click', '.delete', function () {
    let operador_coop_id = $(this).attr('id');
    swal({
        title: "¿Esta seguro de eliminar?",
        text: "Al eliminar al Operador de cooperativa este perdera el acceso a su cuenta",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar!",
        closeOnConfirm: false
    },
        function () {
            eliminarOperadorCoop(operador_coop_id);
        });
});

function eliminarOperadorCoop(idOperadorCopp) {
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo}/${idOperadorCopp}`,
        type: 'DELETE',
        dataType: "json",
        data: JSON.stringify({ "deleted_by": id_usuario_rol }),
        success: function (data) {
            if (data.exito) {
                mensajeExito(data.mensaje);
                obtenerOperadoresCoop();
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Ocurrio un error durante la ejecución');
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
    obtenerOperadoresCoop();

});

colcedula.addEventListener('input', (event) => {
    consult['columna'] = 'p.cedula';
    consult['nombre'] = event.srcElement.value;
    obtenerOperadoresCoop();
});
colnombre.addEventListener('input', (event) => {
    consult['columna'] = 'p.nombre';
    consult['nombre'] = event.srcElement.value;
    obtenerOperadoresCoop();
});
colapellido.addEventListener('input', (event) => {
    consult['columna'] = 'p.apellido';
    consult['nombre'] = event.srcElement.value;
    obtenerOperadoresCoop();
});
colcorreo.addEventListener('input', (event) => {
    consult['columna'] = 'p.correo';
    consult['nombre'] = event.srcElement.value;
    obtenerOperadoresCoop();
});

colactivo.addEventListener('change', (event) => {
    consult['columna'] = 'pr.activo';
    consult['nombre'] = event.target.value;
    obtenerOperadoresCoop();
});