import { url } from './env.js';
var token;
var id_usuario_rol;
$(document).ready(function () {
    token = localStorage.getItem('id_token');
    id_usuario_rol = localStorage.getItem('id_usuario_rol');
    obtenerModulo();
});

function obtenerModulo() {
    let listarmodulo = document.getElementById('modulos');
    $.ajax({
        headers: _headers(token),
        url: `${url}/Modulo/${id_usuario_rol}`,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                var modul = data.data;
                modul.forEach((item) => {
                    listarmodulo.innerHTML += `
                  <li class="">
                    <a onclick="navegar('${item.ruta}')" class="waves-effect waves-dark">
                       <span class="pcoded-micon"> <i class="feather icon-command"></i> </span>
                       <span class="pcoded-mtext">${item.descripcion_modulo} </span>
                    </a>
                  </li>`
                });
            } else {

                console.log(data.mensaje);
            }
        }
    });  
}
