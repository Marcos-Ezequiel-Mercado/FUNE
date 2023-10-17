using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Services;
using DV = TheHightSchoolOfAvellanedaSystem.Domain.Digitoverificador;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class DVRepository : IGenericRepository<DV>, IDVRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        //private string selectSumDVH;
                
        public DVRepository()
        {
            selectAll = "SP_DVV_SELECT_ALL";
            insert = "";
            update = "SP_DVV_UPDATE";
            delete = "";
            //selectSumDVH = "SELECT SUM (@Columna) as Total FROM @Tabla";
            
        }

        public int ActualizarDVV(string elemento, int dv_Valor, string tabla)
        {
            throw new NotImplementedException();
        }
        public int Update(DV entity)
        {
            MasterConexion master = new MasterConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = update;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@dvv", SqlDbType.Int)).Value = entity.dvv;
            cmd.Parameters.Add(new SqlParameter("@tabla", SqlDbType.VarChar)).Value = entity.tabla;
            int Result = master.ExecuteNonQuery(cmd);
            return Result;
        }

        public int ObtenerSumDVH(string columna, string tabla)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT SUM (" + columna + ") as Total FROM " + tabla;
                var tableResult = master.ExecuteReader(cmd);
                int DVV = 0;
                foreach (DataRow item in tableResult.Rows)
                {
                    DVV = Convert.ToInt32(item["Total"] is DBNull ? 0 : item["Total"]);
                }
                return DVV;
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

        public int Add(DV entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DV> GetAll()
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listDigitosverificadores = new List<Digitoverificador>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listDigitosverificadores.Add(new Digitoverificador
                    {
                        Id= Convert.ToInt32(item[0]),
                        tabla = item[1].ToString().Trim(),
                        dvv = Convert.ToInt32(item[2].ToString().Trim()),                        
                    });
                }
                return listDigitosverificadores;
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

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }               
    }
}
