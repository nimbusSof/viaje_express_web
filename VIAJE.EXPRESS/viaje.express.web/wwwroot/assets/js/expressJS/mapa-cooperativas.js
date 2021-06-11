import { url } from './env.js';
var token;
var map;
const url_coop = `${url}/Cooperativa`;
let consult = {
    "offset": 0,
    "limit": 500
}
$(function () {
    token = localStorage.getItem('id_token');
    map = L.map('map1', {
        fullscreenControl: {
            pseudoFullscreen: false,
            position: 'topright'
        }}
  ).setView([0.04104004628590023, -78.14285258539633], 13);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    obtenerCoop();
});

function obtenerCoop() {
    let customIcon = new L.Icon({

        iconUrl: 'https://c8.alamy.com/compes/gknfe4/taxi-icono-metalico-distintivo-logo-accidentada-pictograma-pictograma-symbol-simbolo-comercial-coche-color-gknfe4.jpg',
        iconSize: [50, 50],
        iconAnchor: [25, 50]
    });
    $.ajax({
        headers: _headers(token),
        url: `${url_coop}/Listar`,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                let datos = data.data;
                datos.forEach((coop) => {
                    L.marker([coop.lat, coop.lng], {
                        draggable: true
                    }).bindPopup(coop.nombre).addTo(map);
                });
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Error al obtener los datos');
        }

    });
}
