using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class ClasificacionController : ApiController
    {
       
        // GET: api/Clasificacion
        public RespuestaAPI Get()
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            List<Clasificacion> dataClasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataClasificacion = Db.GetTablaClasificaciones();
                }
                respuesta.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalData = 0;
                respuesta.error = "Se produjo un error";
            }

            respuesta.totalData = dataClasificacion.Count;
            respuesta.dataClasificacion = dataClasificacion;
            return respuesta;
        }
//-------------------------------------------------------------------------------------------------------------------

        // GET: api/Clasificacion/5
        public RespuestaAPI Get(long id)
        {

            RespuestaAPI respuesta = new RespuestaAPI();
            List<Clasificacion> dataClasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataClasificacion = Db.GetClasificacionesPorId(id);
                    respuesta.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.error = "Error";
            }
            respuesta.totalData = dataClasificacion.Count;
            respuesta.dataClasificacion = dataClasificacion;
            return respuesta;

        }
        //-------------------------------------------------------------------------------------------------------------------------------

        // POST: api/Clasificacion
        [HttpPost]
        public IHttpActionResult Post([FromBody] Clasificacion clasificacion)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarClasificacion(clasificacion);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al agregar la clasificacion";
            }

            return Ok(respuestaAPI);
        }


        //---------------------------------------------------------------------------------------------------------------------------------
        // PUT: api/Clasificacion/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Clasificacion clasificacion)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarTablaClasificaciones(id, clasificacion);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al actualizar la clasificacion";
            }
            return Ok(respuestaAPI);
        }

        //--------------------------------------------------------------------------------------------------------------------------

        // DELETE: api/Clasificacion/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarClasificacion(id);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al eliminar la clasificacion";
            }
            return Ok(respuestaAPI);
        }
    }
}
