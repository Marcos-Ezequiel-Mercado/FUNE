using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Abstraction
{
    public interface IBitacora : IEntity 
    {
        int Id { get; set; }
        int idUsuario { get; set; }
        long dni { get; set; }

        DateTime fecha { get; set; }
        string hora { get; set; }
        string descripcion { get; set; }

        int idMovimiento { get; set; }
        int dvh { get; set; }
    }
}

