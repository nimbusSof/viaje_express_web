import { url } from './env.js';
var token = localStorage.getItem('id_token');
var id_usuario_rol = localStorage.getItem('id_usuario_rol');
var rol_usuario=localStorage.getItem('rol');
const usuario = userName();
$('#username').text(usuario.nombre);
$('.error').hide();

$(function () {
    obtener_perfil();
});

function userName () {
    var resultado = {};
    $.ajax({
        headers: _headers(token),
        url: `${url}/PerfilUsuario/${id_usuario_rol}`,
        async: false,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                resultado = data.data;
            } else {
                mensajeError(data.mensaje);
            }

        }
    });
    return resultado;
}

function obtener_perfil() {
    $("#fechan_p").val(formatDate(usuario.fecha_nacimiento));
    $('#cedula_p').val(usuario.cedula);
    $('#nombres_p').val(usuario.nombre);
    $('#apellidos_p').val(usuario.apellido);
    $('#genero_p').val(usuario.genero);
    $('#telefono_p').val(usuario.telefono);
    $('#correo_p').val(usuario.correo);
    $('#contrasenia_p').val(usuario.clave);
    $('#rol_descripcion').text(usuario.rol);
}


$('#guardar').click(function () {
    $('.error').hide();
    var cedula = $("input#cedula_p").val();
    if (cedula == "") {
        $("label#cedula_error").show();
        $("input#cedula_p").focus();
        return false;
    }
    var nombres = $("input#nombres_p").val();
    if (nombres == "") {
        $("label#nombres_error").show();
        $("input#nombres_p").focus();
        return false;
    }
    var apellidos = $("input#apellidos_p").val();
    if (apellidos == "") {
        $("label#apellidos_error").show();
        $("input#apellidos_p").focus();
        return false;
    }
    var fechan = $("input#fechan_p").val();
    if (fechan == "") {
        $("label#fechan_error").show();
        $("input#fechan_p").focus();
        return false;
    }
    var telefono = $("input#telefono_p").val();
    if (telefono == "") {
        $("label#telefono_error").show();
        $("input#telefono_p").focus();
        return false;
    }
    var genero = $("select#genero_p").val();
    if (genero == "") {
        $("label#genero_error").show();
        $("select#genero_p").focus();
        return false;
    }
    var correo = $("input#correo_p").val();
    if (correo == "") {
        $("label#correo_error").show();
        $("input#correo_p").focus();
        return false;
    }
    var contrasenia = $("input#contrasenia_p").val();
    if (contrasenia == "") {
        $("label#contrasenia_error").show();
        $("input#contrasenia_p").focus();
        return false;
    }

    var datos_usuario = {
        'cedula': cedula,
        'nombre': nombres,
        'apellido': apellidos,
        'fecha_nacimiento': fechan,
        'genero': genero,
        'telefono': telefono,
        'correo': correo,
        'clave': contrasenia,
        'path_foto': 'image/image',
        "modified_by": id_usuario_rol
    };
    $.ajax({
        headers: _headers(token),
        url: `${url}/PerfilUsuario/${id_usuario_rol}`,
        type: 'PUT',
        data: JSON.stringify(datos_usuario),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                mensajeExito(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Error al guardar datos del usuario');
        }
    });
});


$('#mi_perfil').click(function () {
    if (rol_usuario != 5) {
        navegar('Usuario/Perfil');
    } else if (rol_usuario == 5) {
        navegar('Cliente/Perfil');
    }
});

$('#back').click(function () {
    window.history.back();
});
