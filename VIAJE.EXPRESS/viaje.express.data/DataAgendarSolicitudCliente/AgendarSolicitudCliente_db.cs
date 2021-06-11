using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;
using viaje.express.model.ModelAgendarSolicitudCliente;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataAgendarSolicitudCliente
{
    public class AgendarSolicitudCliente_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado cliente_insertar_agendar_solicitud_cliente_carrera_programada(InsertarAgendarSolicitudCliente_programada model)
        {
            Consulta consulta = new Consulta("[proc_cliente_insertar_agendar_solicitud_cliente_carrera_programada] @id_persona_rol, @origen_lat, @origen_lng, " +
                "@destino_lat, @destino_lng, @fecha, @hora, @distancia, @tiempo, @monto, @id_tipo_carrera, @id_tipo_solicitud, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", model.id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@origen_lat", model.origen_lat));
            consulta.AgregarParametro(db.CrearParametro("@origen_lng", model.origen_lng));
            consulta.AgregarParametro(db.CrearParametro("@destino_lat", model.destino_lat));
            consulta.AgregarParametro(db.CrearParametro("@destino_lng", model.destino_lng));
            consulta.AgregarParametro(db.CrearParametro("@fecha", model.fecha));
            consulta.AgregarParametro(db.CrearParametro("@hora", model.hora));
            consulta.AgregarParametro(db.CrearParametro("@distancia", model.distancia));
            consulta.AgregarParametro(db.CrearParametro("@tiempo", model.tiempo));
            consulta.AgregarParametro(db.CrearParametro("@monto", model.monto));
            consulta.AgregarParametro(db.CrearParametro("@id_tipo_carrera", model.id_tipo_carrera));
            consulta.AgregarParametro(db.CrearParametro("@id_tipo_solicitud", model.id_tipo_solicitud));
            consulta.AgregarParametro(db.CrearParametro("@created_by", model.created_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado cliente_insertar_agendar_solicitud_cliente_carrera_now(InsertarAgendarSolicitudCliente_now model)
        {
            Consulta consulta = new Consulta("[proc_cliente_insertar_agendar_solicitud_cliente_carrera_justo_ahora] @id_persona_rol, @origen_lat, "+
                "@origen_lng, @destino_lat, @destino_lng, @distancia, @tiempo, @monto, @id_tipo_solicitud, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", model.id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@origen_lat", model.origen_lat));
            consulta.AgregarParametro(db.CrearParametro("@origen_lng", model.origen_lng));
            consulta.AgregarParametro(db.CrearParametro("@destino_lat", model.destino_lat));
            consulta.AgregarParametro(db.CrearParametro("@destino_lng", model.destino_lng));
            consulta.AgregarParametro(db.CrearParametro("@distancia", model.distancia));
            consulta.AgregarParametro(db.CrearParametro("@tiempo", model.tiempo));
            consulta.AgregarParametro(db.CrearParametro("@monto", model.monto));
            consulta.AgregarParametro(db.CrearParametro("@id_tipo_solicitud", model.id_tipo_solicitud));
            consulta.AgregarParametro(db.CrearParametro("@created_by", model.created_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado cliente_cancelar_carrera(int id_persona_rol, CambiosDeEstado model)
        {
            Consulta consulta = new Consulta("[proc_cliente_calcelar_agendar_solicitud_cliente] @id_persona_rol, @id_agendar_solicitud_cliente");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", model.id_agendar_solicitud_cliente));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado chofer_cancelar_carrera_cliente(int id_persona_rol, CambiosDeEstado model)
        {
            Consulta consulta = new Consulta("[proc_chofer_calcelar_carrera] @id_persona_rol, @id_agendar_solicitud_cliente");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", model.id_agendar_solicitud_cliente));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado chofer_ejecutar_carrera(int id_persona_rol, CambiosDeEstado model)
        {
            Consulta consulta = new Consulta("[proc_chofer_ejecutar_carrera_cliente] @id_persona_rol, @id_agendar_solicitud_cliente");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", model.id_agendar_solicitud_cliente));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado chofer_finalizar_carrera_cliente(int id_persona_rol, CambiosDeEstado model)
        {
            Consulta consulta = new Consulta("[proc_chofer_finalizar_carrera_cliente] @id_persona_rol, @id_agendar_solicitud_cliente");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", model.id_agendar_solicitud_cliente));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado chofer_aceptar_solicitud_cliente(int id_persona_rol, CambiosDeEstado model)
        {
            Consulta consulta = new Consulta("[proc_chofer_aceptar_solicitud_cliente_carrera_chofer] @id_persona_rol, @id_agendar_solicitud_cliente, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", model.id_agendar_solicitud_cliente));
            consulta.AgregarParametro(db.CrearParametro("@created_by", id_persona_rol));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado cliente_unirse_carrera_compartida(int id_persona_rol, CambiosDeEstado model)
        {
            Consulta consulta = new Consulta("[proc_cliente_incluir_carrera_compartida] @id_persona_rol, @id_agendar_solicitud_cliente, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", model.id_agendar_solicitud_cliente));
            consulta.AgregarParametro(db.CrearParametro("@created_by", id_persona_rol));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public List<Operador_ObtenerAgendarSolicitudCliente> operador_listar_agenda_solicitud_cliente(int id_cooperativa, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_operador_listar_agendar_solicitud_cliente] @id_cooperativa, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Operador_ObtenerAgendarSolicitudCliente>(consulta);
        }

        public List<Cliente_ObtenerCarreraProgramadaCompartida> cliente_listar_carreras_programadas_compartidas(int id_persona_rol, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_cliente_listar_carreras_programadas_compartidas] @id_persona_rol, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Cliente_ObtenerCarreraProgramadaCompartida>(consulta);
        }

        public List<Chofer_ObtenerCarreraProgramada> chofer_listar_carreras_programadas(string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_chofer_listar_carreras_programadas] @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Chofer_ObtenerCarreraProgramada>(consulta);
        }

        public List<ObtenerPersonaCarreraCompartida> operador_listar_personas_carrera_compartida(int id_agendar_solicitud_cliente)
        {
            Consulta consulta = new Consulta("[proc_operador_listar_agendar_cliente] @id_agendar_solicitud_cliente");
            consulta.AgregarParametro(db.CrearParametro("@id_agendar_solicitud_cliente", id_agendar_solicitud_cliente));

            return db.EjecutarConsulta<ObtenerPersonaCarreraCompartida>(consulta);
        }

        public List<Cliente_Historial_AgendarSolicitudCliente_programada> cliente_historial_carreras_programadas(int id_persona_rol, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new 
                Consulta("[proc_cliente_listar_historial_agendar_solicitud_cliente_carrera_programada] @id_persona_rol, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Cliente_Historial_AgendarSolicitudCliente_programada>(consulta);
        }

        public List<Cliente_Historial_AgendarSolicitudCliente_now> cliente_historial_carreras_now(int id_persona_rol, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new
                Consulta("[proc_cliente_listar_historial_agendar_solicitud_cliente_carrera_justo_ahora] @id_persona_rol, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Cliente_Historial_AgendarSolicitudCliente_now>(consulta);
        }

        public List<Chofer_Historial_AgendarSolicitudCliente_programada> chofer_historial_carreras_programadas(int id_persona_rol, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new
                Consulta("[proc_chofer_listar_historial_agendar_solicitud_cliente_carrera_programada] @id_persona_rol, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Chofer_Historial_AgendarSolicitudCliente_programada>(consulta);
        }

        public List<Chofer_Historial_AgendarSolicitudCliente_now> chofer_historial_carreras_now(int id_persona_rol, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new
                Consulta("[proc_chofer_listar_historial_agendar_solicitud_cliente_carrera_justo_ahora] @id_persona_rol, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Chofer_Historial_AgendarSolicitudCliente_now>(consulta);
        }
    }
}
