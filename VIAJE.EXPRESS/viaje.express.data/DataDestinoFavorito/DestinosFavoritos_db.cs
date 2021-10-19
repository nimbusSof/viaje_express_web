using System;
using System.Collections.Generic;
using System.Text;

using viaje.express.model;
using viaje.express.model.ModelDestinoFavorito;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataDestinoFavorito
{
    public class DestinosFavoritos_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado insertar_destinoFavorito(int id_persona_rol, String destino_lat,
            String destino_lon, String nombre_destino, String nombre_personalizado)
        {
            Consulta consulta = new Consulta("[proc_insertar_destino_favorito] " +
                "@i_operacion, @id_persona_rol, @destino_lat, @destino_lon, " +
                "@nombre_destino, @nombre_personalizado, @created_by");
             
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'I'));
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@destino_lat", destino_lat));
            consulta.AgregarParametro(db.CrearParametro("@destino_lon", destino_lon));
            consulta.AgregarParametro(db.CrearParametro("@nombre_destino", nombre_destino));
            consulta.AgregarParametro(db.CrearParametro("@nombre_personalizado", nombre_personalizado));
            consulta.AgregarParametro(db.CrearParametro("@created_by", id_persona_rol));
            //consulta.AgregarParametro(db.CrearParametro("@created_at", DateTime.Now.ToString()));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado actualizar_destinoFavorito(int id_destino, String destino_lat,
            String destino_lon, String nombre_destino, String nombre_personalizado, int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_insertar_destino_favorito] " +
                "@i_operacion, @destino_lat, @destino_lon, " +
                "@nombre_destino, @nombre_personalizado, @id_destino, @modified_by");

            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'U'));
            consulta.AgregarParametro(db.CrearParametro("@id_destino", id_destino));
            consulta.AgregarParametro(db.CrearParametro("@destino_lat", destino_lat));
            consulta.AgregarParametro(db.CrearParametro("@destino_lon", destino_lon));
            consulta.AgregarParametro(db.CrearParametro("@nombre_destino", nombre_destino));
            consulta.AgregarParametro(db.CrearParametro("@nombre_personalizado", nombre_personalizado));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", id_persona_rol));
            //consulta.AgregarParametro(db.CrearParametro("@modified_at", DateTime.Now.ToString()));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }



        public List<ModelDestinoFavoritoObtener> obtener_destinosFavoritos(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_insertar_destino_favorito] @i_operacion, @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'C'));
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", Int32.Parse(""+id_persona_rol)));
            return db.EjecutarConsulta<ModelDestinoFavoritoObtener>(consulta);
        }


        public Resultado eliminar_destino_favorito(int id_destino)
        {
            Consulta consulta = new Consulta("[proc_insertar_destino_favorito] @id_destino, @i_operacion");
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'D'));
            consulta.AgregarParametro(db.CrearParametro("@id_destino", id_destino));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }


        public List<Probando> obtener_probando(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_probando] @i_operacion, @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@i_operacion", 'C'));
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            return db.EjecutarConsulta<Probando>(consulta);
        }

    }
}
