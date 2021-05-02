using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
     public class VehiculoBd
    {




        internal BaseDeDatos db = BaseDeDatos.GetConection();


        public List<Vehiculo> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Vehiculo] ");

            return db.EjecutarConsulta<Vehiculo>(consulta);
        }

        public Vehiculo Insertar(int cooperativaId, string vehiculoPlaca, string vehiculoColor, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Vehiculo] @cooperativa_id, @vehiculo_placa, @vehiculo_color, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@vehiculo_placa", vehiculoPlaca));
            consulta.AgregarParametro(db.CrearParametro("@vehiculo_color", vehiculoColor));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<Vehiculo>(consulta);



        }

        public Resultado Modificar(int id ,int cooperativaId, string vehiculoPlaca, string vehiculoColor, int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Vehiculo] @id,@cooperativa_id, @vehiculo_placa, @vehiculo_color, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id",id));

            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@vehiculo_placa", vehiculoPlaca));
            consulta.AgregarParametro(db.CrearParametro("@vehiculo_color", vehiculoColor));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);



        }


        public Vehiculo Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Vehiculo] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<Vehiculo>(consulta);
        }
        public List<Vehiculo> Obtener_Vehiculo_Cooperativa(int id, string aux)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Vehiculo_Cooperativa] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarConsulta<Vehiculo>(consulta);
        }
        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Vehiculo] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }

}