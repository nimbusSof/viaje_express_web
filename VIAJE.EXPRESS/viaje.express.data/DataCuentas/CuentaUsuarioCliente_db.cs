using System;
using System.Collections.Generic;
using System.Text;

using viaje.express.model;
using viaje.express.model.ModelCuentas;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataCuentas
{
    public class CuentaUsuarioCliente_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado registro_cliente(string cedula, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono, string correo, string clave, string path_foto)
        {
            int id_rol_cliente = 5; // id_rol Cliente
            int created_by = 0;
            Consulta consulta = new Consulta("[proc_insertar_usuario] @cedula, @nombre, @apellido, @fecha_nacimiento, @genero, "
                + "@telefono, @correo, @clave, @path_foto, @id_rol, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cedula", cedula));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@apellido", apellido));
            consulta.AgregarParametro(db.CrearParametro("@fecha_nacimiento", fecha_nacimiento));
            consulta.AgregarParametro(db.CrearParametro("@genero", genero));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@clave", clave));
            consulta.AgregarParametro(db.CrearParametro("@path_foto", path_foto));
            consulta.AgregarParametro(db.CrearParametro("@id_rol", id_rol_cliente));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado obtener_usuario_por_cedula(string cedula)
        {
            Consulta consulta = new Consulta("[proc_obtener_usuario_por_cedula] @cedula");
            consulta.AgregarParametro(db.CrearParametro("@cedula", cedula));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado insertar_usuario_rol_para_cliente(int id_persona)
        {
            Consulta consulta = new Consulta("[proc_insertar_persona_rol_cliente] @id_persona");
            consulta.AgregarParametro(db.CrearParametro("@id_persona", id_persona));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

    }
}
