using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooAzureApp.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public RespuestaAPI Get()
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            List<Clasificacion> dataClasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataClasificacion = Db.GetTablaClasificaciones();
                }
                respuestaAPI.error = "";
                Db.Desconectar();
            }
            catch
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Se produjo un error";
            }

            respuestaAPI.totalData = dataClasificacion.Count;
            respuestaAPI.dataClasificacion = dataClasificacion;
            return respuestaAPI;
        }
        //-----------------------------------------------------------------------------------------------
        // GET: api/Clasificacion/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            List<Clasificacion> dataClasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    dataClasificacion = Db.GetClasificacionesPorId(id);
                }
                respuestaAPI.error = "";
                Db.Desconectar();
            }
            catch
            {
                respuestaAPI.error = "Se produjo un error";
            }

            respuestaAPI.totalData = dataClasificacion.Count;
            respuestaAPI.dataClasificacion = dataClasificacion;
            return respuestaAPI;
        }
        //---------------------------------------------------------------------------------------------------------

        // POST: api/Clasificacion
        [HttpPost]
        public RespuestaAPI Post([FromBody] Clasificacion denominacionClasificacion)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarClasificacion(denominacionClasificacion);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalData = filasAfectadas;
            resultado.dataClasificacion = null;
            return resultado;
        }


        //--------------------------------------------------------------------------------------------------------------
        // PUT: api/Clasificacion/5
        [HttpPut]
        public RespuestaAPI Put(int id, [FromBody] Clasificacion denominacionClasificacion)

        {

            RespuestaAPI resultado = new RespuestaAPI();
            resultado.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarTablaClasificaciones(id, denominacionClasificacion);

                }

                resultado.totalData = filasAfectadas;

                Db.Desconectar();
            }
            catch (Exception ex)
            {

                resultado.totalData = 0;
                resultado.error = "Se produjo un error";
            }

            return resultado;

        }


        //------------------------------------------------------------------------------------------------------------------
        // DELETE: api/Clasificacion/5
        [HttpDelete]
        public RespuestaAPI Delete(int id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarClasificacion(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalData = filasAfectadas;
            resultado.dataClasificacion = null;
            return resultado;
        }
    }
}