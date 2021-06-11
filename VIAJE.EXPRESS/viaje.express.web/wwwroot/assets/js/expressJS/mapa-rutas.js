import { url } from './env.js';
var token;
var id_cooperativa;
var id_ruta;
const url_ruta = `${url}/Ruta`
var map;
var consult = {
    "offset": 0,
    "limit": 500
}
$(function () {
    token = localStorage.getItem('id_token');
    id_cooperativa = localStorage.getItem('id_cooperativa');
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
    obtenerRutas();

});

function obtenerRutas() {
    var rutas = [];
    var map = {};
    $('#rutas').typeahead({
        source: function (query, result) {
            rutas = [];
            map = {};
            $.ajax({
                headers: _headers(token),
                url: `${url_ruta}/Listar/` + id_cooperativa,
                type: "POST",
                data: JSON.stringify(consult),
                dataType: "json",
                success: function (data) {
                    if (data.exito) {
                        data.data.forEach(ruta => {
                            if (ruta.activo) {
                                map[ruta.nombre_ruta] = ruta;
                                rutas.push(ruta.nombre_ruta);
                            }
                        });
                        result(rutas);
                    } else {
                        mensajeError(data.mensaje);
                    }
                }
            })
        },
        updater: function (item) {
            id_ruta = map[item].id_ruta;
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

$('#obtene_ruta').click(function () {
    if (id_ruta != null) {
        $.ajax({
            headers: _headers(token),
            url: `${url_ruta}/` + id_ruta,
            dataType: "json",
            success: function (data) {
                if (data.exito) {
                    L.Routing.control({
                        show: false,
                        waypoints: [
                            L.latLng(data.data.origen_lat, data.data.origen_lng),
                            L.latLng(data.data.destino_lat, data.data.destino_lng)
                        ],
                        language: 'es'
                    }).addTo(map);
                } else {
                    mensajeError(data.mensaje);
                }
            },
            error: function (err) {
                console.log(err);
            }

        });

    }
}); 
