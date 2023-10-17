using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;


namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Bitacora : Entity, IBitacora
    {
        public int Id { get ; set ; }
        public int idUsuario { get; set ; }
        public long dni { get; set ; }
        
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string descripcion { get; set; }

        public int idMovimiento { get; set; } 
        public int dvh { get; set; }
        
    }
}
