using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.DataAccess;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class FichasRepository : IFichasRepository
    {
        private String procesoBusquedaDeFichas;
        private String procesoEditarDeFichas;
        private String procesoBajaLogica;
        public FichasRepository()
        {
            // procedimiento guardados.
            procesoBusquedaDeFichas = "SP_GET_FICHAS";
            procesoEditarDeFichas = "SP_INSERT_UPDATE_FICHAS";

            // nuevo Matias.
            procesoBajaLogica = "SP_ELIMINAR_FICHAS";
        }
        public int Add(Ficha entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ficha> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ficha ficha)
        {
            try
            {

                MasterConexion master = new MasterConexion();

                var parametros = this.crearParametrosParaEditarFichas(ficha);
                // parece que aqui hace una actualizacion con un procedimiento guardado.
                bool exito = master.EditEntity<Ficha>(procesoEditarDeFichas, parametros);

                return exito;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //================
        // nuevo Matias.
        public bool Baja(Ficha ficha, int idUsuario)
        {
            try
            {

                MasterConexion master = new MasterConexion();

                // tomo parametros para la baja logica.
                var parametros = this.ParametroBajaLogica(ficha,idUsuario);
                // utilizo la clase EditEntity para la baja logica.
                bool exito = master.EditEntity<Ficha>(procesoBajaLogica, parametros);

                return exito;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //====================
        private Object ParametroBajaLogica(Ficha ficha, int idUsuario)
        {
            return new
            {
                @USUARIO = Convert.ToString(idUsuario),
                @ID_FICHA = ficha.Id
            };
        }

        // nuevo 2.
        //public int baja2(Ficha ficha)
        //{
        //    int resultados;
        //    MasterConexion master = new MasterConexion();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = procesoBajaLogica.ToString();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = ficha.Id;
        //    cmd.Parameters.Add(new SqlParameter("@fecha_elim", SqlDbType.NVarChar)).Value = ficha.FechaDeFallecimiento;
        //    return resultados= master.ExecuteNonQuery(cmd);
        //}
        //============================


        public List<Ficha> listarFichasSegunFiltro(Filtro filtro)
        {
            try
            {

                MasterConexion master = new MasterConexion();

                var parametros = this.crearParametrosParaBsquedaDeFichas(filtro);

                return (List<Ficha>) master.GetEntities<Ficha>(procesoBusquedaDeFichas,parametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Object crearParametrosParaBsquedaDeFichas(Filtro filtro)
        {
           return new
            {
                filtro.nombre,
                fecha_fallecimiento = filtro.fechaDeNacimiento,
                filtro.conyuge,
                filtro.padre,
                filtro.madre,
                filtro.domicilio,
                filtro.documento
            };
        }

        private Object crearParametrosParaEditarFichas(Ficha ficha)
        {
            return new
            {
               // ficha.Usuario,
                ficha.Id,
                ficha.Nombre,
                ficha.Sexo,
                ficha.Estudios,
                ficha.FechaDeNacimiento,
                ficha.FechaDeFallecimiento,
                ficha.HoraDeFallecimiento,
                ficha.Edad,
                ficha.LugarDeFallecimiento,
                ficha.EstadoCivil,
                ficha.Conyugue,
                ficha.Padre,
                ficha.Madre,
                ficha.Domicilio,
                ficha.Partido,
                ficha.Nacionalidad,
                ficha.Provincia,
                ficha.Documento,
                ficha.Profesion,
                ficha.Medico,
                ficha.Diagnostico,
                ficha.RegistroCivil,
                ficha.Cementerio,
                ficha.HoraInh,
                ficha.Gastos,
                ficha.Beneficios,
                ficha.Usuario,
                ficha.Domicilio2,
                ficha.CodigoPostal,
                ficha.Documento2,
                ficha.TipoAtaud
            };
        }

  
    }
}
