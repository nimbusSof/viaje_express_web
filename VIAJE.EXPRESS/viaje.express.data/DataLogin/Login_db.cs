using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelLogin;

namespace viaje.express.data.DataLogin
{
    public class Login_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();


        public ResultadoLogin login(string correo, string clave)
        {
            Consulta consulta = new Consulta("[proc_login] @correo, @clave");
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@clave", clave));

            return db.EjecutarFilaUnica<ResultadoLogin>(consulta);
        }
    }
}
