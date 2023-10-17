using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Filtro
    {
        public Filtro()
        {
        }

        public Filtro(string nombre, string fechaDeNacimiento, string conyuge, string padre, string madre,
            string documento, string domicilio)
        {
            this.nombre = nombre;
            this.fechaDeNacimiento = fechaDeNacimiento;
            this.conyuge = conyuge;
            this.padre = padre;
            this.madre = madre;
            this.documento = documento;
            this.domicilio = domicilio;
        }


        public string nombre { get; set; }
        public string fechaDeNacimiento { get; set; }
        public string conyuge { get; set; }
        public string padre { get; set; }
        public string madre { get; set; }
        public string documento { get; set; }
        public string domicilio { get; set; }

    }
}
