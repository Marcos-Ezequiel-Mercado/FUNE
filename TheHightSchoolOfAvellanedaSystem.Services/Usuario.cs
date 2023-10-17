using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;

namespace TheHightSchoolOfAvellanedaSystem.Services
{
    public static class Usuario
    {
        public static IUsuario SetDVH(IUsuario usuario)
        {
            DV dv = new DV();
            //usuario.Incorrectos = 0;
            string cadenaParaUsuario = //Convert.ToString(usuario.Id) + 
                                       Convert.ToString(usuario.dni) + usuario.username.Trim() + usuario.password.Trim() + 
                                       Convert.ToString(usuario.cai) + Convert.ToString(usuario.estado) + Convert.ToString(usuario.primerAcceso) +
                                       Convert.ToString(usuario.idIdioma);
            usuario.dvh = Convert.ToInt16(dv.ActualizarDV(cadenaParaUsuario));
            return usuario;
        }
        public static IUsuario setParameters(IUsuario usuario)
        {
            DV dv = new DV();
            //DateTime myDate = DateTime.Now;
            //string myDateString = myDate.ToString("dd-MM-yyyy_hh-mm-ss");
            Encriptación passEncriptada = new Encriptación();
            usuario.password = passEncriptada.Encriptar(usuario.password, "Michael");
            usuario.cai = 0;
            usuario.estado = 1;
            usuario.primerAcceso = true; 
            string cadenaParaUsuario = Convert.ToString(usuario.dni) + usuario.username.Trim() + usuario.password.Trim() + 
                                       Convert.ToString(usuario.cai) + Convert.ToString(usuario.estado) + Convert.ToString(usuario.primerAcceso) +
                                       Convert.ToString(usuario.idIdioma);
            usuario.dvh = Convert.ToInt16(dv.ActualizarDV(cadenaParaUsuario));
            return usuario;             
        }
        public static string setPass()
        {
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("dd-MM-yyyy_hh-mm-ss");
            string password = myDateString;
            return password;
        }
    }
}
