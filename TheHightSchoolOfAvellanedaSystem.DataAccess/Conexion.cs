using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace TheHightSchoolOfAvellanedaSystem.DataAccess
{
    public abstract class Conexion
    {
        private readonly string connectionStringSeguridad;
        public Conexion()
        {
            connectionStringSeguridad = ConfigurationManager.ConnectionStrings["cnnSeguridad"].ToString();
        }
        
        protected SqlConnection GetConnectionSeguridad()
        {
            return new SqlConnection(connectionStringSeguridad);
        }

    }
}
