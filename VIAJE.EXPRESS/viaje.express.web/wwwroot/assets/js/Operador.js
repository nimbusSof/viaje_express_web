
function crearOperador() {
    var idPersonaRol

    // esta seccion permite ingresar un registro en la tabla persona_rol usando el id de la persona seleccionada el id rol por defecto de un chofer 

    fetch('http://localhost:59454/PersonaRol', {
        method: 'POST',
        body: JSON.stringify({
            "personaId": document.getElementById("Operador").value,
            "rolId": 5,
            "estadoPersonaId": 1,
            "createdBy": 1
        }),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(function () {

        // esta seccion permite  capturar el id de persona rol que se ingreso anteriormente ejecutando un procedure que me permita 
        //obtenerlo ingresando el id de la persona y el rol
        fetch('http://localhost:59454/PersonaRol/' + document.getElementById("Operador").value + '/' + 5)
            .then(response => response.json())
            .then(data => {
                idPersonaRol = data['personaRolId']
            })
            .then(function () {


                // esta seccion permite ingresar un Operador                  

                fetch('http://localhost:59454/Operador/', {
                    method: 'POST',
                    body: JSON.stringify({
                        "cooperativaId": 5,
                        "presonaRolId": idPersonaRol,
                        "createdBy": 1,
                    }),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(function () {
                    var art = 1

                }).catch(err => alert("Error al ingresar el Operador"));




            }).catch(err => alert("Error al ingresar el Operador"))


    }).catch(err => alert("Chofer no encontrado"))


}