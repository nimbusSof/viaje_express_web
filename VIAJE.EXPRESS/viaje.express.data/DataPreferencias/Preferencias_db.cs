using System;
using System.Collections.Generic;
using System.Text;

using viaje.express.model.ModelCuentas;
using viaje.express.model;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.PreferenciasUsuario;

namespace viaje.express.data.DataPreferencias
{
    public class PreferenciasUsuario_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado insertar_preferencia(int id_persona_rol, String idioma)
        {
            Consulta consulta = new Consulta("[proc_insertar_preferencia_usuario] @i_operacion, @i_id_persona_rol, @i_idioma");
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", "I"));
            consulta.AgregarParametro(db.CrearParametro("@i_id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@i_idioma", idioma));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }


        public Resultado actualizar_preferencia(int id_persona_rol, String idioma)
        {
            Consulta consulta = new Consulta("[proc_insertar_preferencia_usuario] @i_operacion, @i_id_persona_rol, @i_idioma");
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'U'));
            consulta.AgregarParametro(db.CrearParametro("@i_id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@i_idioma", idioma));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }


        public PreferenciasUsuario obtener_preferencia(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_insertar_preferencia_usuario] @i_operacion, @i_id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'C'));
            consulta.AgregarParametro(db.CrearParametro("@i_id_persona_rol", id_persona_rol));
            return db.EjecutarFilaUnica<PreferenciasUsuario>(consulta);
        }

    }
}