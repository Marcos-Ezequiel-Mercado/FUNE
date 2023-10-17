using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Control_de_Cambios : Entity
    {
        public int Id { get ; set ; }
        public int idUsuario { get; set; }
        public int idTabla { get; set; }
        public DateTime fechaHoraCambio { get; set; }
        public string  state { get; set; }
        public string propiedad { get; set; }
        public string valorAnterior { get; set; }
        public string valorActual { get; set; }
        public int idFila { get; set; }
        public long dni { get; set; }
        public int dvh { get; set; } 
        
    }
}
