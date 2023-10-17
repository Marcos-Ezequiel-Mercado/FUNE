using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public abstract class Persona
    {
        private Email _email;
        private readonly Domicilio _domicilio;
        //private Localidad localidad;
        public Persona()
        {

        }

        public Persona(Email email)
        {
            if (email == null) 
                throw new Exception("No se puede crear al usuario si no se agrega el email");
            _email = new Email();
            _domicilio = new Domicilio();
        }
        public void agregarDomicilio(string calle, int numero, int codigoPostal, Localidad localidad, long dni, int dvh)
        {
            Domicilio domicilio = new Domicilio(calle, numero, codigoPostal, localidad, dni, dvh);
            domicilio.Calle = calle;
            domicilio.Numero = numero;
            domicilio.CodigoPostal = codigoPostal;
            domicilio.Localidad = localidad;
            domicilio.Dni = dni;
            domicilio.Dvh = dvh;
        }

        public long dni { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set;}
        public Domicilio Domicilio { get { return _domicilio; } }
        public Email Email { get { return _email; } set { _email = value; } }

        public int dvh { get; set;}
    }
}
