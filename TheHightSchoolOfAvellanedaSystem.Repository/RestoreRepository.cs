using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class RestoreRepository
    {
        public int RealizarRestore(string Base, string Destino)
        {
            {
                try
                {
                    MasterConexion master = new MasterConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "ALTER DATABASE [" + Base + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE"; 
                    var tableResult = master.ExecuteNonQuery(cmd);

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "USE MASTER RESTORE DATABASE [" + Base + "] FROM DISK = '" + Destino + "' WITH REPLACE";
                    var tableResult2 = master.ExecuteNonQuery(cmd2);

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "ALTER DATABASE [" + Base + "] SET MULTI_USER";
                    var tableResult3 = master.ExecuteNonQuery(cmd3);

                    return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //VER QUE LE PONGO ACÁ - CONSULTAR DAVID
                }
            }
        }
    }
}
