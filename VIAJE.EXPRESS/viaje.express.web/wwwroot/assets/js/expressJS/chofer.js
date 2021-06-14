import { url } from './env.js';
import { ruta_vehiculos, end_point_solicitud, end_point_vehiculo, db } from './firebas.js';
var id_usuario_rol = localStorage.getItem('id_usuario_rol');
var id_cooperativa = localStorage.getItem('id_cooperativa');
var token = localStorage.getItem('id_token');
var datatable;
var chofer = obtenerChofer();
var vehiculo = obtenerVehiculo();
var routingControl;
var map_tipo_solicitud = obtenerTipoSolicitud();
var id_solicitud_cliente;
var fuera_servi = false;
$('#btn_finalizar').text('Fuera de servicio');
document.querySelector('.estadovehiculo').innerHTML = 'Estada Vehiculo: Libre';

var map;
var estadosV = {};
var LatLng1 = {}, LatLng2 = {};
var consult = {
    "offset": 0,
    "limit": 100,
    "columna": '',
    "nombre": '',
    "sort": ''
}

$(function () {
    obtenerEstadosVehiculo();
    listarSolicitudespendintes();
    obtenerHistorialCarrerasProgramadas();
    cuenta_chofer(
        id_cooperativa,
        chofer.id_vehiculo,
        id_usuario_rol,
        chofer.cedula,
        chofer.nombre,
        chofer.apellido,
        chofer.genero,
        chofer.placa);
});

function obtenerTipoSolicitud() {
    var t_solicitud = {}
    $.ajax({
        headers: _headers(token),
        url: `${url}/TipoSolicitud`,
        async: false,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                data.data.forEach((solicitud) => {
                    t_solicitud[solicitud.id_tipo_solicitud] = solicitud;
                });
            } else {
                console.log(data.mensaje);
            }

        }
    });
    return t_solicitud;
}

function carreraActuar(url_soliciud,id_soliciutd_c) {
    $.ajax({
        headers: _headers(token),
        url: `${url}/CuentaChofer/${url_soliciud}/${id_usuario_rol}`,
        type: 'PUT',
        data: JSON.stringify({ 'id_agendar_solicitud_cliente': id_soliciutd_c }),
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data.exito) {
                $('#infoEstadoCarrera').text(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }

        }
    });
}
window.addEventListener('DOMContentLoaded', async (e) => {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;
            //var latitude = -1.593281;
            //var longitude = - 79.001367;
            map = L.map('map1').setView([latitude, longitude], 13);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(map);
            L.marker([latitude, longitude], {
                draggable: false
            }).bindPopup('Estas aqui').addTo(map);
            LatLng1 = { 'lat': latitude, 'lng': longitude };
        })
    }

});



var empezar_ruta;
$('#iniciar').click(function () {

    if (id_solicitud_cliente != undefined) {
        empezarCarrera(2);
        carreraActuar('comenzar_carrera_cliente', id_solicitud_cliente);
       
    }
       
});
$('#espera').click(function () {
    if (id_solicitud_cliente != undefined)
        $('#infoEstadoCarrera').text('Carrera en espera');
});

function empezarCarrera(estadov) {
    cambiarEstadoVehiculo(estadov);
    var ruta_cli = routingControl._selectedRoute.coordinates;
    console.log('ruta cliente ', ruta_cli);
    let cont = 0;
    empezar_ruta = setInterval(function () {
        if (cont <= ruta_cli.length - 1) {
            console.log(ruta_cli[cont].lat + ' - ' + ruta_cli[cont].lng);
            vehiculo != null ? choferVehiculo_InsertarCoordenadas(id_cooperativa, vehiculo.id_vehiculo, id_usuario_rol, ruta_cli[cont].lat, ruta_cli[cont].lng) : console.log('No se encontro vehiculo');
        } else {
            clearInterval(empezar_ruta);
            cambiarEstadoVehiculo(1);
            alert('Termino el viaje');
        }
        cont++;
    }, 2000);
}

$('#finalizar').click(function () {
    if (id_solicitud_cliente != undefined) {
        cambiarEstadoVehiculo(1);
        carreraActuar('finalizar_carrera_cliente', id_solicitud_cliente);
        clearInterval(empezar_ruta);
    }
});

