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

        public Filtro(string nombre, string fechaDeNacimiento, string responsable)
        {
            this.Nombre = nombre;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.Responsable = responsable;
        }


        public string Nombre { get; set; }
        public string FechaDeNacimiento { get; set; }
        public string Responsable { get; set; }

    }
}
