using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooAzureApp.Controllers
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
            }
            respuestaAPI.error = "";
            Db.Desconectar();
        }
        catch
        {
            respuestaAPI.totalData = 0;
            respuestaAPI.error = "Se produjo un error";
        }

        respuestaAPI.totalData = dataEspecie.Count;
        respuestaAPI.dataEspecie = dataEspecie;
        return respuestaAPI;
    }
    //-----------------------------------------------------------------------------------------------
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
    //---------------------------------------------------------------------------------------------------------

    // POST: api/Especie
    [HttpPost]
    public RespuestaAPI Post([FromBody] Especie especie)
    {
        RespuestaAPI resultado = new RespuestaAPI();
        int filasAfectadas = 0;
        try
        {
            Db.Conectar();

            if (Db.EstaLaConexionAbierta())
            {
                filasAfectadas = Db.AgregarEspecies(especie);
            }
            resultado.error = "";
            Db.Desconectar();
        }
        catch (Exception ex)
        {
            resultado.error = "Se produjo un error";
        }

        resultado.totalData = filasAfectadas;
        resultado.dataEspecie = null;
        return resultado;
    }


    //--------------------------------------------------------------------------------------------------------------
    // PUT: api/Especie/5
    [HttpPut]
    public RespuestaAPI Put(int id, [FromBody] Especie especie)

    {

        RespuestaAPI resultado = new RespuestaAPI();
        resultado.error = "";
        int filasAfectadas = 0;
        try
        {
            Db.Conectar();

            if (Db.EstaLaConexionAbierta())
            {
                filasAfectadas = Db.ActualizarTablaEspecies(id, especie);

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
    // DELETE: api/Especie/5
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
                filasAfectadas = Db.EliminarEspecie(id);
            }
            resultado.error = "";
            Db.Desconectar();
        }
        catch (Exception ex)
        {
            resultado.error = "Se produjo un error";
        }

        resultado.totalData = filasAfectadas;
        resultado.dataEspecie = null;
        return resultado;
    }
}
}