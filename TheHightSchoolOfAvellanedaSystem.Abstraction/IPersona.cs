using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Abstraction
{
    public interface IPersona
    {
        long dni { get; set; }
        string apellido { get; set; }
        string nombre { get; set; }
        int dvh { get; set; }
    }
}
