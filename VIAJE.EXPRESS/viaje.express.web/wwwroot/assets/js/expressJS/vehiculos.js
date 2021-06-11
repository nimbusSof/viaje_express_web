import { url } from './env.js';
import { ruta_vehiculos, db } from './firebas.js';
var datatable;
var token = localStorage.getItem('id_token');
var id_usuario_rol = localStorage.getItem('id_usuario_rol');
var id_cooperativa = localStorage.getItem('id_cooperativa');
const url_vehiculos = `${url}/Vehiculo`
var consult = {
    "offset": 0,
    "limit": 5,
    "columna": '',
    "nombre": '',
    "sort": ''
}

$(function () {
    obtenerVehiculos();
    //obtenerVehiculosFirebase();
});



window.addEventListener('DOMContentLoaded', async (e) => {
    var estado_vehiculo = ["Libre", "Ocupado", "Fuera de servicio"];
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa")).on('value', (querySnapshot) => {
        let list_ultima_ubicacion_vehiculos = [];
        querySnapshot.forEach(doc => {
            let veh = doc.val()


            let id_veh = document.getElementById(veh.id_vehiculo + '-id_vehiculo');
            if (id_veh) {
                id_veh.parentElement.parentElement.children[3].textContent = estado_vehiculo[veh.id_estado_vehiculo - 1];
            }

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
    })
});






function obtenerVehiculos() {
    $.ajax({
        headers: _headers(token),
        url: `${url_vehiculos}/Listar/` + id_cooperativa,
        type: "POST",
        data: JSON.stringify(consult),
        dataType: "json",
        success: function (resp) {
            datatable = $("#tblVehiculo").DataTable();
            datatable.destroy();
            if (resp.exito) {
                datatable = $('#tblVehiculo').DataTable({
                    ordering: false,
                    responsive: true,
                    autoWidth: false,
                    bFilter: false,
                    lengthChange: false,
                    bInfo: false,
                    data: resp.data,
                    columns: [
                        {
                            data: "id_vehiculo", "render": function (data) {

                                return '<div id="' + data + '-id_vehiculo">' + data + '</div>';
                            }
                        },
                        { data: "placa" },
                        { data: "matricula" },
                        { data: "estado_vehiculo" },
                        {
                            data: "activo", "render": function (data) {
                                if (data) {
                                    return "Activo"
                                } else {
                                    return "Desactivo"
                                }
                            }
                        },
                        {
                            data: "id_vehiculo", "render": function (data) {
                                var id = data;
                                return '<button type="button"  name="edit" id="' + id + '"  class="edit btn btn-primary btn-sm"> <i class="fa fa-edit fa-lg"></i></button> <button type="button"   name="delete" id="' + id + '" class="delete btn btn-danger btn-sm"><i class="fa fa-trash fa-lg"></i> </button>';
                            }
                        }
                    ]
                });
            } else {
                clearTable('#tblVehiculo');
            }

        },
        error: function (err) {
            console.log(err);
        }
    });
}

$('#crear_vehiculo').click(function () {
    $('.modal-title').text('Agregar nuevo Vehiculo');
    $('#action_button').val('Add');
    $('#action').val('Add');
    $('#act').hide();
    $('#form_result').html('');
    $('#formulario_vehiculo').trigger("reset");
    $('#formModal').modal('show');
    $('.error').hide();
});


