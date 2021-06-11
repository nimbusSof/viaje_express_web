using System;
using System.Collections.Generic;
using System.Text;

using viaje.express.model;
using viaje.express.model.ModelCuentas;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataCuentas
{
    public class CuentaUsuarioChofer_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();
        private CuentaUsuario_db cuenta_usuario_db = new CuentaUsuario_db();

        public Resultado actualizar_estado_vehiculo(int id_persona_rol, int id_estado_vehiculo)
        {
            Consulta consulta = new Consulta("[proc_actualizar_estado_vehiculo_por_chofer] @id_persona_rol, @id_estado_vehiculo");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_estado_vehiculo", id_estado_vehiculo));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }
}
