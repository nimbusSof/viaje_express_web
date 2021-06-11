import { url } from './env.js';
import { ruta_vehiculos, db } from './firebas.js';
var token = localStorage.getItem('id_token');
var id_cooperativa = localStorage.getItem('id_cooperativa');
var id_vehiculo;
var list_vehiculos;
const url_vehiculos = `${url}/Vehiculo`
var map;
var markers = {};
var consult = {
    "offset": 0,
    "limit": 500
}
var customIcon = new L.Icon({

    iconUrl: 'https://e7.pngegg.com/pngimages/826/619/png-clipart-yellow-car-top-view-yellow-car-top-view.png',
    iconSize: [50, 50],
    iconAnchor: [25, 50]
});
$(function () {
    map = L.map('map1', {
        fullscreenControl: {
            pseudoFullscreen: false,
            position: 'topright'
        }
    }
    ).setView([0.04104004628590023, -78.14285258539633], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    autocompletarBucarPlaca();
});





const deleteUbicacionVehiculo = (id_vehiculo, id) => db.ref(ruta_vehiculos(id_vehiculo, id)).remove();

// obtener ultimo registro ingresado
const getUltimaUbicacionVehiculo = (id_vehiculo) => db.ref(ruta_vehiculos(id_vehiculo)).limitToLast(1).get();

const getUbicacionVehiculo = (id_vehiculo, limit) => db.ref(ruta_vehiculos(id_vehiculo)).limitToLast(limit).get();

const updateUbicacionVehiculo = (id_vehiculo, id, updateUbicVeh) => firebase.database().ref(ruta_vehiculos(id_vehiculo, id)).update(updateUbicVeh);


const getListUbicacionPorIdVehiculo = async (id_vehiculo, limite) => {
    var snapshot = await getUbicacionVehiculo(id_vehiculo, limite);
    let list_ubicacion_vehiculo = []
    snapshot.forEach(doc => {
        let ubic_vehi = doc.val();
        // unshift -> agrega elemento en la primera pos
        list_ubicacion_vehiculo.unshift({
            id: doc.key,
            id_vehiculo: ubic_vehi.id_vehiculo,
            id_persona_rol: ubic_vehi.id_persona_rol,
            lat: ubic_vehi.lat,
            lng: ubic_vehi.lng,
            fecha: ubic_vehi.fecha
        })
    })
    return list_ubicacion_vehiculo;
}



window.addEventListener('DOMContentLoaded', async (e) => {
    console.log('idcoop ', id_cooperativa);
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa")).on('value',  (querySnapshot) => {
        console.log('querySnapshot ', querySnapshot);
        let list_ultima_ubicacion_vehiculos = [];
        querySnapshot.forEach(doc => {
            let veh = doc.val()
            if (veh.activo && !veh.eliminado && (veh.id_estado_vehiculo == 1 || veh.id_estado_vehiculo == 2) &&
                veh.lat && veh.lng) {
                list_ultima_ubicacion_vehiculos.push({
                    id_cooperativa: veh.id_cooperativa,
                    id_vehiculo: veh.id_vehiculo,
                    placa: veh.placa,
                    id_persona_rol: veh.id_persona_rol,
                    lat: veh.lat,
                    lng: veh.lng
                })
            }
        });
        list_ultima_ubicacion_vehiculos.forEach(vehiculo => {
            if (markers[vehiculo.id_vehiculo] == undefined) {
                markers[vehiculo.id_vehiculo] =
                    L.marker([vehiculo.lat, vehiculo.lng], {
                        draggable: false
                    }).bindPopup(vehiculo.placa).addTo(map);
            } else {
                markers[vehiculo.id_vehiculo].setLatLng([vehiculo.lat, vehiculo.lng]);
            }

        });
        list_vehiculos = list_ultima_ubicacion_vehiculos
        console.log(list_ultima_ubicacion_vehiculos);

    })
});


function autocompletarBucarPlaca() {
    var vehiculos = [];
    var map = {};
    $('#vehiculos').typeahead({
        source: function (query, result) {
            vehiculos = [];
            map = {};
            $.ajax({
                headers: _headers(token),
                url: `${url_vehiculos}/Listar/` + id_cooperativa,
                type: "POST",
                data: JSON.stringify(consult),
                dataType: "json",
                success: function (data) {
                    if (data.exito) {
                        data.data.forEach(vehiculo => {
                            if (vehiculo.activo) {
                                map[vehiculo.placa] = vehiculo;
                                vehiculos.push(vehiculo.placa);
                            }
                        });
                        result(vehiculos);

                    } else {
                        mensajeError(data.mensaje);
                    }
                }
            })
        },
        updater: function (item) {
            id_vehiculo = map[item].id_vehiculo;
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

$('#obtene_vehiculo').click(function () {
    if (id_vehiculo != null) {
        list_vehiculos.forEach(vehiculo => {
            if (vehiculo.id_vehiculo == id_vehiculo) {
                map.flyTo([vehiculo.lat, vehiculo.lng], 18);
            }
        });


    }
}); 
