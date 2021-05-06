using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
    public class Entities_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public SecurityViewModel getToken(string token)
        {
            Consulta consulta = new Consulta("[proc_obtener_token] @token");
            consulta.AgregarParametro(db.CrearParametro("@token", token));

            return db.EjecutarFilaUnica<SecurityViewModel>(consulta);
        }
    }
}
