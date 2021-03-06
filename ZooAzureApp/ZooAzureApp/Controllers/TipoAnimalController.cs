﻿using System;
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
        public RespuestaAPI Post([FromBody] TipoAnimal denominacionTipoAnimal)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarTipoAnimal(denominacionTipoAnimal);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalData = filasAfectadas;
            resultado.dataTipoAnimal = null;
            return resultado;
        }


        //--------------------------------------------------------------------------------------------------------------
        // PUT: api/TipoAnimal/5
        [HttpPut]
        public RespuestaAPI Put(int id, [FromBody] TipoAnimal denominacionTipoAnimal)

        {
           
            RespuestaAPI resultado = new RespuestaAPI();
            resultado.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarTablaTiposAnimal(id, denominacionTipoAnimal);

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
        // DELETE: api/TipoAnimal/5
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
                    filasAfectadas = Db.EliminarTipoAnimal(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalData = filasAfectadas;
            resultado.dataTipoAnimal = null;
            return resultado;
        }
    }
}
