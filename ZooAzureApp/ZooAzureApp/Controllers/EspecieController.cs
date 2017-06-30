using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class EspecieController : ApiController
    {
        // GET: api/Especie
        public RespuestaAPI Get()
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            List<Especie> dataEspecie = new List<Especie>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataEspecie = Db.GetTablaEspecies();
                    respuestaAPI.error = "";
                }
               
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                //respuestaAPI.totalData = 0;
                respuestaAPI.error = "Se produjo un error";
            }

            respuestaAPI.totalData = dataEspecie.Count;
            respuestaAPI.dataEspecie = dataEspecie;
            return respuestaAPI;
        }
        //-------------------------------------------------------------------------------
        // GET: api/Especie/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            List<Especie> dataEspecie = new List<Especie>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    dataEspecie = Db.GetEspeciesPorId(id);
                }
                respuestaAPI.error = "";
                Db.Desconectar();
            }
            catch
            {
                respuestaAPI.error = "Se produjo un error";
            }

            respuestaAPI.totalData = dataEspecie.Count;
            respuestaAPI.dataEspecie = dataEspecie;
            return respuestaAPI;
        }
        //---------------------------------------------------------------------------
        // POST: api/Especie
        [HttpPost]
        public IHttpActionResult Post([FromBody] Especie especie)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarEspecies(especie);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al agregar la especie";
            }

            return Ok(respuestaAPI);
        }

        //------------------------------------------------------------------------

        // PUT: api/Especie/5
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]Especie especie)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarTablaEspecies(id, especie);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al actualizar la especie";
            }
            return Ok(respuestaAPI);
        }

        //-------------------------------------------------------------------------------

        // DELETE: api/Especie/5
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarEspecie(id);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al eliminar la especie";
            }
            return Ok(respuestaAPI);
        }
    }
}
