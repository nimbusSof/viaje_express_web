
var firebaseConfig = {
    apiKey: "AIzaSyD6c9oUsV7CChy_8JrIKj9L9JrAhPXecp4",
    authDomain: "vehiculos-c50c3.firebaseapp.com",
    databaseURL: "https://vehiculos-c50c3-default-rtdb.firebaseio.com",
    projectId: "vehiculos-c50c3",
    storageBucket: "vehiculos-c50c3.appspot.com",
    messagingSenderId: "628365823815",
    appId: "1:628365823815:web:d3bdd672d19621bb34c662"
};

// Initialize Firebase
 firebase.initializeApp(firebaseConfig)
//firebase.analytics();
const end_point_solicitud = 'agenda_solicitud_cliente_real_time';
const end_point_vehiculo = 'registro_cooperativa_ubicacion_vehiculo';
const db = firebase.database();

 const ruta_vehiculos = (...args) => {
     let dir = `${end_point_vehiculo}`;
    for (let i = 0; i < args.length; i++) {
        dir += `/${args[i]}`;
    }
    return dir;
}
const ruta_solicitud = (...args) => {
    let dir2 = `${end_point_solicitud}`;
    for (let i = 0; i < args.length; i++) {
        dir2+= `/${args[i]}`;
    }
    return dir2;
}
export { ruta_vehiculos, ruta_solicitud, end_point_solicitud, end_point_vehiculo, db };