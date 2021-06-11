var _token = localStorage.getItem('id_token');
var id_cooper = localStorage.getItem('id_cooperativa');
$(document).ready(function () {
    if (localStorage.getItem('id_token') == null) {
        location.href = '../Home/Index';
    }
        ObtenerDatosCooperativa();
    
});
const navegar = (ruta) => {
    location.href = `../${ruta}`;
}

const cerrar_sesion = () => {
    localStorage.clear();
    navegar('Home/Index');
}

const mensajeVehiculo = (titulo, mensaje) => {
    swal({
        title: titulo,
        text: mensaje,
        type: 'success',
        showConfirmButton: false,
        timer: 2000,
    });
}
const mensajeExito = (mensaje) => {
    swal({
        title: 'Correcto',
        text: mensaje,
        type: 'success',
        showConfirmButton: false,
        timer: 1500,
    });
}
const mensajeExitoCliente = (mensaje) => {
    swal({
        title: 'Correcto',
        text: mensaje,
        type: 'success',
        showConfirmButton: true,
        timer: 5000,
    });
}

const mensajeError = (mensaje) => {
    swal({
        title: 'Error',
        text: mensaje,
        showConfirmButton: false,
        type: 'error',
        timer: 1500,
    });
}

const _headers = (token) => {
    return {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'token': token
    };
}

const formatDate = (fecha) => {
    var elems = fecha.split('T');
    return elems[0];
}


const resetearClave = (modulo, id_usuario, token) => {
    $.ajax({
        headers: _headers(token),
        url: `${modulo}/reset_clave/` + id_usuario,
        type: "PUT",
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                mensajeExito(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Se produjo un error durante la ejecucion.');
        }
    });
}

const clearTable = (tbl) => {
    datatable = $(tbl).DataTable({
        ordering: false,
        responsive: true,
        autoWidth: false,
        bFilter: false,
        lengthChange: false,
        bInfo: false
    });
    datatable.clear().draw();
}


const notificacionesChofer = (lista) => {
    let notificaciones = document.getElementById('list_notificaciones');
    var cliente;
    var mensaje;
    if (lista.length != 0) {
        $('#num_notificacion').text(lista.length);
        $('#num_notificacion').show();
        lista.forEach(nofificacion => {
            notificaciones.innerHTML += `  <li>
                                            <div class="media">
                                                <div class="media-body">
                                                    <h4 class="notification-user">${nofificacion.nombre_cliente + ' ' + nofificacion.apellido_cliente}</h4>
                                                    <p class="notification-msg">${nofificacion.tipo_solicitud+' '+nofificacion.tipo_carrera}</p>
                                                    <button type="button" id="${nofificacion.id_agendar_solicitud_cliente}"  class="aceptar btn btn-success btn-mini waves-effect waves-light">Aceptar</button>                                                   
                                                    <button type="button"  id="${nofificacion.id_agendar_solicitud_cliente}"  class="descartar btn btn-danger btn-mini waves-effect waves-light">Descartar</button>
                                                    <span class="notification-time">30 minutes ago</span>
                                                </div>
                                            </div>
                                        </li>`;
        });
    } else {
        $('#num_notificacion').hide();
        notificaciones.innerHTML = `  <li>
                                            <div class="media">
                                                <div class="media-body">
                                                    <p class="notification-msg">No hay notificaciones</p>
                                                </div>
                                            </div>
                                        </li>`;
    }


}

function ObtenerDatosCooperativa() {
    if (id_cooper !== 'undefined') {
        $.ajax({
            headers: _headers(_token),
            url: `http://localhost:59454/Cooperativa/${id_cooper}`,
            dataType: "json",
            success: function (data) {
                if (data.exito) {
                    document.querySelector('.informacion').innerHTML = 'Cooperativa: ' + data.data.nombre;
                } else {
                    mensajeError(data.mensaje);
                }

            }
        });
    }
}