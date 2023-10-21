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

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public class FichasRepository : IFichasRepository
    {
        private String procesoBusquedaDeFichas;
        private String procesoEditarDeFichas;
        public FichasRepository()
        {
            procesoBusquedaDeFichas = "SP_GET_FICHAS";
            procesoEditarDeFichas = "SP_INSERT_UPDATE_FICHAS";
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

                bool exito = master.EditEntity<Ficha>(procesoEditarDeFichas, parametros);

                return exito;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


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
