using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelModulos;

namespace viaje.express.data.DataModulo
{
    public class Modulo_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<ModuloRol> getRutasRol(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_rutas_usuario] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));

            return db.EjecutarConsulta<ModuloRol>(consulta);
        }
    }
}
