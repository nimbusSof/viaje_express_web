import { url } from './env.js';
import { ruta_solicitud, end_point_vehiculo, db } from './firebas.js';
const url_opm = 'http://nominatim.openstreetmap.org';
var map;
var id_persona_rol = localStorage.getItem('id_usuario_rol');
var datatable;
var token = localStorage.getItem('id_token');
var routingControl;
var cliente = userCliente();
var LatLng1 = {}, LatLng2 = {};
var map_tipo_solicitud = obtenerTipoSolicitud();
$('#carrera').text(map_tipo_solicitud[1].descripcion)
$('#encomienda').text(map_tipo_solicitud[2].descripcion)
const url_cliente = `${url}/CuentaCliente`;

var consult = {
    "offset": 0,
    "limit": 500,
    "columna": '',
    "nombre": '',
    "sort": ''
}

var datos_solicitut = {
    "id_persona_rol": '',
    "origen_lat": '',
    "origen_lng": '',
    "destino_lat": '',
    "destino_lng": '',
    "distancia": '',
    "tiempo": '',
    "monto": '',
    "id_tipo_solicitud": '',
    "created_by": '',
    "fecha": '',
    "hora": '',
    "id_tipo_carrera": 1,
};

$(function () {
    obtenerHistoriaCarrerasJustoAhora();
    if ($('select#tipo_viaje').val() == 1) {
        $('#programar_viaje').hide();
    } else if ($('select#tipo_viaje').val() == 2) {
        $('#programar_viaje').show();
    }
    cuenta_cliente(id_persona_rol,
        cliente.cedula,
        cliente.nombre,
        cliente.apellido,
        cliente.genero);
    obtenerTipoSolicitud();
});



function userCliente() {
    var resultado = {};
    $.ajax({
        headers: _headers(token),
        url: `${url}/PerfilUsuario/${id_persona_rol}`,
        async: false,
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                resultado = data.data;
            } else {
                mensajeError(data.mensaje);
            }

        }
    });
    return resultado;
}


window.addEventListener('DOMContentLoaded', async (e) => {
    $('#mycity').val('');
    $('#searchcity').val('');
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
            //LatLng1 = { 'lat': -1.593281, 'lng': - 79.001367 };
            obtenerInformacionUbicacionActual(LatLng1);
            autocompletarBucarCiudad();
        })
    }
    var form = $("#myForm");
    $('#smartwizard').smartWizard({
        selected: 0,
        theme: 'default',
        autoAdjustHeight: true,
        transitionEffect: 'fade',
        showStepURLhash: false,
        lang: { next: 'Siguiente', previous: 'Atras' },
        toolbarSettings: {
            toolbarButtonPosition: 'right',
            showNextButton: true,
            showPreviousButton: true
        }
    });
    form.validate({
        errorPlacement: function errorPlacement(error, element) { element.after(error); },
        rules: {
            searchcity: {
                required: true
            }
        },
        messages: {
            searchcity: {
                required: 'El destino es requerido'
            }
        }
    });

    const obtenerDatos = (tipo_viaje) => {
        var tipo_carrera = $('input:radio[name=exampleRadios]:checked').val();
        var tipo_solicitud = document.getElementsByClassName('selected')[0].getAttribute('id');
        datos_solicitut.id_persona_rol = id_persona_rol;
        datos_solicitut.id_tipo_solicitud = tipo_solicitud;
        datos_solicitut.origen_lat = routingControl._selectedRoute.waypoints[0].latLng.lat;
        datos_solicitut.origen_lng = routingControl._selectedRoute.waypoints[0].latLng.lng;
        datos_solicitut.destino_lat = routingControl._selectedRoute.waypoints[1].latLng.lat;
        datos_solicitut.destino_lng = routingControl._selectedRoute.waypoints[1].latLng.lng;
        let distancia = routingControl._selectedRoute.summary.totalDistance / 1000;
        datos_solicitut.distancia = distancia;

        var _tiempo = routingControl._selectedRoute.summary.totalTime;
        datos_solicitut.tiempo = calcularTiempo(_tiempo);
        datos_solicitut.created_by = id_persona_rol;

        if (tipo_viaje == 1) {
            datos_solicitut.monto = distancia * 0.5;
        } else if (tipo_viaje == 2) {
            if (tipo_carrera == 1) {
                datos_solicitut.monto = distancia * 0.5;
            } else if (tipo_carrera == 2) {
                datos_solicitut.monto = (distancia * 0.5) / 3;
            }
            datos_solicitut.id_tipo_carrera = tipo_carrera;
            datos_solicitut.fecha = $("input#fechav").val();
            datos_solicitut.hora = $("input#horav").val();
        }


    }

    $('#smartwizard').on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {
        var elmForm = $("#form-step-" + stepNumber);
        var _tipo_viaje = $('select#tipo_viaje').val();
        var precio_viaje;
        if (stepDirection === 'forward' && elmForm) {
            if (stepNumber == 0) {
                if (_tipo_viaje == 1) {
                    $('#programando').hide();
                    $('#ahora').show();
                } else if (_tipo_viaje == 2) {
                    $('#ahora').hide();
                    $('#programando').show();
                }
            }
            if (stepNumber == 1) {
                let distancia = routingControl._selectedRoute.summary.totalDistance / 1000;
                if (_tipo_viaje == 1) {
                    precio_viaje = distancia * 0.5;
                    $('#precio_viaje_ahora').text(precio_viaje);
                    datos_solicitut.monto = precio_viaje;
                } else if (_tipo_viaje == 2) {
                    precio_viaje = distancia * 0.5;
                    $('#precio_viaje_prog_privado').text(precio_viaje);
                    let precio_compartido = precio_viaje / 3;
                    $('#precio_viaje_prog_compartido').text(precio_compartido);
                }
            }
            if (stepNumber == 2) {
                obtenerDatos(_tipo_viaje);
                $('#detalle_viaje').text(map_tipo_solicitud[datos_solicitut.id_tipo_solicitud].descripcion);
                $('#detalle_tiempo').text(datos_solicitut.tiempo);
                $('#detalle_precio').text(datos_solicitut.monto);
                let fecha_actual = new Date();
                console.log(fecha_actual.toLocaleDateString());
                datos_solicitut.fecha != "" ? $('#detalle_fecha').text(datos_solicitut.fecha) : $('#detalle_fecha').text(fecha_actual.toLocaleDateString());
            }
            // elmForm.validator('validate');
            // var elmErr = elmForm.children('.has-error');
            // if (elmErr && elmErr.length > 0) {
            //     return false;
            // }
            if ($('#myForm').valid()) {
                return true
            } else {
                return false
            }
        }
        return true;
    })



    $('.radio-group .radio').click(function () {
        $('.selected .fa').removeClass('fa-check');
        $('.radio').removeClass('selected');
        $(this).addClass('selected');
    });
    $('.btn-group').button();
});

