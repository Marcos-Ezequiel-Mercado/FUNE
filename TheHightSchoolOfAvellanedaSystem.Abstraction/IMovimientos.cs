using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Abstraction
{
    public interface IMovimientos:IEntity
    {
        int Id { get; set; }
        string descripcion { get; set; }
        int idCriticidad { get; set; }
        int dvh { get; set; }

    }
}
