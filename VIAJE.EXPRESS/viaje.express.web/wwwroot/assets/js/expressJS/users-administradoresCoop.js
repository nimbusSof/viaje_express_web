import { url } from './env.js';
var datatable;
var token;
var id_usuario_rol;
var id_cooperatiava;
const url_modulo_useradmincoop = `${url}/UsuarioAdministradorCooperativa`;
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
    obtenerAdministradoresCoop();
    seleccionarCooperativa();
});

function obtenerAdministradoresCoop() {
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo_useradmincoop}/Listar`,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            datatable = $("#tblAdminCoop").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblAdminCoop').DataTable({
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
                        { data: "nombre_cooperativa" },
                        {
                            data: "id_persona_rol", "render": function (data) {
                                var id = data;
                                return '<button type="button"  name="edit" id="' + id + '"  class="edit btn btn-primary btn-sm"> <i class="fa fa-edit fa-lg"></i></button> <button type="button"   name="delete" id="' + id + '" class="delete btn btn-danger btn-sm"><i class="fa fa-trash fa-lg"></i> </button>';
                            }
                        }
                    ]
                });
            } else {
                clearTable('#tblAdminCoop');
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}



$('#crear_admincooperativa').click(function () {
    $('.modal-title').text('Agregar nuevo Administrador de Cooperativa');
    $('#action_button').val('Add');
    $('#action').val('Add');
    $('#form_result').html('');
    $('#formModal').modal('show');
    $('#formulario_admincooperativa').trigger("reset");
    $('#act').hide();
    $('#resetc').hide();
    $('.error').hide();
});


$('#resetearc').click(function () {
    var id = $('#hidden_id').val();
    resetearClave(url_modulo_useradmincoop, id, token);
});


$('#formulario_admincooperativa').on('submit', function (event) {
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
    var activo = document.getElementById("activo");

    var admincoop = {
        'cedula': cedula,
        'nombre': nombres,
        'apellido': apellidos,
        'fecha_nacimiento': fechan,
        'genero': genero,
        'telefono': telefono,
        'correo': correo,
        'clave': cedula,
        'path_foto': 'image/image',
        'id_cooperativa': id_cooperatiava,
        "created_by": id_usuario_rol,
        "id_persona_rol_ejecucion": id_usuario_rol,
        "activo": activo.checked,
        "modified_by": id_usuario_rol
    };

    let type_met = '';
    var action_url = '';
    let id_admin = $('#hidden_id').val();
    if ($('#action').val() == 'Add') {
        action_url = url_modulo_useradmincoop;
        type_met = 'POST'
    }
    if ($('#action').val() == 'Edit') {
        action_url = `${url_modulo_useradmincoop}/${id_admin}`;
        type_met = 'PUT'

    }
    $.ajax({
        headers: _headers(token),
        url: action_url,
        type: type_met,
        data: JSON.stringify(admincoop),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModal').modal('hide');
                mensajeExito(data.mensaje);
                obtenerAdministradoresCoop();
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



$(document).on('click', '.edit', function () {
    $('.error').hide();
    var id = $(this).attr('id');
    $('#act').show();
    $('#resetc').show();
    $('#form_result').html('');
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo_useradmincoop}/${id}`,
        dataType: "json",
        success: function (resp) {
            $("#fechan").val(formatDate(resp.data.fecha_nacimiento));
            $('#cedula').val(resp.data.cedula);
            $('#nombres').val(resp.data.nombre);
            $('#apellidos').val(resp.data.apellido);
            $('#genero').val(resp.data.genero);
            id_cooperatiava = resp.data.id_cooperativa
            nombreCoop(id_cooperatiava);
            $('#telefono').val(resp.data.telefono);
            $('#correo').val(resp.data.correo);
            $('#hidden_id').val(id);
            document.getElementById("activo").checked = resp.data.activo;
            $('.modal-title').text('Editar Administrador de Cooperativa');
            $('#action_button').val('Edit');
            $('#action').val('Edit');
            $('#formModal').modal('show');
        }
    });
});