const obtenerHistoriaCarrerasJustoAhora = () => {
    $.ajax({
        headers: _headers(token),
        url: `${url_cliente}/listar_historial_carreras_justo_ahora/${id_persona_rol}`,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            console.log(data);
            datatable = $("#tblhisto_carreras_ja").DataTable();
            datatable.destroy();
            if (data.exito) {
                datatable = $('#tblhisto_carreras_ja').DataTable({
                    ordering: false,
                    responsive: true,
                    autoWidth: false,
                    bFilter: false,
                    lengthChange: false,
                    bInfo: false,
                    data: data.data,
                    columns: [
                        { data: "id_agendar_solicitud_cliente" },
                        { data: "tipo_solicitud" },
                        { data: "nombre_chofer" },
                        { data: "placa" },
                        { data: "fecha_solicitud", "render": function (fecha) { return formatDate(fecha) } }
                        //{
                        //    data: "id_agendar_solicitud_cliente", "render": function (id) {
                        //        return '<button type="button" id="' + id + '" class="ver_solicitud btn btn-success btn-sm"><i class="fa fa-eye fa-lg"></i> Ver</button>';
                        //    }
                        //}
                    ]
                });
            } else {
                clearTable('#tblhisto_carreras_ja');
            }

        },
        error: function (err) {
            console.log(err);
        }
    });
}

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

$('#tipo_viaje').on('change', function () {
    if (this.value == 1) {
        $('#programar_viaje').hide();
    } else if (this.value == 2) {
        $('#programar_viaje').show();
    }
});

