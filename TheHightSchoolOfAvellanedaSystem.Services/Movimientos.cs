using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;

namespace TheHightSchoolOfAvellanedaSystem.Services
{
    public static class Movimientos
    {
        public static IMovimientos SetDVH(IMovimientos movimientos)
        {
            DV dv = new DV();
            string cadenaParaMovimento = movimientos.Id + movimientos.descripcion + movimientos.idCriticidad;
            movimientos.dvh = Convert.ToInt16(dv.ActualizarDV(cadenaParaMovimento));
            return movimientos;
        }

        public static IMovimientos SetDVHViejos(IMovimientos movimieto)
        {
            DV dv = new DV();
            string cadenaParaMovimientoVieja = movimieto.Id + movimieto.descripcion + movimieto.idCriticidad;
            movimieto.dvh = Convert.ToInt16(dv.ActualizarDV(cadenaParaMovimientoVieja));
            return movimieto;
        }
    }
}
