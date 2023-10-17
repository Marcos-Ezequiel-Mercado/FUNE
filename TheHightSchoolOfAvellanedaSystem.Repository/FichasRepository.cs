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

        private Object crearParametrosParaEditarFichas(Ficha filtro)
        {
            return new
            {
               
            };
        }
    }
}