$('#solicitarCarrera').click(function () {
    var tipo_viaje = $('select#tipo_viaje').val();
    var url_tipo_viaje;

    if (tipo_viaje == 1) {
        url_tipo_viaje = `${url_cliente}/insertar_carrera_justo_ahora`;
    } else if (tipo_viaje == 2) {
        url_tipo_viaje = `${url_cliente}/insertar_carrera_programada`;
    }

    console.log(datos_solicitut);
    $.ajax({
        headers: _headers(token),
        url: url_tipo_viaje,
        type: "POST",
        data: JSON.stringify(datos_solicitut),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                cliente_solicitud_realtime(
                    datos_solicitut.id_persona_rol,
                    data.codigo,
                    datos_solicitut.origen_lat,
                    datos_solicitut.origen_lng,
                    datos_solicitut.destino_lat,
                    datos_solicitut.destino_lng,
                    datos_solicitut.fecha,
                    datos_solicitut.distancia,
                    datos_solicitut.tiempo,
                    datos_solicitut.monto,
                    datos_solicitut.id_tipo_solicitud);
                mensajeExitoCliente(data.mensaje);
                obtenerHistoriaCarrerasJustoAhora();
            } else {
                mensajeError(data.mensaje);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
});

const calcularTiempo = (tiemp) => {
    var tiem = tiemp / 60;
    var part_entera = Math.trunc(tiem);
    var part_decimal = tiem - part_entera;
    if (part_decimal > 0.49) {
        part_entera++;
    } else if (part_entera == 0) {
        part_entera = tiem;
    }
    return part_entera
}
const obtenerInformacionUbicacionActual = (LatLng) => {
    let _url = `${url_opm}/reverse?format=json&addressdetails=0&zoom=18&lat=${LatLng.lat}&lon=${LatLng.lng}`;
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        url: _url,
        dataType: "json",
        success: function (data) {
            $('#mycity').val(data.display_name);
        }
    })
}

function autocompletarBucarCiudad() {
    let _urlcity = `${url_opm}/search?city=Ayora&country=ecuador&county=cayambe&format=jsonv2`
    var ciudades = [];
    var map = {};
    $('#esperando').hide();
    $('#searchcity').typeahead({
        source: function (query, result) {
            ciudades = [];
            map = {};
            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                url: `${url_opm}/search?city=${query}&country=ecuador&format=jsonv2`,
                //url: _urlcity, &county=${query}
                dataType: "json",
                success: function (data) {
                    if (data.length > 0) {
                        data.forEach(city => {
                            map[city.display_name] = city;
                            ciudades.push(city.display_name);
                        });
                        result(ciudades);
                        $('#esperando').hide();
                    } else {
                        $('#esperando').show();
                    }
                }
            })
        },
        updater: function (item) {
            let destino = map[item];
            LatLng2 = { 'lat': destino.lat, 'lng': destino.lon };
            solicitarRuta(LatLng2);
            return item;
        },
        matcher: function (item) {
            if (item.toLowerCase().indexOf(this.query.trim().toLowerCase()) != -1) {
                return true;
            }
        },
        sorter: function (items) {
            return items.sort();
        },
        highlighter: function (item) {
            var regex = new RegExp('(' + this.query + ')', 'gi');
            return item.replace(regex, "<strong>$1</strong>");
        }

    });
}

const solicitarRuta = (LatLngdestino) => {
    if (!$.isEmptyObject(LatLng1) && !$.isEmptyObject(LatLngdestino)) {
        if (routingControl == undefined) {
            routingControl = L.Routing.control({
                show: false,
                waypoints: [
                    L.latLng(LatLng1.lat, LatLng1.lng),
                    L.latLng(LatLngdestino.lat, LatLngdestino.lng)
                ],
                language: 'es'
            }).addTo(map);
        } else {
            routingControl.getPlan().setWaypoints([
                L.latLng(LatLng1.lat, LatLng1.lng),
                L.latLng(LatLngdestino.lat, LatLngdestino.lng)
            ]);

        }
    }
}


//$('#solicitar').click(function () {
//    if (!$.isEmptyObject(LatLng1) && !$.isEmptyObject(LatLng2)) {
//        if (routingControl == undefined) {
//            routingControl = L.Routing.control({
//                show: false,
//                waypoints: [
//                    L.latLng(LatLng1.lat, LatLng1.lng),
//                    L.latLng(LatLng2.lat, LatLng2.lng)
//                ],
//                language: 'es'
//            }).addTo(map);
//        } else {
//            routingControl.getPlan().setWaypoints([
//                L.latLng(LatLng1.lat, LatLng1.lng),
//                L.latLng(LatLng2.lat, LatLng2.lng)
//            ]);

//        }
//    }
//});



////FIREBASE