$('#formulario_vehiculo').on('submit', function (event) {
    $('.error').hide();
    var placa = $("input#placa").val();
    if (placa == "") {
        $("label#placa_error").show();
        $("input#placa").focus();
        return false;
    }
    var matricula = $("input#matricula").val();
    if (matricula == "") {
        $("label#matricula_error").show();
        $("input#matricula").focus();
        return false;
    }
    var color = $("input#color").val();
    if (color == "") {
        $("label#color_error").show();
        $("input#color").focus();
        return false;
    }
    var activo = document.getElementById("activo");
    var vehiculo = {
        "id_cooperativa": id_cooperativa,
        'placa': placa,
        'matricula': matricula,
        "activo": activo.checked,
        'color': color,
        "created_by": id_usuario_rol,
        "modified_by": id_usuario_rol
    };

    let id_vehiculo = $('#hidden_id').val();
    let type_method = '';
    var action_url = '';
    if ($('#action').val() == 'Add') {
        action_url = url_vehiculos;
        type_method = 'POST'
    }
    if ($('#action').val() == 'Edit') {
        action_url = `${url_vehiculos}/${id_vehiculo}`;
        type_method = 'PUT'
    }
    $.ajax({
        headers: _headers(token),
        url: action_url,
        type: type_method,
        data: JSON.stringify(vehiculo),
        dataType: "json",
        success: function (data) {
            if (data.exito) {
                $('#formModal').modal('hide');
                type_method == 'POST' ?
                    operador_InsertarVehiculo(id_cooperativa, data.codigo, placa) :
                    operador_ActualizarVehiculoEstado(id_cooperativa, id_vehiculo, activo.checked);
                obtenerVehiculos();
                mensajeExito(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Error al ingresar los datos del vehiculo');
        }
    });
    return false;
});


$(document).on('click', '.edit', function () {
    $('.error').hide();
    $('#act').show();
    var id = $(this).attr('id');
    $('#form_result').html('');
    $.ajax({
        headers: _headers(token),
        url: `${url_vehiculos}/${id}`,
        dataType: "json",
        success: function (resp) {
            $('#placa').val(resp.data.placa);
            $('#matricula').val(resp.data.matricula);
            $('#color').val(resp.data.color);
            document.getElementById("activo").checked = resp.data.activo;
            $('#hidden_id').val(id);
            $('.modal-title').text('Editar Vehiculo');
            $('#action_button').val('Edit');
            $('#action').val('Edit');
            $('#formModal').modal('show');
        }
    });
});




$(document).on('click', '.delete', function () {
    let vehiculo_id = $(this).attr('id');
    swal({
        title: "¿Esta seguro de eliminar?",
        text: "Al eliminar el vehiculo no podra ser asignado a un chofer.",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar!",
        closeOnConfirm: false
    },
        function () {
            eliminarVehiculo(vehiculo_id);
        });
});


function eliminarVehiculo(idvehiculo) {
    $.ajax({
        headers: _headers(token),
        url: `${url_vehiculos}/${idvehiculo}`,
        type: 'DELETE',
        dataType: "json",
        data: JSON.stringify({ "deleted_by": id_usuario_rol }),
        success: function (data) {
            if (data.exito) {
                operador_EliminarVehiculo(id_cooperativa, idvehiculo);
                obtenerVehiculos();
                mensajeExito(data.mensaje);
            } else {
                mensajeError(data.mensaje);
            }

        },
        error: function (err) {
            mensajeError('Ocurrio un error en la ejecución');
        }
    });
}

//*****************************FIREBASE************************************//

const operador_InsertarVehiculo = (id_cooperativa, id_vehiculo, placa) => {
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo")).set({
        id_cooperativa,
        id_vehiculo,
        placa,
        id_estado_vehiculo: 3,
        activo: true,
        eliminado: false
    });

}

const operador_ActualizarVehiculoEstado = (id_cooperativa, id_vehiculo, activo) => {
    console.log('Actualizado: ', id_cooperativa, ' ', id_vehiculo, ' ', activo);
    const insertUbicacionVehiculo = db.ref(ruta_vehiculos(id_cooperativa, id_vehiculo))
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo")).update({
        activo
    })
}

const operador_EliminarVehiculo = (id_cooperativa, id_vehiculo) => {
    const insertUbicacionVehiculo = db.ref(ruta_vehiculos(id_cooperativa, id_vehiculo))
    db.ref(ruta_vehiculos(id_cooperativa + "-id_cooperativa", id_vehiculo + "-id_vehiculo")).update({
        eliminado: true
    })
}


const selectlimitar = document.querySelector('.limitar');

const colplaca = document.querySelector('.colplaca');
const colmatricula = document.querySelector('.colmatricula');
const colestado = document.querySelector('.colestado');
const colactivo = document.querySelector('.colactivo');

selectlimitar.addEventListener('change', (event) => {
    consult['limit'] = event.target.value;
    obtenerVehiculos();

});

colplaca.addEventListener('input', (event) => {
    consult['columna'] = 'v.placa';
    consult['nombre'] = event.srcElement.value;
    obtenerVehiculos();
});
colmatricula.addEventListener('input', (event) => {
    consult['columna'] = 'v.matricula';
    consult['nombre'] = event.srcElement.value;
    obtenerVehiculos();
});

colestado.addEventListener('input', (event) => {
    consult['columna'] = 'ev.descripcion';
    consult['nombre'] = event.srcElement.value;
    obtenerVehiculos();
});
colactivo.addEventListener('change', (event) => {
    consult['columna'] = 'v.activo';
    consult['nombre'] = event.target.value;
    obtenerVehiculos();

});