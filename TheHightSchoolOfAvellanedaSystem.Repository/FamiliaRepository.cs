using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private string selectAll;

        public FamiliaRepository()
        {
            selectAll = "SP_SELECT_FAMILIAS_TODAS";

        }

        public int Add(Familia entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Familia> GetAll()
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listFamilias = new List<Familia>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listFamilias.Add(new Familia
                    {
                        Id = Convert.ToInt32(item[0]),
                        nombre = item[1].ToString()
                    });
                }
                return listFamilias;
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

        public int Update(Familia entity)
        {
            throw new NotImplementedException();
        }
    }

}

