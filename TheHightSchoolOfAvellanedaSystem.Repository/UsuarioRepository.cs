using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        private string selectByUsuPass;
        private string selectById;
        private string selectByUsu;
        private string updateDVH;
        private string selectLast;
        private string insertLanguaje;
        private string getLanguaje; 
        private string updateLanguaje;
        private string getPatentes;

        public UsuarioRepository()
        {
            selectAll = "SP_SELECT_USUARIOS_TODOS";
            insert = "SP_USUARIOS_ADD";
            update = "SP_USUARIO_UPDATE";
            delete = "";
            selectByUsuPass = "SP_SELECT_USUARIO";
            selectById = "SP_USUARIO_SELECT_x_ID";
            selectByUsu = "SP_SELECT_USUARIO_X_NOMBRE_USU";
            selectLast = "SP_USUARIO_SELECT_LAST"; 
            updateDVH = "SP_USUARIO_UPDATE_DVH";
            insertLanguaje= "SP_USUARIO_ASSIGN_LANGUAGE";
            getLanguaje = "SP_USUARIO_GET_IDIOMA";
            updateLanguaje = "SP_USUARIO_UPDATE_IDIOMA";
            getPatentes = "SP_USUARIO_GET_PATENTES";

        }

        public int Add(Domain.Usuario entity)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insert;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int)).Value = entity.Id;
                cmd.Parameters.Add(new SqlParameter("@dni", SqlDbType.BigInt)).Value = entity.dni;
                cmd.Parameters.Add(new SqlParameter("@apellidoPersona", SqlDbType.VarChar)).Value = entity.apellido;
                cmd.Parameters.Add(new SqlParameter("@nombrePersona", SqlDbType.VarChar)).Value = entity.nombre;
                cmd.Parameters.Add(new SqlParameter("@dvhPersona", SqlDbType.Int)).Value = entity.dvh;
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", SqlDbType.VarChar)).Value = entity.username;
                cmd.Parameters.Add(new SqlParameter("@contrasenia", SqlDbType.VarChar)).Value = entity.password;
                cmd.Parameters.Add(new SqlParameter("@cai", SqlDbType.BigInt)).Value = entity.cai;
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.BigInt)).Value = entity.estado;
                cmd.Parameters.Add(new SqlParameter("@primer_acceso", SqlDbType.Bit)).Value = entity.primerAcceso;
                cmd.Parameters.Add(new SqlParameter("@idIdioma", SqlDbType.BigInt)).Value = entity.idIdioma;
                cmd.Parameters.Add(new SqlParameter("@dvh", SqlDbType.BigInt)).Value = entity.dvh;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = entity.email;
                cmd.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar)).Value = entity.calle;
                cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.BigInt)).Value = entity.numero;
                cmd.Parameters.Add(new SqlParameter("@codigoPostal", SqlDbType.BigInt)).Value = entity.codigoPostal;
                cmd.Parameters.Add(new SqlParameter("@localidad", SqlDbType.BigInt)).Value = entity.localidad;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Domain.Usuario entity)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = update;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.BigInt)).Value = entity.Id;
                cmd.Parameters.Add(new SqlParameter("@dni", SqlDbType.BigInt)).Value = entity.dni;
                cmd.Parameters.Add(new SqlParameter("@apellidoPersona", SqlDbType.VarChar)).Value = entity.apellido;
                cmd.Parameters.Add(new SqlParameter("@nombrePersona", SqlDbType.VarChar)).Value = entity.nombre;
                cmd.Parameters.Add(new SqlParameter("@dvhPersona", SqlDbType.Int)).Value = entity.dvh;
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", SqlDbType.VarChar)).Value = entity.username;
                cmd.Parameters.Add(new SqlParameter("@contrasenia", SqlDbType.VarChar)).Value = entity.password;
                cmd.Parameters.Add(new SqlParameter("@cai", SqlDbType.BigInt)).Value = entity.cai;
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.Bit)).Value = entity.estado;
                cmd.Parameters.Add(new SqlParameter("@primer_acceso", SqlDbType.Bit)).Value = entity.primerAcceso;
                cmd.Parameters.Add(new SqlParameter("@idIdioma", SqlDbType.BigInt)).Value = entity.idIdioma;
                cmd.Parameters.Add(new SqlParameter("@dvh", SqlDbType.BigInt)).Value = entity.dvh;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Usuario> GetAll()
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var email = new Email();
                var listUsuarios = new List<Domain.Usuario>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listUsuarios.Add(new Domain.Usuario(email)
                    {
                        Id = Convert.ToInt32(item[0]),
                        dni = Convert.ToInt32(item[1]),
                        username = item[2].ToString().Trim(),
                        password = item[3].ToString().Trim().Trim(),
                        cai = Convert.ToInt16(item[4].ToString().Trim()),
                        estado = Convert.ToInt32(item[5].ToString().Trim()),
                        primerAcceso = Convert.ToBoolean(item[6].ToString().Trim()),
                        dvh = Convert.ToInt32(item[7])                        
                    });
                }
                return listUsuarios;
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
        //public Domain.Usuario ObtenerUsuarioPorUsernamePassword(string username, string password)
        //{
        //    MasterConexion master = new MasterConexion();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = selectByUsuPass;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@Usu_Nombre_Usu", SqlDbType.VarChar)).Value = username;
        //    cmd.Parameters.Add(new SqlParameter("@Usu_Contraseña", SqlDbType.VarChar)).Value = password;

        //    var tableResult = master.ExecuteReader(cmd);
        //    var usuario = new Domain.Usuario();
        //    Encriptación unUsuarioEncriptado = new Encriptación();
        //    foreach (DataRow item in tableResult.Rows)
        //    {
        //        usuario.Id = int.Parse(item["Usu_Id"].ToString());
        //        usuario.Username = unUsuarioEncriptado.Desencriptar(item["Usu_NombreUsu"].ToString().Trim(), "Michael");
        //        usuario.Password = item["Usu_Contraseña"].ToString();
        //        usuario.Nombre_y_Apellido = item["Usu_Nombre_y_Apellido"].ToString();
        //        usuario.Incorrectos = int.Parse(item["Usu_Cont_Incorrectos"].ToString());
        //        usuario.Usuario_DVH = int.Parse(item["Usu_DVH"].ToString());
        //        usuario.Usuario_Estado = Convert.ToBoolean(item["Est_Id"].ToString());
        //    };
        //    return usuario;
        //}

        //public Domain.Usuario ObtenerUsuarioPorId(int Id)
        //{
        //    try
        //    {
        //        MasterConexion master = new MasterConexion();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = selectByUsuPass;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@Usu_Id", SqlDbType.VarChar)).Value = Id;

        //        var tableResult = master.ExecuteReader(cmd);
        //        var usuario = new Domain.Usuario();
        //        Encriptación unUsuarioEncriptado = new Encriptación();
        //        foreach (DataRow item in tableResult.Rows)
        //        {
        //            usuario.Id = int.Parse(item["Usu_Id"].ToString());
        //            usuario.Username = unUsuarioEncriptado.Desencriptar(item["Usu_NombreUsu"].ToString().Trim(), "Michael");
        //            usuario.Password = item["Usu_Contraseña"].ToString();
        //        };
        //        return usuario;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Domain.Usuario ObtenerUsuarioPorUsuario(string username)
        //{
        //    MasterConexion master = new MasterConexion();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = selectByUsu;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@Usu_Nombre_Usu", SqlDbType.VarChar)).Value = username;
        //    var tableResult = master.ExecuteReader(cmd);
        //    var usuario = new Domain.Usuario();
        //    Encriptación unUsuarioEncriptado = new Encriptación();
        //    foreach (DataRow item in tableResult.Rows)
        //    {
        //        usuario.Id = int.Parse(item["Usu_Id"].ToString());
        //        usuario.Username = unUsuarioEncriptado.Desencriptar(item["Usu_NombreUsu"].ToString().Trim(), "Michael");
        //        usuario.Password = item["Usu_Contraseña"].ToString();
        //        usuario.Nombre_y_Apellido = item["Usu_Nombre_y_Apellido"].ToString();
        //        usuario.Incorrectos = int.Parse(item["Usu_Cont_Incorrectos"].ToString());
        //        usuario.Usuario_DVH = int.Parse(item["Usu_DVH"].ToString());
        //        usuario.Usuario_Estado = Convert.ToBoolean(item["Est_Id"].ToString());
        //    };
        //    return usuario;
        //}

        Domain.Usuario IUsuarioRepository.ObtenerUsuarioPorUsernamePassword(string username, string password)
        {
            try
            {
            MasterConexion master = new MasterConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectByUsuPass;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = username;
            cmd.Parameters.Add(new SqlParameter("@contrasenia", SqlDbType.VarChar)).Value = password;

            var tableResult = master.ExecuteReader(cmd);

                var email = new Email();

            var usuario = new Domain.Usuario(email);
            Encriptación unUsuarioEncriptado = new Encriptación();
            foreach (DataRow item in tableResult.Rows)
            {
                    usuario.Id = int.Parse(item["id_usuario"].ToString());
                    usuario.dni = int.Parse(item["dni"].ToString());
                    usuario.username = unUsuarioEncriptado.Desencriptar(item["nombre"].ToString().Trim(), "Michael");
                    usuario.password = item["contrasenia"].ToString();
                    usuario.cai = int.Parse(item["cai"].ToString());
                    usuario.estado = Convert.ToInt32(item["idEstado"].ToString());
                    usuario.primerAcceso = Convert.ToBoolean(item["primer_acceso"].ToString());
                    usuario.dvh = int.Parse(item["dvh"].ToString());
            };
            return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }   

        }

        Domain.Usuario IUsuarioRepository.ObtenerUsuarioPorId(int id)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectById;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = id;

                var tableResult = master.ExecuteReader(cmd);
                var email = new Email();
                var usuario = new Domain.Usuario(email);
                Encriptación unUsuarioEncriptado = new Encriptación();
                foreach (DataRow item in tableResult.Rows)
                {
                    usuario.Id = int.Parse(item[0].ToString());
                    usuario.dni = int.Parse(item[1].ToString());
                    usuario.username = unUsuarioEncriptado.Desencriptar(item[2].ToString().Trim(), "Michael");
                    usuario.password = item[3].ToString();
                    usuario.cai = int.Parse(item[4].ToString());
                    usuario.estado = Convert.ToInt32(item[5].ToString());
                    usuario.primerAcceso = Convert.ToBoolean(item[6].ToString());
                    usuario.idIdioma = Convert.ToInt32(item[7].ToString().Trim());
                    usuario.dvh = int.Parse(item[8].ToString());
                };
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Domain.Usuario IUsuarioRepository.ObtenerUsuarioPorUsuario(string username)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectByUsu;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = username;
                var tableResult = master.ExecuteReader(cmd);
                var email = new Email();
                var usuario = new Domain.Usuario(email);
                Encriptación unUsuarioEncriptado = new Encriptación();
                foreach (DataRow item in tableResult.Rows)
                {
                    usuario.dni = int.Parse(item[0].ToString());
                    usuario.apellido = item[1].ToString().Trim();
                    usuario.nombre = item[2].ToString().Trim();
                    usuario.Id = int.Parse(item[3].ToString());
                    usuario.username = unUsuarioEncriptado.Desencriptar(item[4].ToString().Trim(), "Michael");
                    usuario.password = item[5].ToString();
                    usuario.cai = int.Parse(item[6].ToString());
                    usuario.primerAcceso = Convert.ToBoolean(item[7].ToString());
                    usuario.estado = Convert.ToInt32(item[8].ToString());
                    usuario.idIdioma = Convert.ToInt32(item[9].ToString().Trim());
                    usuario.dvh = int.Parse(item[10].ToString());
                };
                return usuario;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        IEnumerable<Domain.Usuario> IGenericRepository<Domain.Usuario>.GetAll()
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = selectAll;
                cmd.CommandType = CommandType.StoredProcedure;
                var tableResult = master.ExecuteReader(cmd);
                var listUsuarios = new List<Domain.Usuario>();
                var email = new Email();
                foreach (DataRow item in tableResult.Rows)
                {
                    listUsuarios.Add(new Domain.Usuario()
                    {
                        dni = Convert.ToInt32(item[0]),
                        apellido = item[1].ToString().Trim(),
                        nombre = item[2].ToString().Trim(),
                        Id = Convert.ToInt32(item[3]),
                        username = item[4].ToString().Trim(),
                        password = item[5].ToString().Trim().Trim(),
                        cai = Convert.ToInt32(item[6].ToString().Trim()),
                        primerAcceso = Convert.ToBoolean(item[7].ToString().Trim()),
                        estado = Convert.ToInt32(item[8].ToString().Trim()),
                        idIdioma = Convert.ToInt32(item[9].ToString().Trim()),
                        dvh = Convert.ToInt32(item[10].ToString().Trim()),
                        email = item[11].ToString().Trim(),
                        calle = item[12].ToString().Trim(),
                        numero = Convert.ToInt32(item[13].ToString().Trim()),
                        codigoPostal = Convert.ToInt32(item[14].ToString().Trim()),
                        localidad = Convert.ToInt32(item[15].ToString().Trim()),
                    });
                }
                return listUsuarios;
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

        public int UpdateDVH(int nuevoDVH, int Id)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updateDVH;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Usu_DVH", SqlDbType.Int)).Value = nuevoDVH;
                cmd.Parameters.Add(new SqlParameter("@Usu_Id", SqlDbType.Int)).Value = Id;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int selectLastUser()
        {
            MasterConexion master = new MasterConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = selectLast;
            cmd.CommandType = CommandType.StoredProcedure;

            var tableResult = master.ExecuteReader(cmd);
            int usuario = 0;
            foreach (DataRow item in tableResult.Rows)
            {
                usuario = int.Parse(item["Total"].ToString());
            };
            return usuario;
        }
        public int isertLanguage(int idUsuario, int idIdioma, string descripcionIdioma)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insertLanguaje;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int)).Value = idUsuario;
                cmd.Parameters.Add(new SqlParameter("@id_idioma", SqlDbType.Int)).Value = idIdioma;
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = descripcionIdioma;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getUserLanguage(int idUsuario)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = getLanguaje;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_Usuario", SqlDbType.Int)).Value = idUsuario;
                var tableResult = master.ExecuteReader(cmd);
                int idioma = 0;
                foreach (DataRow item in tableResult.Rows)
                {
                    idioma = int.Parse(item["Idio_Id"].ToString());
                };
                return idioma;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateUserLanguage(int idUsuario, int idIdioma, string descripcionIdioma)
        {
            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updateLanguaje;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_Usuario", SqlDbType.Int)).Value = idUsuario;
                cmd.Parameters.Add(new SqlParameter("@Id_Idioma", SqlDbType.Int)).Value = idIdioma;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = descripcionIdioma;
                int Result = master.ExecuteNonQuery(cmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Domain.Usuario addPatentes(Domain.Usuario usuario)
        {


            try
            {
                MasterConexion master = new MasterConexion();
                SqlCommand cmd = new SqlCommand();                
                cmd.CommandText = getPatentes;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_Usuario", SqlDbType.Int)).Value = usuario.Id;
                var tableResult = master.ExecuteReader(cmd);
                
                List<string> pat = new List<string>();
                foreach (DataRow item in tableResult.Rows)
                {
                    pat .Add(item["patente"].ToString());
                };


                usuario.patentes = pat;

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }       
}
