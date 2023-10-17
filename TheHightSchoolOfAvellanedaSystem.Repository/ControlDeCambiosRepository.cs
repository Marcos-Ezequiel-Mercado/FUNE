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
    public class ControlDeCambiosRepository : IGenericRepository<Domain.Control_de_Cambios>
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public ControlDeCambiosRepository() 
        {
            selectAll = "SP_CONTROL_DE_CAMBIOS_SELECT_ALL";
            insert = "SP_CONTROL_DE_CAMBIOS_ADD";
            update = "";
            delete = "";
        }




        public int Add(Control_de_Cambios entity)
        {
            MasterConexion master = new MasterConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = insert;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@Id_Control", SqlDbType.Int)).Value = entity.Id;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int)).Value = entity.idUsuario;
            cmd.Parameters.Add(new SqlParameter("@dniUsuario", SqlDbType.Int)).Value = entity.dni;
            cmd.Parameters.Add(new SqlParameter("@idTabla", SqlDbType.Int)).Value = entity.idTabla;
            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Cambio", SqlDbType.DateTime2)).Value = entity.fechaHoraCambio;
            cmd.Parameters.Add(new SqlParameter("@state", SqlDbType.VarChar)).Value = Convert.ToString(entity.state);
            cmd.Parameters.Add(new SqlParameter("@propiedad", SqlDbType.VarChar)).Value = entity.propiedad;
            cmd.Parameters.Add(new SqlParameter("@Valor_Anterior", SqlDbType.VarChar)).Value = Convert.ToString(entity.valorAnterior);
            cmd.Parameters.Add(new SqlParameter("@Valor_Actual", SqlDbType.VarChar)).Value = Convert.ToString(entity.valorActual);
            cmd.Parameters.Add(new SqlParameter("@idFila", SqlDbType.Int)).Value = entity.idFila;
            cmd.Parameters.Add(new SqlParameter("@dvh", SqlDbType.Int)).Value = entity.dvh;
            int Result = master.ExecuteNonQuery(cmd);
            return Result;
        }

        public IEnumerable<Control_de_Cambios> GetAll(int idTabla)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idTabla", SqlDbType.VarChar)).Value = idTabla;
                var tableResult = master.ExecuteReader(cmd);
                var listControlCambios = new List<Domain.Control_de_Cambios>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listControlCambios.Add(new Domain.Control_de_Cambios 
                    {
                        Id = Convert.ToInt32(item[0]),
                        idUsuario = Convert.ToInt16(item[1]),
                        idTabla= Convert.ToInt16(item[2]),
                        fechaHoraCambio = Convert.ToDateTime(item[3].ToString().Trim()),
                        state = Convert.ToString(item[4].ToString().Trim()),
                        propiedad = Convert.ToString(item[5].ToString().Trim()),
                        valorAnterior = Convert.ToString(item[6].ToString().Trim()),
                        valorActual= Convert.ToString(item[7].ToString().Trim()),
                        idFila = Convert.ToInt32(item[8]),
                        dni = Convert.ToInt32(item[9]),
                        dvh = Convert.ToInt32(item[10])
                    });
                }
                return listControlCambios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Control_de_Cambios> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Control_de_Cambios entity)
        {
            throw new NotImplementedException();
        }
    }
}
