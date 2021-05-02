var resultado;
var c;

function listarVehiculos() {
    var controller = '"Vehiculo"';
    var action = '"Index"';
    var classa = '"nav-link text-dark button primary"';

    var areas = '" "';
    var hss = '"/EditVehiculo/Index"';
    const url = 'http://localhost:59454/Vehiculo/' + sessionStorage.getItem('id_cooperativa') + '/' + 'hd'
    fetch(url)
        .then(response => response.json())
        .then(data => {
            let listaV = document.querySelector('#listaV');
            listaV.innerHTML = '';
            for (let item of data) {
                listaV.innerHTML += "<tr><td>" + item.vehiculoId + "</td><td>" + item.vehiculoPlacaVehiculo + "</td>" +
                    "<td>" + item.vehiculoColorVehiculo +
                    "</td><td>" +
                    "<ul class='actions special'> " +
                    " <li> <input type='button'  class='boton' name='act' id='act' " +
                    "onclick='actualizar(" + item.vehiculoId + ")' value='Actualizar' style='width: 30'></li><li> <input type='button'  class='boton' name='crear' id='crear' " +
                    "onclick='eliminar_Vehiculo(" + item.vehiculoId + ")' value='Eliminar' style='width: 30'></li> </ul>";
               
                +" </ul></td></tr>";
            }
        })
        .catch(
        )
}
function listarUsuarios() {
    const url = 'http://localhost:59454/Persona/'
    fetch(url)
        .then(response => response.json())
        .then(data => {
            let listaVw = document.querySelector('#listaoficial');
            listaVw.innerHTML = '';
            for (let item of data) {
                listaVw.innerHTML += "<tr><td>" + item.cedulaPersona + "<td><td>" + item.nombrePersona + "<td><td>" + item.apellidosPersona + "<td></tr>";
            }
        })
        .catch(
        )
}
function validar() {
   

    const url = 'http://localhost:59454/Persona/' + document.getElementById("usuario").value+'/'+ document.getElementById("pass").value
    fetch(url)
        .then(response => response.json())
        .then(data => {

            var id_usuario = data.idPersona
            sessionStorage.setItem('persona_nombre_usuario', data.personaNombreUsuario);
            sessionStorage.setItem('id_persona', data.idPersona);

            validarUsuario(id_usuario)
        
            
          
        })
        .catch(err => alert("Usuario o contrasenia erroneosjijijijihhuhuh")

        )

}



