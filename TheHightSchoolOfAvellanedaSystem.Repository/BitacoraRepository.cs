using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class BitacoraRepository : IGenericRepository<Domain.Bitacora>, IBitacoraRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        private string selectWhitFiltersAsc;
        private string selectWhitFiltersDesc;
        private string selectLastBitacora;
        private string updateDVH;

        public BitacoraRepository()
        {
            selectAll = "SP_BITACORA_SELECT_ALL";
            insert = "SP_BITACORA_ADD";
            update = "";
            delete = "";
            selectWhitFiltersAsc = "SP_BITACORA_SELECT_X_USUARIO_X_CRITICIDAD_Y_FECHAS_ASC_2023";
            selectWhitFiltersDesc = "SP_BITACORA_SELECT_X_USUARIO_X_CRITICIDAD_Y_FECHAS_ASC_2023";
            selectLastBitacora = "SP_BITACORA_TRAER_ULTIMO";
            updateDVH = "SP_BITACORA_UPDATE_DVH";

        }

        public IEnumerable<Domain.Bitacora> GetAllWhitFilters(DateTime? fechaDesde, DateTime? fechaHasta, int? usuario, string criticidad, bool? formaAscendente)
        {
            if (fechaDesde.ToString() == "01/01/0001 0:00:00") { fechaDesde = null; }
            if (fechaHasta.ToString() == "01/01/0001 0:00:00") { fechaHasta = null; }
            //if (usuario == 0) { usuario == null; }
            try
            {
                MasterConexion master = new MasterConexion(); 
                SqlCommand cmd = new SqlCommand();

                if ((bool)formaAscendente)
                {
                    cmd.CommandText = selectWhitFiltersAsc;
                }
                else
                {
                    cmd.CommandText = selectWhitFiltersDesc;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@Usuario", usuario == 0 ? (object)DBNull.Value : usuario));
                cmd.Parameters.Add(new SqlParameter("@Criticidad", criticidad == null ? (object)DBNull.Value : criticidad));
                cmd.Parameters.Add(new SqlParameter("@FechaDesde", fechaDesde == null ? (object)DBNull.Value : fechaDesde));
                cmd.Parameters.Add(new SqlParameter("@FechaHasta", fechaHasta == null ? (object)DBNull.Value : fechaHasta));

                var tableResult = master.ExecuteReader(cmd);
                Encriptación unaBitacoraDesencriptada = new Encriptación();
                var listBitacoras = new List<Domain.Bitacora>();
                //CultureInfo ci = CultureInfo.InvariantCulture;
                foreach(DataRow item in tableResult.Rows)
                {
                    listBitacoras.Add(new Domain.Bitacora
                    {
                        Id = Convert.ToInt32(item[0]),
                        idUsuario= Convert.ToInt32(item[1]),
                        dni = Convert.ToInt32(item[2]),
                        fecha = Convert.ToDateTime(item[3].ToString().Trim()),
                        hora = Convert.ToDateTime(item[4].ToString().Trim().Trim()).ToShortTimeString(),
                        dvh = Convert.ToInt32(item[5]),
                        idMovimiento= Convert.ToInt32(item[6]),
                        descripcion = unaBitacoraDesencriptada.Desencriptar(item[7].ToString().Trim(), "Tyson"),
                        //Bit_Criticidad = item[6].ToString().Trim(),
                    }); 
                }
                return listBitacoras;

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

        public int GetLasBitacora()
        {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectLastBitacora;
                cmd.CommandType = CommandType.StoredProcedure;
                
                var tableResult = master.ExecuteReader(cmd);
                int bitacora=0;
                foreach (DataRow item in tableResult.Rows)
                {
                    bitacora = int.Parse(item["Total_Bit"].ToString());
                };
                return bitacora;
        }


        public int Add(Domain.Bitacora entity)
        {
            MasterConexion master = new MasterConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = insert;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = entity.Id;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.BigInt)).Value = entity.idUsuario;
            cmd.Parameters.Add(new SqlParameter("@dni", SqlDbType.BigInt)).Value = entity.dni;
            cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = entity.fecha;
            cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.Time)).Value = entity.hora;
            cmd.Parameters.Add(new SqlParameter("@dvh", SqlDbType.BigInt)).Value = entity.dvh;
            cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.BigInt)).Value = entity.idMovimiento;
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = entity.descripcion;
            int Result = master.ExecuteNonQuery(cmd);
            return Result;
        }

        public IEnumerable<Domain.Bitacora> GetAll()
        {
            try 
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listBitacoras = new List<Domain.Bitacora>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listBitacoras.Add(new Domain.Bitacora
                    {
                        Id = Convert.ToInt32(item[0]),
                        idUsuario = Convert.ToInt32(item[1]),
                        dni = Convert.ToInt32(item[2]),
                        fecha = Convert.ToDateTime(item[3].ToString().Trim()),
                        hora = item[4].ToString().Trim(),
                        dvh = Convert.ToInt32(item[5].ToString().Trim()),
                        idMovimiento = Convert.ToInt32(item[6].ToString().Trim()), 
                        descripcion = item[7].ToString().Trim(),
                    });
                }
                return listBitacoras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Domain.Bitacora entity)
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
                cmd.Parameters.Add(new SqlParameter("@dvh", SqlDbType.Int)).Value = nuevoDVH;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = Id;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
