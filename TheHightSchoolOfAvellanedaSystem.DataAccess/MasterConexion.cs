using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheHightSchoolOfAvellanedaSystem.DataAccess
{
    public class MasterConexion : Conexion
    {
        //Matodo de ejecución de escritura en base
        public int ExecuteNonQuery(SqlCommand com)
        {
            using (var connection = GetConnectionSeguridad())
            {
                try
                {
                    connection.Open();
                    com.Connection = connection;
                    int result = com.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //Metodo de ejecución de lecturas a base 
        public DataTable ExecuteReader(SqlCommand com)
        {
            using (var connection = GetConnectionSeguridad())
            {
                try
                {
                    connection.Open();
                    com.Connection = connection;
                    SqlDataReader reader = com.ExecuteReader();

                    using (var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public IEnumerable<T> GetEntities<T>(String storedProcedure, Object parameters)
        {
            using (var connection = GetConnectionSeguridad())
            {
                try
                {
                    connection.Open();

                    // Llamamos al stored procedure usando ORM Dapper
                    var resultados = connection
                        .Query<T>(storedProcedure,parameters, commandType: CommandType.StoredProcedure)
                        .ToList();

                    return resultados;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public bool EditEntity<T>(string storedProcedure, Object parameters)
        {
            using (var connection = GetConnectionSeguridad())
            {
                try
                {
                    connection.Open();

                    // Llamamos al stored procedure usando ORM Dapper
                    int rowsAffected = connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                    // Si rowsAffected es mayor que 0, significa que se editó al menos una entidad con éxito.
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Puedes manejar la excepción aquí, por ejemplo, registrarla o relanzarla.
                    throw new Exception(ex.Message);
                }
            }
        }


    }
}
