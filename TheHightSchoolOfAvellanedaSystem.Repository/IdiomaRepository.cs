using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class IdiomaRepository : IIdiomaRepository
    {
        private string selectAll;

        public IdiomaRepository() 
        { 
        selectAll = "SP_SELECT_IDIOMAS_TODOS";
        
        }

        public int Add(Idioma entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idioma> GetAll()
        {
            try 
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listIdiomas = new List<Idioma>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listIdiomas.Add(new Idioma
                    {
                        Id = Convert.ToInt32(item[0]),
                        descripcionIdioma = item[1].ToString()
                    }); 
                }
                return listIdiomas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Idioma entity)
        {
            throw new NotImplementedException();
        }
    }
}
