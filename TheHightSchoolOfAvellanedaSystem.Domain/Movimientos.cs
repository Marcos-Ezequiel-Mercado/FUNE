using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Movimientos : Entity, IMovimientos
    {
        public int Id { get ; set ; }
        public string descripcion { get; set; }
        public int idCriticidad { get; set; }
        public int dvh { get; set; }
        
    }
}
