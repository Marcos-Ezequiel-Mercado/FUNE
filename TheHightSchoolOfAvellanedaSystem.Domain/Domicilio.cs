using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Domicilio : Entity
    {
        public int Id { get ; set ; }
        public string Calle { get; set ; }
        public int Numero { get; set ; }
        public int CodigoPostal { get; set ; }
        public Localidad Localidad { get; set ; }
        public long Dni { get; set; }
        public int Dvh { get; set; }
        
        //CONSTRUCTORES
        public Domicilio()
        {
        }

        public Domicilio(string calle, int numero, int codigoPostal, Localidad localidad, long dni, int dvh)
        {
            Calle = calle;
            Numero = numero;
            CodigoPostal = codigoPostal;
            Localidad = localidad;
            Dni = dni;
            Dvh = dvh;
        }

    }
}
