using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;

namespace TheHightSchoolOfAvellanedaSystem.Services
{
    public static class Bitacora
    {
        public static IBitacora SetDVH(IBitacora bitacora)
        {
            DV dv = new DV();
            DateTime fechaHora = DateTime.Now;
            bitacora.fecha = Convert.ToDateTime(fechaHora.ToShortDateString());
            bitacora.hora = fechaHora.ToShortTimeString();

            string cadenaParaBitacora = bitacora.idUsuario + Convert.ToString(bitacora.dni) + bitacora.fecha + 
                                        bitacora.hora + 
                                        bitacora.idMovimiento + bitacora.descripcion;
            bitacora.dvh = Convert.ToInt16(dv.ActualizarDV(cadenaParaBitacora));
            return bitacora;
        }

        public static IBitacora SetDVHViejos(IBitacora bitacora)
        {
            DV dv = new DV();
            string cadenaParaBitacoraVieja = bitacora.idUsuario + Convert.ToString(bitacora.dni) + bitacora.fecha.ToShortDateString() + 
                                             Convert.ToDateTime(bitacora.hora.ToString()).ToShortTimeString() + 
                                             bitacora.idMovimiento + bitacora.descripcion;
            bitacora.dvh = Convert.ToInt16(dv.ActualizarDV(cadenaParaBitacoraVieja));
            return bitacora;
        }
    }
}