$('#fuera_servicio').click(function () {
    if (!fuera_servi) {
        fuera_servi = true;
        id_solicitud_cliente = undefined;
        cambiarEstadoVehiculo(3);
        $('#infoCliente').text('Ninguno');
        $('#infoCarrera').text('Ninguno');
        $('#infoEstadoCarrera').text('Ninguno');
        $('#btn_finalizar').text('Habilitar');
    } else {
        $('#btn_finalizar').text('Fuera de servicio');
        fuera_servi = false;
        cambiarEstadoVehiculo(1);
    }

    clearInterval(empezar_ruta);
});


function obtenerChofer() {
    var result = {};
    $.ajax({
        headers: _headers(token),
        async: false,
        url: `${url}/UsuarioChofer/${id_usuario_rol}`,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                result = data.data;
            } else {
                mensajeError(data.mensaje);
            }
        }
    });
    return result;
}


function obtenerHistorialCarrerasProgramadas() {
    $.ajax({
        headers: _headers(token),
        url: `${url}/CuentaChofer/listar_historial_carreras_justo_ahora/${id_usuario_rol}`,
        type: 'POST',
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data.exito) {
                datatable = $("#tblhistorial").DataTable();
                datatable.destroy();
                if (data.exito) {
                    datatable = $('#tblhistorial').DataTable({
                        ordering: false,
                        responsive: true,
                        autoWidth: false,
                        bFilter: false,
                        lengthChange: false,
                        bInfo: false,
                        data: data.data,
                        columns: [
                            { data: "id_agendar_solicitud_cliente" },
                            { data: "cedula_cliente" },
                            { data: "nombre_cliente" },
                            { data: "tipo_solicitud" },
                            {
                                data: "fecha_solicitud", "render": function (fecha) {
                                    return formatDate(fecha);
                                }
                            }
                            //,
                            //{
                            //    data: "id_agendar_solicitud_cliente", "render": function (id) {
                            //        return '<button type="button" id="' + id + '" class="ver_detalle btn btn-success btn-sm"><i class="fa fa-eye fa-lg"></i> Ver</button>';
                            //    }
                            //}
                        ]
                    });
                } else {
                    clearTable('#tblhistorial');
                }
            } else {
                console.log(data.mensaje);
            }
        }
    });
}



$(document).on('click', '.ver_detalle', function () {
    var id = $(this).attr('id');
    $('.modal-title').text('Detalle de la solicitud ' + id);
    $('#form_result').html('');
    $('#formModal').modal('show');
});

function obtenerEstadosVehiculo() {
    $.ajax({
        headers: _headers(token),
        url: `${url}/EstadoVehiculo`,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                data.data.forEach(estado => {
                    estadosV[estado.id_estado_vehiculo] = estado;
                })
            } else {
                mensajeError(data.mensaje);
            }
        }
    });
}

function obtenerVehiculo() {
    var datos = {};
    $.ajax({
        headers: _headers(token),
        url: `${url}/Vehiculo/${chofer.id_vehiculo}`,
        async: false,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                datos = data.data;
                document.querySelector('.infovehiculo').innerHTML = 'Vehiculo: ' + datos.placa;
            } else {
                console.log(data.mensaje);
            }

        }
    });
    return datos;
}




function cambiarEstadoVehiculo(estado) {
    $.ajax({
        headers: _headers(token),
        url: `${url}/CuentaChofer/cambiar_estado_vehiculo/${id_usuario_rol}`,
        type: 'PUT',
        data: JSON.stringify({ 'id_estado_vehiculo': estado }),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                document.querySelector('.estadovehiculo').innerHTML = 'Estada Vehiculo: ' + estadosV[estado].descripcion;
                choferVehiculo_CambiarEstadoVehiculo(id_cooperativa, vehiculo.id_vehiculo, id_usuario_rol, estado);
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Error al guardar datos del administrador');
        }
    });
}
function listarSolicitudespendintes() {
    $.ajax({
        headers: _headers(token),
        url: `${url}/CuentaChofer/listar_carreras_programadas`,
        type: 'POST',
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                notificacionesChofer(data.data);
            } else {
                console.log(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Error al obtener solicitudes');
        }
    });
}

