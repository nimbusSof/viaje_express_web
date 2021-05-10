
function inciar_session() {
    const url = 'http://localhost:59454/Login';
    var _correo = document.getElementById("correo").value;
    var _clave = document.getElementById("clave").value;

    // alert(_correo + "  " + _clave);
    const data = {
        correo: _correo,
        clave: _clave
    }
    //POST request with body equal on data in JSON format
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then((response) => response.json())
        //Then with the data from the response in JSON...
        .then((data) => {
            if (data['exito']) {
                localStorage.setItem('id_token', data['token']);
                localStorage.setItem('id_usuario_rol', data['id_persona_rol']);
                console.log(localStorage.getItem('id_token'));
                redireccioLogin(data['rol']);
            } else {
                alert(data['mensaje']);

            }
        })
        //Then with the error genereted...
        .catch((error) => {
            alert('Error Login:', error);
        });

}



function redireccioLogin(rol) {

    switch (rol) {
        case 1:
            location.href = '../Administrador/Index'

            break
        case 2:
            location.href = '../Cooperativa/Index'
            break
        case 3:
            location.href = '../Operador/Index'
            break
        case 4:
            location.href = '../Chofer/Index'
            break
        default:
            location.href = '../Cliente/Index'
            break
    }
}