function validarUsuario(id_usuario) {


    const url = 'http://localhost:59454/PersonaRol/' + id_usuario
    fetch(url)
        .then(response => response.json())
        .then(data => {
            var id_rol = data['rolId']
            var id_personaRol = data['personaRolId']
            sessionStorage.setItem('id_personaRol', id_personaRol);
            validarUsuarioRol(id_rol, id_personaRol)

        })
        .catch(err => alert("Usuario o contrasenia erroneos tt")

        )

}
function validarUsuarioRol(id_rol) {
    const url = 'http://localhost:59454/Rol/' + id_rol
    fetch(url)
        .then(response => response.json())
        .then(data => {
            var rol = data['descrpcionRol']
            sessionStorage.setItem('rol', rol);
            var a=1
            switch (rol) {
                case "Administrador":
                    location.href = '../Home/Privacy'

                    break
                case "Cliente":
                    location.href = '../Cliente/Cliente'
                    break
                case "Cooperativa":
                    location.href = '../AdminCoperatController2/Index'
                    break
                case "Operadora":
                    location.href = '../Cliente/Cliente'
                    break
                default:
                    location.href = '../Cliente/Cliente'
                    break
            }          
        })
        .catch(err => alert("Usuario o contrasenia erroneos")
    )
}
function ObtenerCooperativa() {
    const url = 'http://localhost:59454/Cooperativa/' + sessionStorage.getItem('id_personaRol') + '/' + 'd'
    fetch(url)
        .then(response => response.json())
        .then(data => {

            resultado = data['idCoop'];
            sessionStorage.setItem('id_cooperativa', resultado);
           // alert("ID COOPERATIVA: " + resultado)
           

        })
        .catch(err => alert("Error" + err))
}
function crear_Persona(){

    var cedula = document.getElementById('Cedula').value;
    var nombre = document.getElementById('Nombre').value;
    var apellidos = document.getElementById('Apellidos').value;
    var fechanac = '2021-02-26T00:10:23.699Z';
    var telefono = document.getElementById('Telefono').value;
    var direccion = document.getElementById('Direccion').value;
    var correo = document.getElementById('Correo').value;
    var contrasenia = document.getElementById('Contrasena').value;
    var nusuario = document.getElementById('NUsuario').value;
    let Persona = 
       {
        "cedulaPersona": cedula,
        "nombrePersona": nombre,
        "apellidosPersona": apellidos,
        "nacimientoPersona": fechanac,
        "telefonoPersona": telefono,
        "direccionPersona": direccion,
        "correoPersona": correo,
        "contraseniaPersona": contrasenia,
        "createdBy": sessionStorage.getItem('id_persona'),
        "personaNombreUsuario": nusuario
    }
   
    fetch('http://localhost:59454/Persona', {
        method: 'POST',
        body: JSON.stringify(Persona),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => {
       var a = 1
    }
    )
    .catch(error => console.error(error + "AQQUIII"));
}

function crear_Chofer( cooperativaId, personaRolId, vehiculoId) {

    let Chofer =
    {
       
        "cooperativaId": cooperativaId,
        "presonaRolId": personaRolId,
        "vehiculoId": vehiculoId,
        "estadoChoferId": estadoChoferId,
        "createdBy": 1,
    }
    console.log(Chofer);
    fetch('http://localhost:59454/Chofer/', {
        method: 'POST',
        body: JSON.stringify(Chofer),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(r => console.log(r)).catch(err => alert("Error al ingresar el Chofer"));
}
function listarOperador() {
    var controller = '"CrudOperador"';
    var action = '"Index"';
    var classa = '"nav-link text-dark button primary"';

    var areas = '" "';
    var hss = '"/busquedaOperador/Index"';
    const url = 'http://localhost:59454/Persona/'
    fetch(url)
        .then(response => response.json())
        .then(data => {
            let listaV2 = document.querySelector('#listaVase');
            listaV2.innerHTML = '';
            for (let item of data) {
                listaV2.innerHTML += "<tr><td>" + item.idPersona + "</td><td>" + item.nombrePersona + "</td>" +
                    "<td>" + item.apellidosPersona + "</td><td>" + item.telefonoPersona + "</td></tr>";
            }
        })
        .catch(
        )
}
function crear_Vehiculo() {

   

    let Vehiculo =
    {

        "cooperativaId": sessionStorage.getItem('id_cooperativa'),
        "vehiculoPlacaVehiculo": document.getElementById('Placa').value,
        "vehiculoColorVehiculo": document.getElementById('Color').value,
        "createdBy": sessionStorage.getItem('id_persona'),
    }
    fetch('http://localhost:59454/Vehiculo/', {

        method: 'POST',
        body: JSON.stringify(Vehiculo),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(r => {
        var a = 1
        alert("Se han guardado los cambios")
        location.href = '/VehiCRUDController2/Index'
        //listarVehiculos();
    }
    )
        .catch(error => alert("Error al ingresar el Vehículo"))
    
}

function crear_Cooperativa() {


    var idPersonarol = document.getElementById('idPersonarol').value;
    var nombrecoop = document.getElementById('nombrecoop').value;
    var direccionCoop = document.getElementById('direccionCoop').value;
    var telefonoCoop = document.getElementById('telefonoCoop').value;

    let Cooperativa =
    {
        "idPersonarol": idPersonarol,
        "nombrecoop": nombrecoop,
        "direccionCoop": direccionCoop,
        "telefonoCoop": telefonoCoop,
        "createdBy": 1,
    }
    console.log(Cooperativa);
    fetch('http://localhost:59454/Cooperativa/', {
        method: 'POST',
        body: JSON.stringify(Cooperativa),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(r => console.log(r)).catch(err => alert("Error al ingresar la Copperativa"));
}



function eliminar_Vehiculo(id_vehiculo) {
    var confirmacion = confirm("Desea Eliminar el vehículo con id: " + id_vehiculo);
    if (confirmacion) {
        const url = 'http://localhost:59454/Vehiculo/' + id_vehiculo + '/' + sessionStorage.getItem('id_persona')
        fetch(url, {
            method: 'Delete',
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(r => {
            var a = 1
            alert("Se han guardado los cambios")
            location.href = '/VehiCRUDController2/Index'
    
        }).catch(err => alert("Error al Eliminar el vehiculo"));
    } else {
        alert("Cancelado");
    }
}

function actualizar(id_vehiculo) {
    const url = 'http://localhost:59454/Vehiculo/' + id_vehiculo
    Promise(fetch(url)
        .then(response => response.json())
        .then(data => {
        console.log(data)
            sessionStorage.setItem('vehiculoId', id_vehiculo);
            sessionStorage.setItem('cooperativaIdV', data['cooperativaId']);
            sessionStorage.setItem('vehiculoPlacaVehiculo', data['vehiculoPlacaVehiculo']);
            sessionStorage.setItem('vehiculoColorVehiculo', data['vehiculoColorVehiculo']);
            location.href = '/EditVehiculo/Index';
        }))
        .catch(err => alert("Error al seleccionar el Vehiculo")
        )  
}
function valoresVehiculo() {
   
    var padreP = document.getElementById("PlacaV");
    var input = document.createElement("INPUT");
    input.type = 'text';
    input.name = "Pl";
    input.id = "Placa";
    input.placeholder = "Ingrese la Placa del vehiculo";
    input.value = sessionStorage.getItem('vehiculoPlacaVehiculo');
    padreP.appendChild(input);
    var padreC = document.getElementById("ColorV");
    var input = document.createElement("INPUT");
    input.type = 'text';
    input.name = "Cl";
    input.id = "Color";
    input.placeholder = "Ingrese el Color del vehiculo";
    input.value = sessionStorage.getItem('vehiculoColorVehiculo');
    padreC.appendChild(input);  
}
function actualizar_Vehiculo() {
    var confirmacion = confirm("Desea Guardar los cambios el vehículo con id: " + sessionStorage.getItem('vehiculoId'));
    if (confirmacion) {
        let Vehiculo =
        {

            "cooperativaId": sessionStorage.getItem('id_cooperativa'),
            "vehiculoPlacaVehiculo": document.getElementById('Placa').value,
            "vehiculoColorVehiculo": document.getElementById('Color').value,
            "modifiedBy": sessionStorage.getItem('id_persona'),
        }
        fetch('http://localhost:59454/Vehiculo/' + sessionStorage.getItem('vehiculoId'), {

            method: 'PUT',
            body: JSON.stringify(Vehiculo),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(r => {
            var a = 1
            alert("Se han guardado los cambios")
            location.href = '/VehiCRUDController2/Index'
        }).catch(error => alert("Error al actualizar el Vehículo"))

    } else {
        alert("No se han guardado los cambios");
    }
}

