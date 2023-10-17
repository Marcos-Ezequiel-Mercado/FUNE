using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class MovimientosRepository : IGenericRepository<Domain.Movimientos>, IMovimientosReposotory
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        private string updateDVH;
        
        public MovimientosRepository()
        {
            selectAll = "SP_MOVIMIENTOS_SELECT_ALL";
            insert = "SP_MOVIMIENTOS_ADD";
            update = "";
            delete = "";
            updateDVH = "SP_MOVIMIENTO_UPDATE_DVH";
        }
        public int Add(Domain.Movimientos entity)
        {
            MasterConexion master = new MasterConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = insert;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@Mov_Desc", SqlDbType.VarChar)).Value = entity.Movimiento;
            //cmd.Parameters.Add(new SqlParameter("@Bit_Id_Mov", SqlDbType.Int)).Value = entity.Bit_Id_Mov;
            //cmd.Parameters.Add(new SqlParameter("@Usu_Id", SqlDbType.Int)).Value = entity.Usu_Id;
            //cmd.Parameters.Add(new SqlParameter("@Mov_DVH", SqlDbType.Int)).Value = entity.Mov_DVH;
            int Result = master.ExecuteNonQuery(cmd);
            return Result;
        }

        public IEnumerable<Domain.Bitacora> GetAll()
        {
            throw new NotImplementedException();
        }


        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Domain.Movimientos entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateDVH(int nuevoDVH, int Id)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updateDVH;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mov_DVH", SqlDbType.Int)).Value = nuevoDVH;
                cmd.Parameters.Add(new SqlParameter("@Bit_Id_Mov", SqlDbType.Int)).Value = Id;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        IEnumerable<Domain.Movimientos> IGenericRepository<Domain.Movimientos>.GetAll()
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listMovimientos = new List<Domain.Movimientos>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listMovimientos.Add(new Domain.Movimientos
                    {
                        //Movimiento = item[0].ToString().Trim(),
                        //Bit_Id_Mov = Convert.ToInt16(item[1].ToString().Trim()),
                        //Usu_Id = Convert.ToInt16(item[2].ToString().Trim()),
                        //Mov_DVH = Convert.ToInt16(item[3].ToString().Trim())
                    });
                }
                return listMovimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