$(document).on('click', '.aceptar', function () {
    var id_solicitud = $(this).attr('id');
    $.ajax({
        headers: _headers(token),
        url: `${url}/CuentaChofer/aceptar_solicitud_cliente/${id_usuario_rol}`,
        type: 'PUT',
        data: JSON.stringify({ 'id_agendar_solicitud_cliente': id_solicitud }),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                console.log(data.mensaje);
            } else {
                console.log(data.mensaje);
            }
        },
        error: function (err) {
            mensajeError('Error al obtener solicitudes');
        }
    });
});



///FIREBASE


const choferVehiculo_InsertarCoordenadas = (id_cooperativa, id_vehiculo, id_persona_rol, lat, lng) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo")).update({
        id_persona_rol,
        lat,
        lng,
        fecha: new Date().toDateString()
    })
    const insert = db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo", 'coords',
        id_persona_rol + "-id_persona_rol")).push()
    insert.set({
        lat,
        lng,
        fecha: new Date().toDateString()
    })
}
const choferVehiculo_CambiarEstadoVehiculo = (id_cooperativa, id_vehiculo, id_persona_rol, id_estado_vehiculo) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo")).update({
        id_persona_rol,
        id_estado_vehiculo
    })
}

// ejecutar cuando inicie sesion el chofer
const cuenta_chofer = (id_cooperativa, id_vehiculo, id_persona_rol, cedula, nombre, apellido, genero,placa) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo")).update({
        id_persona_rol,
        cedula,
        apellido,
        nombre,
        genero,
        placa
    });
}

const solicitud_cliente = (id_cooperativa, id_vehiculo, id_agendar_solicitud_cliente, id_persona_rol_cli) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo", "notificaciones",
        id_agendar_solicitud_cliente + "-id_solicitud")).update({
            id_agendar_solicitud_cliente,
            id_persona_rol_cli
        })
}



window.addEventListener('DOMContentLoaded', async (e) => {
    var id_vehiculo = chofer.id_vehiculo;
    db.ref(end_point_solicitud).on('value', (querySnapshot) => {
        querySnapshot.forEach(doc => {
            let model = doc.val();
            if (model.solicitud_realtime && model.solicitud_realtime.id_estado_solicitud == 1) {
                solicitud_cliente(id_cooperativa, id_vehiculo, model.solicitud_realtime.id_agendar_solicitud_cliente, model.id_persona_rol);

            } else {
                //console.log("[-]")
            }
        });
    })
});


///*-------------------------------------------------------*/
const chofer_aceptar_solicitud = (id_cooperativa,id_vehiculo, id_agendar_solicitud_cliente, id_persona_rol) => {
    db.ref(end_point_solicitud + "/" + id_persona_rol + "-id_persona_rol/notificaciones/" +
        id_agendar_solicitud_cliente + "-id_solicitud").set({
            id_agendar_solicitud_cliente,
            id_cooperativa,
            id_vehiculo,
            read: false
        });

    db.ref(end_point_solicitud + "/" + id_persona_rol + "-id_persona_rol/solicitud_realtime").update({
        id_estado_solicitud: 2
    });

    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo", "notificaciones",
        id_agendar_solicitud_cliente + "-id_solicitud")).update({
            cancelada: true
        });
}

const obtener_info_cliente = (id_persona_rol) => {
    return db.ref(end_point_solicitud + "/" + id_persona_rol + "-id_persona_rol").get();
}

const marcar_como_leido = (id_cooperativa, id_vehiculo, lista) => {
    for (let i = 0; i < lista.length; i++) {
        db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo", "notificaciones",
            lista[i].id_agendar_solicitud_cliente + "-id_solicitud")).update({
                read: true
            })
    }
}

const chofer_cancelar_solicitud = (id_cooperativa, id_vehiculo, id_agendar_solicitud_cliente) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo", "notificaciones",
        id_agendar_solicitud_cliente + "-id_solicitud")).update({
            cancelada: true
        });
}

