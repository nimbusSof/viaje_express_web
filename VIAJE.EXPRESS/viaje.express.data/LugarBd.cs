using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
   public class LugarBd
    {

        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Lugar Insertar(int? cooperativaId, Double lugarLatitud , Double lugarLongitud ,string lugarNombre, int createdBy)
        {
            Consulta consulta = new Consulta(
                "[dbo].[Insertar_Lugar] @cooperativa_id , @lugar_latitud , @lugar_longitud , @lugar_nombre, @created_by");

            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@lugar_latitud", lugarLatitud));
            consulta.AgregarParametro(db.CrearParametro("@lugar_longitud", lugarLongitud));
            consulta.AgregarParametro(db.CrearParametro("@lugar_nombre", lugarNombre));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));

            return db.EjecutarFilaUnica<Lugar>(consulta);
        }

        public Resultado Modificar(int id, int? cooperativaId, Double lugarLatitud, Double lugarLongitud, string lugarNombre, int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Lugar] @id, @cooperativa_id , @lugar_latitud , @lugar_longitud , @lugar_nombre, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@lugar_latitud", lugarLatitud));
            consulta.AgregarParametro(db.CrearParametro("@lugar_longitud", lugarLongitud));
            consulta.AgregarParametro(db.CrearParametro("@lugar_nombre", lugarNombre));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Lugar] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Lugar Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Lugar] @ruta_id");
            consulta.AgregarParametro(db.CrearParametro("@ruta_id", id));
            return db.EjecutarFilaUnica<Lugar>(consulta);
        }


        public List<Lugar> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Lugar]");


            return db.EjecutarConsulta<Lugar>(consulta);
        }
    }
}

