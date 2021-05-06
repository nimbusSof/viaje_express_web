

function login() {
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
                sessionStorage.setItem('id_token', data['token']);
                localStorage.setItem('id_usuario_rol', data['id_persona_rol']);
                redireccioLogin('Administrador');
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


    //var url = `http://localhost:59454/Usuario/ ${rol}`;
    //fetch(url)
    //    .then((response) => {
    //        return response.json();
    //    })
    //    .then((data) => {
    //        if (data['exito']) {
                
    //        } else {
    //            alert(data['mensaje']);
    //        }
    //        //console.log(data);

    //    }).catch((error) => alert(error));





    switch (rol) {
        case "Administrador":
            location.href = '../Administrador/Index'

            break
        case "Administrador Cooperativa":
            location.href = '../Cooperativa/Index'
            break
        case "Operador":
            location.href = '../Operador/Index'
            break
        case "Chofer":
            location.href = '../Chofer/Index'
            break
        default:
            location.href = '../Cliente/Index'
            break
    }
}



