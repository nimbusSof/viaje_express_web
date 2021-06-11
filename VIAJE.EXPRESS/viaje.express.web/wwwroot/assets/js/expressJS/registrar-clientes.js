import { url } from './env.js';
import { ruta_solicitud, db } from './firebas.js';
$(function () {
    $('.error').hide();
});

$('#registar').click(function () {
    registrar();
});


function registrar() {
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
    var genero = $("select#genero").val();
    if (genero == "") {
        $("label#genero_error").show();
        $("select#genero").focus();
        return false;
    }
    var fechan = $("input#fechan").val();
    if (fechan == "") {
        $("label#fechan_error").show();
        $("input#fechan").focus();
        return false;
    }
    var correo = $("input#correo").val();
    if (correo == "") {
        $("label#correo_error").show();
        $("input#correo").focus();
        return false;
    }
    var contrasenia = $("input#contrasenia").val();
    if (contrasenia == "") {
        $("label#contrasenia_error").show();
        $("input#contrasenia").focus();
        return false;
    }


    var usuario = {
        'cedula': cedula,
        'nombre': nombres,
        'apellido': apellidos,
        'direccion': direccion,
        'telefono': telefono,
        'genero': genero,
        'fecha_nacimiento': fechan,
        'correo': correo,
        'clave': contrasenia,
        'path_foto': 'image/image',
    };
    console.log(usuario);
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        url: `${url}/CuentaCliente/registro_cliente`,
        type: 'POST',
        data: JSON.stringify(usuario),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                alert(data.mensaje);
                cuenta_cliente(data.codigo, cedula, nombres, apellidos, genero);
                location.href = '../Acceso/LoginCliente';
            } else if (!data.exito && data.codigo > 0) {
                alert(data.mensaje);
                registrarUsuarioClientenuevo_rol(data.codigo, usuario);
            } else {
                alert(data.mensaje);
            }
        },
        error: function (err) {
            alert(data.mensaje);
        }
    });
    return false;
}

function registrarUsuarioClientenuevo_rol(idpersona,user) {
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        url: `${url}/CuentaCliente/registro_persona_rol_cliente`,
        type: 'POST',
        data: JSON.stringify({ 'id_persona': idpersona }),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                alert(data.mensaje);
                cuenta_cliente(idpersona, user.cedula, user.nombres, user.apellidos, user.genero);
                location.href = '../Acceso/LoginCliente';
            } else {
                alert(data.mensaje);
            }
        },
        error: function (err) {
            alert(data.mensaje);
        }
    });
}

////FIREBASE
const cuenta_cliente = (id_persona_rol, cedula, nombre, apellido, genero) => {
    db.ref(ruta_solicitud(id_persona_rol + "-id_persona_rol")).update({
        id_persona_rol,
        cedula,
        apellido,
        nombre,
        genero
    });
    console.log('registro en firebase correcto');
}