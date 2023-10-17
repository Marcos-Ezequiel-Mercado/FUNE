using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class BackupRepository
    {
        public int RealizarBU(string BaseSeguridad, string Destino)
        {
            {
                try
                {
                    MasterConexion master = new MasterConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "BACKUP DATABASE " + BaseSeguridad + 
                                      " TO DISK = N'" + Destino + 
                                      "' WITH NOFORMAT, NOINIT, NAME = N'" + BaseSeguridad + 
                                      "',SKIP, STATS = 10";
                    var tableResult = master.ExecuteReader(cmd);
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
