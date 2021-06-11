using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelModulos;

using viaje.express.model;


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

        public Resultado insertar_usuario_rol_modulo(int id_persona_rol_ejecucion, int id_persona_rol, int id_modulo)
        {
            Consulta consulta = new Consulta("[proc_persona_rol_modulo] @id_persona_rol_ejecucion, @id_persona_rol, @id_modulo");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol_ejecucion", id_persona_rol_ejecucion));
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_modulo", id_modulo));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public List<AsignarModulo> listar_modulo_rol(int id_rol_admin_coop)
        {
            Consulta consulta = new Consulta("[proc_listar_modulo_rol] @id_rol_admin_coop");
            consulta.AgregarParametro(db.CrearParametro("@id_rol_admin_coop", id_rol_admin_coop));
            return db.EjecutarConsulta<AsignarModulo>(consulta);
        }

        public Resultado eliminar_modulo_persona_rol(int id_persona_rol)
        {   
            Consulta consulta = new Consulta("[proc_eliminar_modulo_persona_rol] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }
}
