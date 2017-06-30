using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooAzureApp.Controllers
{
    public class TipoAnimalController : ApiController
    {
        // GET: api/TipoAnimal
        public RespuestaAPI Get()
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            List<TipoAnimal> dataTipoAnimal = new List<TipoAnimal>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataTipoAnimal = Db.GetTablaTiposAnimal();
                }
                respuestaAPI.error = "";
                Db.Desconectar();
            }
            catch
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Se produjo un error";
            }

            respuestaAPI.totalData = dataTipoAnimal.Count;
            respuestaAPI.dataTipoAnimal = dataTipoAnimal;
            return respuestaAPI;
        }
//-----------------------------------------------------------------------------------------------
        // GET: api/TipoAnimal/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            List<TipoAnimal> dataTipoAnimal = new List<TipoAnimal>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    dataTipoAnimal = Db.GetTipoAnimalPorId(id);
                }
                respuestaAPI.error = "";
                Db.Desconectar();
            }
            catch
            {
                respuestaAPI.error = "Se produjo un error";
            }

            respuestaAPI.totalData = dataTipoAnimal.Count;
            respuestaAPI.dataTipoAnimal = dataTipoAnimal;
            return respuestaAPI;
        }
        //---------------------------------------------------------------------------------------------------------

        // POST: api/TipoAnimal
        [HttpPost]
        public IHttpActionResult Post([FromBody] TipoAnimal dataTipoAnimal)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarTipoAnimal(dataTipoAnimal);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al agregar el tipo de animal";
            }

            return Ok(respuestaAPI);
        }

        //--------------------------------------------------------------------------------------------------------------
        // PUT: api/TipoAnimal/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]TipoAnimal tipoAnimal)
        {
            RespuestaAPI respuestaAPI = new RespuestaAPI();
            respuestaAPI.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarTablaTiposAnimal(id, tipoAnimal);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al actualizar el tipo de animal";
            }
            return Ok(respuestaAPI);
        }


        //------------------------------------------------------------------------------------------------------------------
        // DELETE: api/TipoAnimal/5
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
                    filasAfectadas = Db.EliminarTipoAnimal(id);
                }
                respuestaAPI.totalData = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuestaAPI.totalData = 0;
                respuestaAPI.error = "Error al eliminar el tipo de animal";
            }
            return Ok(respuestaAPI);
        }
    }
}
