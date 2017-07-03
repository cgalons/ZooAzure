using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ZooAzureApp
{
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {

                //string cadenaConexion = @"Server=.\sqlexpress;
                //                          Database=zooDB;
                //                          User Id=testuser;
                //                          Password=!Curso@2017;";

                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {
                
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }

        public static List<TipoAnimal> GetTablaTiposAnimal()
        {
            List<TipoAnimal> listaTipoAnimal = new List<TipoAnimal>();

            string procedimiento = "dbo.GetTablaTiposAnimal";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TipoAnimal modelTipoAnimal = new TipoAnimal();
                modelTipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                modelTipoAnimal.denominacionTipoAnimal = reader["denominacionTipoAnimal"].ToString();
                listaTipoAnimal.Add(modelTipoAnimal);
            }

            return listaTipoAnimal;
        }

        public static List<TipoAnimal> GetTipoAnimalPorId(long idTipoAnimal)
        {
            List<TipoAnimal> listaTipoAnimal = new List<TipoAnimal>();

            string procedimiento = "dbo.GetTipoAnimalPorId";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idTipoAnimal;
            comando.Parameters.Add(parametroId);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                TipoAnimal modelTipoAnimal = new TipoAnimal();
                modelTipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                modelTipoAnimal.denominacionTipoAnimal= reader["denominacionTipoAnimal"].ToString();
                listaTipoAnimal.Add(modelTipoAnimal);
            }

            return listaTipoAnimal;
        }

        public static int AgregarTipoAnimal(TipoAnimal modelTipoAnimal)
        {
            string procedimiento = "dbo.AgregarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacionTipoAnimal";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = modelTipoAnimal.denominacionTipoAnimal;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int ActualizarTablaTiposAnimal(long idTipoAnimal, TipoAnimal modelTipoAnimal)
        {
            string procedimiento = "dbo.ActualizarTablaTiposAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idTipoAnimal;
            comando.Parameters.Add(parametro);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacionTipoAnimal";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = modelTipoAnimal.denominacionTipoAnimal;
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarTipoAnimal(long idTipoAnimal)
        {
            string procedimiento = "dbo.EliminarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idTipoAnimal;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }


        //----------------------------------------------------------------------------------------------------------------------------


        public static List<Clasificacion> GetTablaClasificaciones()
        {
            List<Clasificacion> listaClasificacion = new List<Clasificacion>();

            string procedimiento = "dbo.GetTablaClasificaciones";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Clasificacion modelClasificacion = new Clasificacion();
                modelClasificacion.idClasificacion = (long)reader["idClasificacion"];
                modelClasificacion.denominacionClasificacion = reader["denominacionClasificacion"].ToString();
                listaClasificacion.Add(modelClasificacion);
            }

            return listaClasificacion;
        }

        public static List<Clasificacion> GetClasificacionesPorId(long id)
        {
            List<Clasificacion> listaClasificacion = new List<Clasificacion>();

            string procedimiento = "dbo.GetClasificacionesPorId";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";//Nombre parametro PA, no de la tabla ni parámetro función
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Clasificacion modelClasificacion = new Clasificacion();
                modelClasificacion.idClasificacion = (long)reader["idClasificacion"];
                modelClasificacion.denominacionClasificacion = reader["denominacionClasificacion"].ToString();
                listaClasificacion.Add(modelClasificacion);

            }

            return listaClasificacion;
        }

        public static int AgregarClasificacion(Clasificacion modelClasificacion)
        {
            string procedimiento = "dbo.AgregarClasificacion";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacionClasificacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = modelClasificacion.denominacionClasificacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int ActualizarTablaClasificaciones(long idClasificacion, Clasificacion modelClasificacion)
        {
            string procedimiento = "dbo.ActualizarTablaClasificaciones";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idClasificacion;
            comando.Parameters.Add(parametro);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacionClasificacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = modelClasificacion.denominacionClasificacion;
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarClasificacion(long idClasificacion)
        {
            string procedimiento = "dbo.EliminarClasificacion";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idClasificacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }


        //-----------------------------------------------------------------------------------------------------------------------------

        public static List<Especie> GetTablaEspecies()
        {
            List<Especie> listaEspecie = new List<Especie>();

            string procedimiento = "dbo.GetTablaEspecies";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Especie modelEspecie = new Especie();
                modelEspecie.idEspecie = (long)reader["idEspecie"];
                modelEspecie.clasificacion = new Clasificacion();
                modelEspecie.clasificacion.idClasificacion = (long)reader["idClasificacionTE"];
                modelEspecie.tipoAnimal = new TipoAnimal();
                modelEspecie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimalTE"];
                modelEspecie.nombre = reader["nombre"].ToString();
                modelEspecie.nPatas = (int)reader["nPatas"];
                modelEspecie.esMascota = (bool)reader["esMascota"];
                listaEspecie.Add(modelEspecie);
            }

            return listaEspecie;
        }

        public static List<Especie> GetEspeciesPorId(long idEspecie)
        {
            List<Especie> listaEspecie = new List<Especie>();

            string procedimiento = "dbo.GetEspeciesPorId";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idEspecie;
            comando.Parameters.Add(parametroId);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Especie modelEspecie = new Especie();
                modelEspecie.idEspecie = (long)reader["idEspecie"];
                modelEspecie.clasificacion = new Clasificacion();
                modelEspecie.clasificacion.idClasificacion = (long)reader["idClasificacionTE"];
                modelEspecie.tipoAnimal = new TipoAnimal();
                modelEspecie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimalTE"];
                modelEspecie.nombre = reader["nombre"].ToString();
                modelEspecie.nPatas = (int)reader["nPatas"];
                modelEspecie.esMascota = (bool)reader["esMascota"];
                listaEspecie.Add(modelEspecie);
            }

            return listaEspecie;
        }

        public static int AgregarEspecies(Especie modelEspecie)
        {
            string procedimiento = "dbo.AgregarEspecies";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacionTE";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = modelEspecie.clasificacion.idClasificacion;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimalTE";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = modelEspecie.tipoAnimal.idTipoAnimal;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "nombre";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = modelEspecie.nombre;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "nPatas";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.SqlValue = modelEspecie.nPatas;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "esMascota";
            parametro.SqlDbType = SqlDbType.Bit;
            parametro.SqlValue = modelEspecie.esMascota;
            comando.Parameters.Add(parametro);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int ActualizarTablaEspecies(long idEspecie, Especie modelEspecie)
        {
            string procedimiento = "dbo.ActualizarTablaEspecies";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idEspecie";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idEspecie;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacionTE";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = modelEspecie.clasificacion.idClasificacion;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimalTE";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = modelEspecie.tipoAnimal.idTipoAnimal;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "nombre";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = modelEspecie.nombre;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "nPatas";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.SqlValue = modelEspecie.nPatas;
            comando.Parameters.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "esMascota";
            parametro.SqlDbType = SqlDbType.Bit;
            parametro.SqlValue = modelEspecie.esMascota;
            comando.Parameters.Add(parametro);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarEspecie(long idEspecie)
        {
            string procedimiento = "dbo.EliminarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idEspecie";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idEspecie;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }
    }
}