const cuenta_cliente = (id_persona_rol, cedula, nombre, apellido, genero) => {
    db.ref(ruta_solicitud(id_persona_rol + "-id_persona_rol")).update({
        id_persona_rol,
        cedula,
        apellido,
        nombre,
        genero
    });
}
const cliente_solicitud_realtime = (id_persona_rol, id_agendar_solicitud_cliente, origen_lat, origen_lng,
    destino_lat, destino_lng, fecha, distancia, tiempo, monto, id_tipo_solicitud) => {
    db.ref(ruta_solicitud(id_persona_rol + "-id_persona_rol", 'solicitud_realtime')).update({
        id_agendar_solicitud_cliente,
        origen_lat,
        origen_lng,
        destino_lat,
        destino_lng,
        fecha,
        distancia,
        tiempo,
        monto,
        id_tipo_solicitud,
        id_estado_solicitud: 1
    });
    console.log('Si se guardo');
}



const obtener_info_chofer = (id_cooperativa, id_vehiculo) => {
    return db.ref(end_point_vehiculo + "/" + id_cooperativa + "-id_cooperativa/" +
        id_vehiculo + "-id_vehiculo").get();
}

const marcar_como_leido = (id_persona_rol, lista) => {
    for (let i = 0; i < lista.length; i++) {
        db.ref(ruta_solicitud(id_persona_rol + "-id_persona_rol", "notificaciones",
            lista[i].id_agendar_solicitud_cliente + "-id_solicitud")).update({
                read: true
            })
    }
}

// cliente notificaciones
var notificaciones = [];
window.addEventListener('DOMContentLoaded', async (e) => {
    await db.ref(ruta_solicitud(id_persona_rol + "-id_persona_rol", "notificaciones")).limitToLast(100).on('value',
        async (querySnapshot) => {
        notificaciones = [];
        let nro_notificaciones = 0;
        querySnapshot.forEach(doc => {
            let model_val = doc.val();
            if (!model_val.read) {
                nro_notificaciones++;
            }
            notificaciones.push(model_val)
        })


        // leer notificaciones
        var elem_nro_notificaciones = document.getElementById('nro_notificaciones');
        elem_nro_notificaciones.textContent = nro_notificaciones;

        // notificaciones
        //let btn = document.getElementById('notificaciones_cli');
        //btn.addEventListener('click', async (e) => {
        //    marcar_como_leido(id_persona_rol, notificaciones);
        //    let element_notificaciones = await document.getElementById("list_notificaciones_cli");
        //    element_notificaciones.innerHTML = "";
        //    console.log(' jhhas' + notificaciones.length);
        //    for (let i = 0; i < notificaciones.length; i++) {
        //        var model = await obtener_info_chofer(notificaciones[i].id_cooperativa,
        //            notificaciones[i].id_vehiculo);
        //        model = model.val();
        //        element_notificaciones.innerHTML += `
        //        <li>
        //            <div class="media">
        //                <div class="media-body">
        //                    <h5 class="notification-user">Solicitud aceptada</h5>
        //                    <p class="notification-msg">
        //                        Chofer: ${model.nombre} ${model.apellido}
        //                        <br>
        //                        Vehiculo: ${model.placa}
        //                                </p>
        //                    <span class="notification-time">hace 30 minutos</span>
        //                </div>
        //            </div>
        //        </li>`
        //    }

        //    //const btnCancelar = document.querySelectorAll('.btn-cancelar');
        //    //btnCancelar.forEach(btn => {
        //    //    btn.addEventListener('click', async (e) => {
        //    //        let elem = e.target.dataset.id;
        //    //        let v_elem = elem.split('-');
        //    //        let id_agen_solic_cli = parseInt(v_elem[0]);
        //    //        let id_per_rol = parseInt(v_elem[1]);
        //    //        console.log("cancelar")
        //    //        alert("cancelado")
        //    //    })
        //    //});
        //});

    })

});


$('#notificaciones_cli').click(async function () {

    marcar_como_leido(id_persona_rol, notificaciones);
    let element_notificaciones = document.getElementById("list_notificaciones_cli");
    element_notificaciones.innerHTML = "";
    console.log(' jhhas' + notificaciones.length);
    for (let i = 0; i < notificaciones.length; i++) {
        var model = await obtener_info_chofer(notificaciones[i].id_cooperativa,
            notificaciones[i].id_vehiculo);
        model = model.val();
        element_notificaciones.innerHTML += `
                    <li>
                        <div class="media">
                            <div class="media-body">
                                <h5 class="notification-user">Solicitud aceptada</h5>
                                <p class="notification-msg">
                                    Chofer: ${model.nombre} ${model.apellido}
                                    <br>
                                    Vehiculo: ${model.placa}
                                            </p>
                                <span class="notification-time">hace 30 minutos</span>
                            </div>
                        </div>
                    </li>`
    }
});