function nombreCoop(id_coop) {
    $.ajax({
        headers: _headers(token),
        url: `${url}/Cooperativa/`+id_coop,
        dataType: "json",
         success: function (data) {
             $('#cooperativa').val(data.data.nombre);
        }
     });
}


function seleccionarCooperativa() {
    var coops = [];
    var map = {};
    $('#cooperativa').typeahead({
        source: function (query, result) {
            coops = [];
            map = {};
            $.ajax({
                headers: _headers(token),
                url: `${url}/Cooperativa/Listar`,
                type: "POST",
                data: JSON.stringify(consult),
                dataType: "json",
                success: function (data) {
                    if (data.exito) {
                        data.data.forEach(coop => {
                            if (coop.activo) {
                                map[coop.nombre] = coop;
                                coops.push(coop.nombre);
                            }
                        });
                        result(coops);
                    } else {
                        console.log(data.mensaje);
                    }
                }
            })
        },
        updater: function (item) {
            id_cooperatiava = map[item].id_cooperativa;
            return item;
        },
        matcher: function (item) {
            if (item.toLowerCase().indexOf(this.query.trim().toLowerCase()) != -1) {
                return true;
            }
        },
        sorter: function (items) {
            return items.sort();
        },
        highlighter: function (item) {
            var regex = new RegExp('(' + this.query + ')', 'gi');
            return item.replace(regex, "<strong>$1</strong>");
        }
       
    });
}


$(document).on('click', '.delete', function () {
    let admin_coop_id = $(this).attr('id');
    swal({
        title: "¿Esta seguro de eliminar?",
        text: "Al eliminar al Administrador perdera el acceso a la cuenta",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar!",
        closeOnConfirm: false
    },
        function () {
            eliminarAdminCoop(admin_coop_id);
        });
});

function eliminarAdminCoop(idAdminCopp) {
    $.ajax({
        headers: _headers(token),
        url: `${url_modulo_useradmincoop}/${idAdminCopp}`,
        type: 'DELETE',
        dataType: "json",
        data: JSON.stringify({ "deleted_by": id_usuario_rol }),
        success: function (data) {
            if (data['exito']) {
                mensajeExito(data.mensaje);
                obtenerAdministradoresCoop();
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Ocurrio un error al ejecutar esta instruccion');
        }
    });
}


const selectlimitar = document.querySelector('.limitar');

const colcedula = document.querySelector('.colcedula');
const colnombre = document.querySelector('.colnombre');
const colapellido = document.querySelector('.colapellido');
const colcorreo = document.querySelector('.colcorreo');
const colcooperativa = document.querySelector('.colcooperativa');
const colactivo = document.querySelector('.colactivoadmin');

selectlimitar.addEventListener('change', (event) => {
    consult['limit'] = event.target.value;
    obtenerAdministradoresCoop();

});

colcedula.addEventListener('input', (event) => {
    consult['columna'] = 'p.cedula';
    consult['nombre'] = event.srcElement.value;
    obtenerAdministradoresCoop();
});
colnombre.addEventListener('input', (event) => {
    consult['columna'] = 'p.nombre';
    consult['nombre'] = event.srcElement.value;
    obtenerAdministradoresCoop();
});
colapellido.addEventListener('input', (event) => {
    consult['columna'] = 'p.apellido';
    consult['nombre'] = event.srcElement.value;
    obtenerAdministradoresCoop();
});
colcorreo.addEventListener('input', (event) => {
    consult['columna'] = 'p.correo';
    consult['nombre'] = event.srcElement.value;
    obtenerAdministradoresCoop();
});


colactivo.addEventListener('change', (event) => {
    consult['columna'] = 'pr.activo';
    consult['nombre'] = event.target.value;
    obtenerAdministradoresCoop();
});
colcooperativa.addEventListener('input', (event) => {
    consult['columna'] = 'c.nombre';
    consult['nombre'] = event.srcElement.value;
    obtenerAdministradoresCoop();
});
