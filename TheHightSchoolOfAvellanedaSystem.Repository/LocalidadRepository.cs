using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class LocalidadRepository : ILocalidadRepository
    {
        private string selectAll;

        public LocalidadRepository()
        {
            selectAll = "SP_SELECT_LOCALIDADES_TODAS";

        }


        public int Add(Localidad entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Localidad> GetAll()
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listLocalidades = new List<Localidad>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listLocalidades.Add(new Localidad
                    {
                        Id = Convert.ToInt32(item[0]),
                        descripcion = item[1].ToString()
                    });
                }
                return listLocalidades;
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

        public int Update(Localidad entity)
        {
            throw new NotImplementedException();
        }
    }
}
