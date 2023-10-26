using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;
//using TheHightSchoolOfAvellanedaSystem.Domain;
//MODIFICADO
namespace TheHightSchoolOfAvellanedaSystem.Services
{
    public class ManejadorDeSesion
    {
        static ManejadorDeSesion _sesion;
        IUsuario _usuario;
        
        public static ManejadorDeSesion GetInstance
        {
            get
            {
                if (_sesion == null) _sesion = new ManejadorDeSesion();
                return _sesion;
            }
        }

        public  IUsuario Session //ojo este atributo
        {
            get
            {
                return _usuario;
            }
        }

        public  bool IsLogged()
        {
            return _usuario != null;
        }

        public  void Login(IUsuario usuario)
        {
            _usuario = usuario;

        }

        public  void Logout()
        {
            _usuario = null;
        }

        public bool IsInRole(TipoPermiso permiso)
        {            
            foreach (var item in _usuario.patentes)
            {
                if (item.Equals(permiso)) { 
                    return true;                                    
                }

            }

            return false;
        }

        public bool IsAdmin()
        {
            foreach (var item in _usuario.patentes)
            {
                if (item.ToString().Equals(TipoPermiso.admin.ToString()))
                {
                    return true;
                }

            }

            return false;
        }

    }

}
