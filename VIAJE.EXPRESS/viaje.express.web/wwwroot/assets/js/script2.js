
function ingresar() {
   
    let datos = {
        "cedulaPersona": "1002955543",
        "nombrePersona": "EUGENIA",
        "apellidosPersona": "PERES BRIONES",
        "nacimientoPersona": "1995-05-09",
        "telefonoPersona": "0909093339",
        "direccionPersona": "QUITO",
        "correoPersona": "moka@utn.edu.ec",
        "contraseniaPersona": "123",
        "createdBy": 1,
        "personaNombreUsuario": "lidiansa"
    }
    const url = 'http://localhost:59454/Persona'
    fetch(url, {
        method: 'POST',
        body: JSON.stringify(datos),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(function (response) {

        var n=1

            return response.text
        })
        .catch(err => alert("Datos no ingresados") )

}










