using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;

namespace viaje.express.data.DataUsuario
{
    public class Usuario_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Usuario obtener_usuario(int id)
        {
            Consulta consulta = new Consulta("[proc_obtener_usuario] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id));
            return db.EjecutarFilaUnica<Usuario>(consulta);
        }
        
    }
}
