using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using viaje.express.model;

namespace viaje.express.data
{
    public class PersonaBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Persona Insertar(string cedulaPersona, string nombrePersona,string apellidosPersona, DateTime nacimientoPersona,string telefonoPersona,string direccionPersona, string correoPersona, string contraseniaPersona,string personaNombreUsuario, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Persona] @persona_cedula, @persona_nombre, " +
                "@persona_apellidos, @persona_nacimiento, @persona_telefono, @persona_direccion, @persona_correo," +
                " @persona_contrasenia, @persona_nombre_usuario,@created_by" );
            consulta.AgregarParametro(db.CrearParametro("@persona_cedula", cedulaPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_nombre", nombrePersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_apellidos", apellidosPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_nacimiento", nacimientoPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_telefono", telefonoPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_direccion", direccionPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_correo", correoPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_contrasenia", contraseniaPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_nombre_usuario", personaNombreUsuario));

            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));


            return db.EjecutarFilaUnica<Persona>(consulta);
        }

        public Resultado Modificar(int id,string cedulaPersona, string nombrePersona, string apellidosPersona, DateTime nacimientoPersona, string telefonoPersona, string direccionPersona, string correoPersona, string contraseniaPersona, string personaNombreUsuario, int? modifiedBy)
        {
        
            Consulta consulta = new Consulta("[dbo].[Modificar_Persona] @id, @persona_cedula," +
                " @persona_nombre, @persona_apellidos, @persona_nacimiento, @persona_telefono," +
                " @persona_direccion, @persona_correo, @persona_contrasenia, @persona_nombre_usuario, @modified_by ");
            String a = nacimientoPersona.ToShortDateString();
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@persona_cedula", cedulaPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_nombre", nombrePersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_apellidos", apellidosPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_nacimiento", a));
            consulta.AgregarParametro(db.CrearParametro("@persona_telefono", telefonoPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_direccion", direccionPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_correo", correoPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_contrasenia", contraseniaPersona));
            consulta.AgregarParametro(db.CrearParametro("@persona_nombre_usuario", personaNombreUsuario));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

    







        public Persona Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Persona] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<Persona>(consulta);
        }

        public Persona ObtenerPorLogin(string PersonaNombre, string contrasaenia)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Persona_Login] @persona_nombre,@persona_contrasenia ");
            consulta.AgregarParametro(db.CrearParametro("@persona_nombre", PersonaNombre));
            consulta.AgregarParametro(db.CrearParametro("@persona_contrasenia", contrasaenia));

            return db.EjecutarFilaUnica<Persona>(consulta);
        }



        public List<Persona> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Persona] ");

            return db.EjecutarConsulta<Persona>(consulta);
        }





        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Persona] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }











    }
}


