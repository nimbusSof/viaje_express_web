
function crearChofer() {
    var idPersonaRol

    // esta seccion permite ingresar un registro en la tabla persona_rol usando el id de la persona seleccionada el id rol por defecto de un chofer 

    fetch('http://localhost:59454/PersonaRol', {
        method: 'POST',
        body: JSON.stringify({
            "personaId": document.getElementById("Chofer").value,
            "rolId": 6,
            "estadoPersonaId": 1,
            "createdBy": 1
        }),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(function () {

        // esta seccion permite  capturar el id de persona rol que se ingreso anteriormente ejecutando un procedure que me permita 
        //obtenerlo ingresando el id de la persona y el rol
        fetch('http://localhost:59454/PersonaRol/' + document.getElementById("Chofer").value + '/' + 6)
            .then(response => response.json())
            .then(data => {
                idPersonaRol = data['personaRolId']
            })
            .then(function () {


                // esta seccion permite ingresar un chofer                  

                fetch('http://localhost:59454/Chofer/', {
                    method: 'POST',
                    body: JSON.stringify({
                        "cooperativaId": 5,
                        "personaRolId": idPersonaRol,
                        "vehiculoId": document.getElementById("Vehiculo").value,
                        "estadoChoferId": 1,
                        "createdBy": 1,
                    }),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(response => response.json())
                    .then(data => {
                        var i = data.choferId
                        fetch('http://localhost:59454/Chofer/2/5/' + i)
                            .then(response => response.json())
                            .then(data => {

                                var result
                                if (data.estadoChoferId == 1) {
                                    result = "<td>ACTIVO</td>"
                                } else {
                                    result = "<td>INACTIVO</td>"
                                }

                                $("#contenido").append($("<tr id='" + data.choferId + "'>" +
                                    " <th scope=row>" + data.choferId + "</th>" +
                                    "<td>" + data.personaNombre + "</td>" +
                                    "<td>" + data.personaApellidos + "</td>" +

                                    "<td>" + data.cooperativaNombre + "</td>" +
                                    "<td>" + data.vehiculoId + "</td>" +

                                    result +
                                    "<td>" +
                                    "<button type='button' id='modificar' value='" + data.choferId + "' onclick='modificarChofer(this)'>Modificar</button>" + "</td > " +
                                    "<td>" +
                                    "<button type='button' id='eliminar' value='" + data.choferId + "' onclick='eliminarChofer(this)'>Eliminar</button>" + "</td > " +

                                    "</tr >"

                                ));





                            })



                    }).catch(err => alert("Error al ingresar el Chofer"));




            }).catch(err => alert("Error al ingresar el Chofer"))


    }).catch(err => alert("Chofer no encontrado"))


}

var estado
var ideChofer
function modificarChofer(numero) {
    idechofer = numero.value
    alert(numero.value)

    flotante(1)
    obtenerChofer(numero.value)
}


function flotante(tipo) {

    if (tipo == 1) {
        //Si hacemos clic en abrir mostramos el fondo negro y el flotante
        $('#contenedor').show();
        $('#flotante').animate({
            marginTop: "-152px"
        });
    }
    if (tipo == 2) {
        //Si hacemos clic en cerrar, deslizamos el flotante hacia arriba
        $('#flotante').animate({
            marginTop: "-756px"
        });
        //Una vez ocultado el flotante cerramos el fondo negro
        setTimeout(function () {
            $('#contenedor').hide();

        }, 500)
    }

}


function act() {
    var v;
    if ((v = $("#check:checked").val()) != null) {
        alert('activado')
    } else { alert('desactivado') }
}
var choferId, cooperativaId, personaRolId, vehiculoId, estadoChofer, modifiedBy

function obtenerChofer(chofer) {
    var v;
    var c = chofer;


    fetch('http://localhost:59454/Chofer/' + c)
        .then(response => response.json())
        .then(data => {
            choferId = data.choferId
            cooperativaId = data.cooperativaId,
                personaRolId = data.personaRolId,
                vehiculoId = data.vehiculoId,
                estadoChofer = data.estadoChoferId

        }).then(function () {

            if (estadoChofer == 1) {
                document.getElementById('check').checked = true
            }




        })
        .catch(err => alert("Error al obtener el Chofer"))


}

function guardarChofer() {
    var v
    vehiculo = document.getElementById('miSelect').value
    var activo;
    if (document.getElementById('check').checked) {
        activo = 1
    } else { activo = 2 }
    var id = choferId
    var ptt = personaRolId



    fetch('http://localhost:59454/Chofer/' + choferId, {

        method: 'PUT',
        body: JSON.stringify({
            "cooperativaId": cooperativaId,
            "personaRolId": personaRolId,
            "vehiculoId": vehiculo,
            "estadoChoferId": activo,
            "modifiedBy": 1
        }),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(r => {
        var a = 1
        alert("Se han guardado los cambios")

        fetch('http://localhost:59454/Chofer/2/5/' + choferId)
            .then(response => response.json())
            .then(data => {

                var result
                if (data.estadoChoferId == 1) {
                    result = "<td>ACTIVO</td>"
                } else {
                    result = "<td>INACTIVO</td>"
                }

                var table = document.getElementById(choferId);
                table.innerHTML = "";
                table.innerHTML = "<th scope=row>" + data.choferId + "</th>" +
                    "<td>" + data.personaNombre + "</td>" +
                    "<td>" + data.personaApellidos + "</td>" +

                    "<td>" + data.cooperativaNombre + "</td>" +
                    "<td>" + data.vehiculoId + "</td>" +

                    result +
                    "<td>" +
                    "<button type='button' id='modificar' value='" + data.choferId + "' onclick='modificarChofer(this)'>Modificar</button>" + "</td > " +
                    "<td>" +
                    "<button type='button' id='eliminar' value='" + data.choferId + "' onclick='eliminarChofer(this)'>Eliminar</button>" + "</td > ";

                var r = 1




                flotante(2)




            })









    }).catch(error => alert("Error al actualizar el Vehículo"))





}


function eliminarChofer(idChofer) {

    var p = idChofer.value


    fetch('http://localhost:59454/Chofer/' + idChofer.value, {
        method: 'DELETE'

    }).then(res => {
        alert('Chofer Eliminado')

        eliminar(idChofer.value)


    }).catch(err => alert("Error al eliminar el Chofer"))

}



function cargar() {
    var contenido = document.querySelector('#contenido')
    //obtenerlo ingresando el id de la persona y el rol
    fetch('http://localhost:59454/Chofer/2/5')
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            data.forEach(function (element) {
                var result
                if (element.estadoChoferId == 1) {
                    result = "<td>ACTIVO</td>"
                } else {
                    result = "<td>INACTIVO</td>"
                }

                $("#contenido").append($("<tr id='" + element.choferId + "'>" +
                    " <th scope=row>" + element.choferId + "</th>" +
                    "<td>" + element.personaNombre + "</td>" +
                    "<td>" + element.personaApellidos + "</td>" +

                    "<td>" + element.cooperativaNombre + "</td>" +
                    "<td>" + element.vehiculoId + "</td>" +

                    result +
                    "<td>" +
                    "<button type='button' id='modificar' value='" + element.choferId + "' onclick='modificarChofer(this)'>Modificar</button>" + "</td > " +
                    "<td>" +
                    "<button type='button' id='eliminar' value='" + element.choferId + "' onclick='eliminarChofer(this)'>Eliminar</button>" + "</td > " +

                    "</tr >"

                ));
            })
        })
}


function eliminar(i) {
    var table = document.getElementById(i);
    table.innerHTML = "";



}