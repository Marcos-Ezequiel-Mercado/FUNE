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
        private String procesoBusquedaFichas;
        private String procesoEditarFichas;
        private String procesoEliminarFichas;
        private MasterConexion masterConexion;
        public FichasRepository()
        {
            masterConexion = new MasterConexion();
            procesoBusquedaFichas = "SP_GET_FICHAS";
            procesoEditarFichas = "SP_INSERT_UPDATE_FICHAS";
            procesoEliminarFichas = "SP_ELIMINAR_FICHAS";
        }
        public bool Add(Ficha ficha, Usuario usuarioLogueado)
        {
            try
            {

                var parametros = this.crearParametrosFichas(ficha, 1, usuarioLogueado.Id.ToString());

                bool exito = masterConexion.EditEntity<Ficha>(procesoEditarFichas, parametros);

                return exito;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Ficha> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Usuario usuario,string idFicha)
        {
            try
            {

                var parametros = this.crearParametrosEliminarFichas(idFicha, usuario);

                bool exito = masterConexion.EditEntity<Ficha>(procesoEliminarFichas, parametros);

                return exito;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      

        public bool Update(Ficha ficha)
        {
            try
            {

                var parametros = this.crearParametrosFichas(ficha,0,ficha.Usuario);

                bool exito = masterConexion.EditEntity<Ficha>(procesoEditarFichas, parametros);

                return exito;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Ficha> listarFichasSegunFiltro(Filtro filtro)
        {
            try
            {

                var parametros = this.crearParametrosParaBusquedaDeFichas(filtro);

                return (List<Ficha>) masterConexion.GetEntities<Ficha>(procesoBusquedaFichas,parametros);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Object crearParametrosParaBusquedaDeFichas(Filtro filtro)
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

        private object crearParametrosEliminarFichas(string ficha, Usuario usuario)
        {
            return new
            {
                @USUARIO = usuario.nombre + " " + usuario.apellido,
                @ID_FICHA = ficha,
            };
        }

        private Object crearParametrosFichas(Ficha ficha, int insert,String idUsuario)
        {
            return new
            {
                @INSERT = insert,
                @USUARIO  = idUsuario,
                @ID_FICHA = ficha.Id,
                @NOMBRE = ficha.Nombre,
                @SEXO = ficha.Sexo,
                @ESTUDIOS = ficha.Estudios,
                @FECHANAC =ficha.FechaDeNacimiento,
                @FECHAFALLE = ficha.FechaDeFallecimiento,
                @HORAFALLE = ficha.HoraDeFallecimiento,
                @EDAD = ficha.Edad,
                @LUGFALLE = ficha.LugarDeFallecimiento,
                @ESTCIVIL = ficha.EstadoCivil,
                @CONYUGE = ficha.Conyugue,
                @PADRE = ficha.Padre,
                @MADRE = ficha.Madre,
                @DOMICILIO = ficha.Domicilio,
                @PARTIDO = ficha.Partido,
                @NACIONAL  = ficha.Nacionalidad,
                @PROVINCIA = ficha.Provincia,
                @DOCUMENTO = ficha.Documento,
                @PROFESION = ficha.Profesion,
                @MEDICO = ficha.Medico,
                @DIAGNOSTIC = ficha.Diagnostico,
                @REGCIVIL = ficha.RegistroCivil,
                @CEMENTERIO= ficha.Cementerio,
                @HORAINH = ficha.HoraInh,
                @FECHAINH = ficha.FechaInh,
                @GASTOS = ficha.Gastos,
                @BENEFIC = ficha.Beneficios,
                @RESPONSABLE = ficha.Responsable,
                @DIRECCION_RESP = ficha.DomicilioResponsable,
                @CODPOSTAL = ficha.CodigoPostal,
                @DOCUMENTO2_RESP = ficha.DocumentoResponsable,
                @ATAUD = ficha.Ataud,
                @AFIN = ficha.Afin
            };
        }    
    }
}
