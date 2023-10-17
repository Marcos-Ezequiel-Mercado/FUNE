using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Localidad : Entity
    {
        public int Id { get ; set ; }

        public string descripcion { get; set ; }

        public int dvh { get; set; } 
    }
}
