import { url } from './env.js';

$(function () {
    $('#login').click(function () {
        let url_login = `${url}/Login`;
        iniciar_session(url_login);
    });

    $('#loginCliente').click(function () {
        let url_login_cliente = `${url}/Login/Cliente`;
        iniciar_session(url_login_cliente);
    });
});

const credenciales = () => {
    return {
        correo: $('#correo').val(),
        clave: $('#clave').val()
    };
}

const iniciar_session = (_url) => {
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        type: 'POST',
        data: JSON.stringify(credenciales()),
        url: _url,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                localStorage.setItem('id_token', data.token);
                localStorage.setItem('id_usuario_rol', data.id_persona_rol);
                localStorage.setItem('rol', data.rol);
                data.rol < 5 ? localStorage.setItem('id_cooperativa', data.id_cooperativa) : '';
                redireccioLogin(data.rol);
            } else {
                alert(data.mensaje);
            }
        }, error: function (err) {
            alert(err.message);
        }
    })
}


const redireccioLogin=(rol)=> {
    switch (rol) {
        case 1:
            location.href = '../Administrador/Index'
            break
        case 2:
            location.href = '../AdminCoop/Index'
            break
        case 3:
            location.href = '../Operador/Index'
            break
        case 4:
            location.href = '../Chofer/Index'
            break
        case 5:
            location.href = '../Cliente/Index'
            break
        default:
            location.href = '../Home/Index'
            break
    }
}