// chofer notificaciones
window.addEventListener('DOMContentLoaded', async (e) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", vehiculo.id_vehiculo + "-id_vehiculo", "notificaciones")).on('value',
        async (querySnapshot) => {
            var notificaciones = [];
            let nro_notificaciones = 0;
            querySnapshot.forEach(doc => {
                let model_val = doc.val();

                if (!model_val.read) {
                    nro_notificaciones++;
                }

                if (!model_val.cancelada) { // si no existe entre y si existe y sea falso entre
                    notificaciones.push(model_val);
                }
            })

            // nro notificaciones
            const elem_nro_notificaciones = document.getElementById('nro_notificaciones');
            elem_nro_notificaciones.textContent = nro_notificaciones;

            // notificaciones
            const btn = document.getElementById('btn-notificaciones');
            btn.addEventListener('click', async (e) => {
                marcar_como_leido(id_cooperativa, vehiculo.id_vehiculo, notificaciones);
                const element_notificaciones = document.getElementById("list_notificaciones");
                element_notificaciones.innerHTML = ""
                for (let i = 0; i < notificaciones.length; i++) {
                    var model = await obtener_info_cliente(notificaciones[i].id_persona_rol_cli);
                    model = model.val();
                    element_notificaciones.innerHTML += `  
                                           <li>
                                            <div class="media">
                                                <div class="media-body">
                                                    <h4 class="notification-user">${model.nombre+' '+model.apellido}</h4>
                                                    <p class="notification-msg">Solicitud: ${map_tipo_solicitud[model.solicitud_realtime.id_tipo_solicitud].descripcion}</p>
                                                    <button type="button"  data-id="${notificaciones[i].id_agendar_solicitud_cliente}-${notificaciones[i].id_persona_rol_cli}-${i}"  class="btn-aceptar btn btn-success btn-mini waves-effect waves-light">Aceptar</button>                                                   
                                                    <button type="button"  data-id="${notificaciones[i].id_agendar_solicitud_cliente}-${notificaciones[i].id_persona_rol_cli}"  class="btn-cancelar btn btn-danger btn-mini waves-effect waves-light">Descartar</button>
                                                    <span class="notification-time">30 minutes ago</span>
                                                </div>
                                            </div>
                                        </li>`;
                }

                const btnAceptar = document.querySelectorAll('.btn-aceptar');
                btnAceptar.forEach(btn => {
                    btn.addEventListener('click', async (e) => {
                        let elem = e.target.dataset.id;
                        let v_elem = elem.split('-');
                        let id_agen_solic_cli = parseInt(v_elem[0]);
                        let id_per_rol = parseInt(v_elem[1]);
                        let identifi = parseInt(v_elem[2]);
                        chofer_aceptar_solicitud(id_cooperativa, vehiculo.id_vehiculo,
                            id_agen_solic_cli, id_per_rol);
                        var datosUsuario = await obtener_info_cliente(notificaciones[identifi].id_persona_rol_cli);
                        datosCarrera(datosUsuario.val(), id_agen_solic_cli);
                    })
                });

                const btnCancelar = document.querySelectorAll('.btn-cancelar');
                btnCancelar.forEach(btn => {
                    btn.addEventListener('click', async (e) => {
                        let elem = e.target.dataset.id;
                        let v_elem = elem.split('-');
                        let id_agen_solic_cli = parseInt(v_elem[0]);
                        let id_per_rol = parseInt(v_elem[1]);
                        chofer_cancelar_solicitud(id_cooperativa, vehiculo.id_vehiculo, id_agen_solic_cli)
                    })
                });
            });
        })
});

function datosCarrera(datos, idsolicitud) {
    $('#infoCliente').text(datos.nombre);
    console.log('datso ',datos);
    $('#infoCarrera').text(map_tipo_solicitud[datos.solicitud_realtime.id_tipo_solicitud].descripcion);
    id_solicitud_cliente = idsolicitud;
    carreraActuar('aceptar_solicitud_cliente', idsolicitud);
    cambiarEstadoVehiculo(2);
    obtenerHistorialCarrerasProgramadas();
    obtener_ruta_Cliente(datos);
}

function obtener_ruta_Cliente(cliente) {
    if (cliente != undefined) {
        if (routingControl == undefined) {
            routingControl = L.Routing.control({
                show: false,
                waypoints: [
                    L.latLng(cliente.solicitud_realtime.origen_lat, cliente.solicitud_realtime.origen_lng),
                    L.latLng(cliente.solicitud_realtime.destino_lat, cliente.solicitud_realtime.destino_lng)
                ],
                language: 'es'
            }).addTo(map);
        } else {
            routingControl.getPlan().setWaypoints([
                L.latLng(cliente.solicitud_realtime.origen_lat, cliente.solicitud_realtime.origen_lng),
                L.latLng(cliente.solicitud_realtime.destino_lat, cliente.solicitud_realtime.destino_lng)
            ]);

        }
    }

}