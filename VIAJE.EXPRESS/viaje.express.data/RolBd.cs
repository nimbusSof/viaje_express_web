using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{

    public class RolBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Rol Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Rol] @rol_id");
            consulta.AgregarParametro(db.CrearParametro("@rol_id", id));
            return db.EjecutarFilaUnica<Rol>(consulta);
        }

    }
}
