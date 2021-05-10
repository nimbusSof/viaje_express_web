
function validar() {
   

    const url = 'http://localhost:59454/Persona/' + document.getElementById("usuario").value+'/'+ document.getElementById("pass").value
    fetch(url)
        .then(response => response.json())
        .then(data => {
            const as = document.getElementById("usuario").value
          

            location.href = 'Cliente/Cliente'  
                     
          
        })
        .catch(err => alert("Usuario o contrasenia erroneos")

        )

}










