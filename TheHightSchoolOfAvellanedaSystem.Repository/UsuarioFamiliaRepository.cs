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
    public class UsuarioFamiliaRepository : IUsuarioFamiliaRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public UsuarioFamiliaRepository()
        {
            selectAll = "";
            insert = "SP_USUARIOS_FAMILIA_ADD";
            update = "";
            delete = "";

        }

        public int Add(UsuarioFamilia entity)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insert;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int)).Value = entity.Id;
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.BigInt)).Value = entity.idUsuario;
                cmd.Parameters.Add(new SqlParameter("@dniUsuario", SqlDbType.BigInt)).Value = entity.dniUsuario;
                cmd.Parameters.Add(new SqlParameter("@idFamilia", SqlDbType.BigInt)).Value = entity.idFamilia;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UsuarioFamilia> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(UsuarioFamilia entity)
        {
            throw new NotImplementedException();
        }
    }
}
